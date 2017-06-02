﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTRevo.Infrastructure.Notifications
{
    public class NotificationBus : INotificationBus
    {
        private readonly INotificationChannel[] notificationChannels;

        public NotificationBus(INotificationChannel[] notificationChannels)
        {
            this.notificationChannels = notificationChannels;
        }

        public async Task PushNotification(INotification notification)
        {
            IEnumerable<INotificationChannel> channels = notificationChannels
                .Where(x => x.NotificationTypes.Any(y => y.IsInstanceOfType(notification)));
            foreach (INotificationChannel channel in channels)
            {
                await channel.SendNotificationAsync(notification);
            }
        }

        public async Task PushNotifications(IEnumerable<INotification> notifications)
        {
            var notificationsByType = notifications.GroupBy(x => x.GetType());
            
            foreach (var byType in notificationsByType)
            {
                IEnumerable<INotificationChannel> channels = notificationChannels
                      .Where(x => x.NotificationTypes.Any(y => y.IsAssignableFrom(byType.Key)));
                foreach (INotificationChannel channel in channels)
                {
                    foreach (INotification notification in byType)
                    {
                        await channel.SendNotificationAsync(notification);
                    }
                }
            }
        }
    }
}
