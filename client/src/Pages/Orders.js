import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Orders = () => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        fetchOrders();
    }, []);


    //Might change depending on the backend endpoint
    const fetchOrders = async () => {
        try {
            const response = await axios.get('/api/orders');
            setOrders(response.data);
        } catch (error) {
            console.error('Error fetching orders:', error);
        }
    };

    //Just a placeholder for now
    const renderOrders = () => {
        return orders.map((order) => (
            <div key={order.id}>
                <p>Order ID: {order.id}</p>
                <p>Customer Name: {order.customerName}</p>     
            </div>
        ));
    };

    return (
        <div>
            <h1>Orders</h1>
            {renderOrders()}
        </div>
    );
};

export default Orders;
