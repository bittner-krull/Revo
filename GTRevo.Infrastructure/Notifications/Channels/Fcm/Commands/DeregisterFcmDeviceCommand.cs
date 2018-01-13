﻿using System.ComponentModel.DataAnnotations;
using GTRevo.Core.Commands;
using GTRevo.Infrastructure.Security.Commands;

namespace GTRevo.Infrastructure.Notifications.Channels.Fcm.Commands
{
    [AuthorizePermissions(Permissions.DeregisterDeviceToken)]
    public class DeregisterFcmDeviceCommand : ICommand
    {
        [Required]
        public string RegistrationId { get; set; }

        [Required]
        public string AppId { get; set; }
    }
}