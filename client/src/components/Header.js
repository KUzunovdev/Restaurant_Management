import React from 'react';

function Header() {
    return (
        <div>
            <header>
                <nav>
                    <ul>
                        <li>Home</li>
                        <li>Menu</li>
                        <li>Orders</li>
                        <li>Reservations</li>
                        {isAdminStaff() && <li>Inventory</li>}
                        {isAdminStaff() && <li>Inventory</li>}
                    </ul>
                </nav>
            </header>
        </div>
    );
}

function isAdminStaff() {
    // Logic to determine if the user is an admin or not

    return true;
}

export default Header;
