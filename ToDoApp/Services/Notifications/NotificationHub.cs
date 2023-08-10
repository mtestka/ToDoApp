using System;
using Microsoft.AspNetCore.SignalR;
using ToDoApp.Entities.Models;

namespace ToDoApp.Services.Notifications
{
	public class NotificationHub:Hub
	{
        /// <summary>
        /// Send notification to all Clients.
        /// </summary>
        /// <param name="notification">Notification to be sent to all Clients.</param>
        /// <returns></returns>
        public async Task SendNotification(Notification notification)
        {
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
	}
}

