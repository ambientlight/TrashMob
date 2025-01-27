﻿namespace TrashMob.Shared.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrashMob.Shared.Models;

    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly MobDbContext mobDbContext;

        public UserNotificationRepository(MobDbContext mobDbContext)
        {
            this.mobDbContext = mobDbContext;
        }

        public async Task<IEnumerable<UserNotification>> GetUserNotifications(Guid userId, Guid eventId)
        {
            return await mobDbContext.UserNotifications.Where(un => un.EventId == eventId && un.UserId == userId)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<UserNotification> AddUserNotification(UserNotification userNotification)
        {
            userNotification.Id = Guid.NewGuid();
            userNotification.SentDate = DateTimeOffset.UtcNow;
            mobDbContext.UserNotifications.Add(userNotification);
            await mobDbContext.SaveChangesAsync().ConfigureAwait(false);
            return userNotification;
        }
    }
}
