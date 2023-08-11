import * as signalR from '@microsoft/signalr';

const signalrService = {
    connection: null,

    startConnection: function () {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/notificationHub") // Replace with your hub URL
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
            console.log("Received notification:", message);
            callback(message);
        });
    },
};

export default signalrService;