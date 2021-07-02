﻿
namespace TrashMob.Shared.Engine
{
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;
    using TrashMob.Shared.Persistence;

    public class EventSummaryHostReminderNotifier : NotificationEngineBase, INotificationEngine
    {
        protected override NotificationTypeEnum NotificationType => NotificationTypeEnum.EventSummaryHostReminder;

        protected override int NumberOfHoursInWindow => -4;

        protected override string EmailSubject => "Upcoming TrashMob.eco events in your area today!";

        public EventSummaryHostReminderNotifier(IEventRepository eventRepository, 
                                                IUserRepository userRepository, 
                                                IEventAttendeeRepository eventAttendeeRepository,
                                                IUserNotificationRepository userNotificationRepository,
                                                IUserNotificationPreferenceRepository userNotificationPreferenceRepository,
                                                IEmailSender emailSender,
                                                IMapRepository mapRepository,
                                                ILogger logger) :
            base(eventRepository, userRepository, eventAttendeeRepository, userNotificationRepository, userNotificationPreferenceRepository, emailSender, mapRepository, logger)
        {
        }


        public Task GenerateNotificationsAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Generating Notifications for {0}", NotificationType);
            return Task.CompletedTask;
        }
    }
}