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
}

export default NotificationComponent;