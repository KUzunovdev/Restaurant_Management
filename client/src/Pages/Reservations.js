import React, { useState, useEffect } from 'react';
//import ReservationTable from '../components/ReservationTable';
//import ReservationForm from '../components/ReservationForm';
import ReservationService from '../services/ReservationService';

const Reservations = () => {
    const [reservations, setReservations] = useState([]);
    const [selectedTable, setSelectedTable] = useState(null);

    // Might need to change the endpoint
    useEffect(() => {
        const fetchReservations = async () => {
            try {
                const reservationsData = await ReservationService.getReservations();
                setReservations(reservationsData);
            } catch (error) {
                console.error('Error fetching reservations:', error);
            }
        };

        fetchReservations();
    }, []);

    const handleTableSelect = (tableId) => {
        setSelectedTable(tableId);
    };

    const handleReservationSubmit = async (reservationData) => {
        try {
            // Send reservation data to the server
            await ReservationService.createReservation(reservationData);
            // Update the reservations state
            setReservations([...reservations, reservationData]);
            // Clear the selected table
            setSelectedTable(null);
        } catch (error) {
            console.error('Error creating reservation:', error);
        }
    };

    return (
        
        <div>
            {/* <h1>Reservations</h1>
            <ReservationTable
                tables={tables}
                reservations={reservations}
                selectedTable={selectedTable}
                onTableSelect={handleTableSelect}
            />
             //Pop up maybe ? 
            <ReservationForm
                selectedTable={selectedTable}
                onReservationSubmit={handleReservationSubmit}
            />*/}
        </div>
    );
};

export default Reservations;
