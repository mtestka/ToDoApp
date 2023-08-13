import * as signalR from '@microsoft/signalr';
import { toast } from 'react-toastify';

const signalrService = {
    connection: null,

    startConnection: function () {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_SIGNALR_HUB_URL)
            .build();

        this.connection
            .start()
            .then(() => {
                console.log("SignalR Connected");
            })
            .catch((err) => {
                console.error("SignalR Connection Error: ", err);
            });
    },

    subscribeToNotifications: function (callback) {
        this.connection.on("ReceiveNotification", (message) => {
            toast("Task to do: " + message);
        });
    },
};

export default signalrService;