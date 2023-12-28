import React, { useState } from 'react';
import "../styles/Login.css";

function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleUsernameChange = (e) => {
        setUsername(e.target.value);
    };

    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Perform login logic here from the BE
    };

    return (
        <div className="login-container">
        <h2>Login</h2>
        <form onSubmit={handleSubmit}>
            <div className="form-group">
                <label>
                    Username:
                    <input type="text" value={username} onChange={handleUsernameChange} />
                </label>
            </div>
            <div className="form-group">
                <label>
                    Password:
                    <input type="password" value={password} onChange={handlePasswordChange} />
                </label>
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
    );
}

export default Login;
