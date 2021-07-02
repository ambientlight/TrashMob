namespace TrashMob.Shared.Tests
{
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;
    using TrashMob.Shared.Engine;
    using TrashMob.Shared.Persistence;
    using Xunit;

    public class UpcomingEventAttendingTodayNotifierTests : NotifierTestsBase
    {
        protected override NotificationTypeEnum NotificationType => NotificationTypeEnum.UpcomingEventAttendingToday;

        [Fact]
        public async Task GenerateNotificationsAsync_WithNoDataAvailable_Succeeds()
        {
            // Arrange
            var engine = new UpcomingEventAttendingTodayNotifier(EventRepository.Object, UserRepository.Object, EventAttendeeRepository.Object, UserNotificationRepository.Object, UserNotificationPreferenceRepository.Object, EmailSender.Object, MapRepository.Object, Logger.Object);

            // Act
            await engine.GenerateNotificationsAsync().ConfigureAwait(false);

            // Assert
            EmailSender.Verify(_ => _.SendEmailAsync(It.IsAny<Email>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public void GetEmailTemplate_Succeeds()
        {
            // Arrange
            var engine = new UpcomingEventAttendingTodayNotifier(EventRepository.Object, UserRepository.Object, EventAttendeeRepository.Object, UserNotificationRepository.Object, UserNotificationPreferenceRepository.Object, EmailSender.Object, MapRepository.Object, Logger.Object);

            // Act
            var template = engine.GetEmailTemplate();

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(template));
            Assert.Contains("You're attending a TrashMob.eco event today!", template);
        }
    }
}
