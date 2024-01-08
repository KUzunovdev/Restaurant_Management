using server.Data;
using server.Models;

namespace server.Services
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new reservation
        public Reservation CreateReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            // Additional logic, validation, or checks can be added here
            //if (reservation.ReservationDate < DateTime.Now)
            //{
            //    throw new InvalidOperationException("Reservation date must be in the future.");
            //}
            //_logger.LogInformation($"Reservation created: ID {reservation.ReservationID} by Customer ID {reservation.CustomerID}");

            var overlappingReservation = _context.Reservations
                                                        .FirstOrDefault(r =>
                                                            r.TableID == reservation.TableID &&
                                                            r.ReservationDate < reservation.ReservationDate.AddHours(1));
            if (overlappingReservation != null)
            {
                // Handle conflict, for example:
                throw new InvalidOperationException("Table is already reserved during this time.");
            }
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            // Mark the corresponding table as occupied
            var table = _context.Tables.FirstOrDefault(t => t.TableID == reservation.TableID);
            if (table != null)
            {
                table.IsOccupied = true;
                _context.SaveChanges();
            }

            return reservation;
        }

        // Get a reservation by ID
        public Reservation GetReservationById(int reservationId)
        {
            return _context.Reservations
                .FirstOrDefault(r => r.ReservationID == reservationId);
        }

        // Get all reservations
        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        // Update an existing reservation
        public void UpdateReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            var existingReservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationID == reservation.ReservationID);

            if (existingReservation == null)
                throw new InvalidOperationException("Reservation not found");

            // Update fields of the existing reservation
            existingReservation.CustomerID = reservation.CustomerID;
            existingReservation.TableID = reservation.TableID;
            existingReservation.ReservationDate = reservation.ReservationDate;
            // ... update other fields as needed

            _context.SaveChanges();
        }

        // Delete a reservation by ID
        public void DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationID == reservationId);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found");

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
