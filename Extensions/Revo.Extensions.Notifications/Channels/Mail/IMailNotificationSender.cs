﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revo.Extensions.Notifications.Channels.Mail
{
    public interface IMailNotificationSender
    {
        Task SendMessages(IReadOnlyCollection<SerializableMailMessage> messages);
    }
}