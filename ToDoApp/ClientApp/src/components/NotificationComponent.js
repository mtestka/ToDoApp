import React, { useState, useEffect } from 'react';
import signalrService from './signalrService';

function NotificationComponent() {
    const [notifications, setNotifications] = useState([]);

    useEffect(() => {
        signalrService.startConnection();
        signalrService.subscribeToNotifications((message) => {
            setNotifications((prevNotifications) => [...prevNotifications, message]);
        });
    }, []);

    return (
        <div>
            <h2>Received Notifications:</h2>
            <ul>
                {notifications.map((notification, index) => (
                    <li key={index}>{notification}</li>
                ))}
            </ul>
        </div>
    );
}

export default NotificationComponent;