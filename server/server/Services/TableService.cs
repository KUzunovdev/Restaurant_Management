namespace server.Services
{
    public class TableService
    {
        private readonly ApplicationDbContext _context;

        public TableService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new table
        public Table CreateTable(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            // Additional logic, validation, or checks can be added here

            _context.Tables.Add(table);
            _context.SaveChanges();

            return table;
        }

        // Get a table by ID
        public Table GetTableById(int tableId)
        {
            return _context.Tables
                .FirstOrDefault(t => t.TableID == tableId);
        }

        // Get all tables
        public List<Table> GetAllTables()
        {
            return _context.Tables.ToList();
        }

        // Update an existing table
        public void UpdateTable(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            var existingTable = _context.Tables
                .FirstOrDefault(t => t.TableID == table.TableID);

            if (existingTable == null)
                throw new InvalidOperationException("Table not found");

            // Update fields of the existing table
            existingTable.Number = table.Number;
            existingTable.Capacity = table.Capacity;
            existingTable.IsOccupied = _context.Reservations.Any(r => r.TableID == existingTable.TableID);
            // ... update other fields as needed

            _context.SaveChanges();
        }

        // Delete a table by ID
        public void DeleteTable(int tableId)
        {
            var table = _context.Tables
                .FirstOrDefault(t => t.TableID == tableId);

            if (table == null)
                throw new InvalidOperationException("Table not found");

            _context.Tables.Remove(table);
            _context.SaveChanges();
        }
    }
}
