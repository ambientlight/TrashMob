﻿namespace TrashMob.Shared.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrashMob.Shared.Models;

    public class PartnerLocationRepository : IPartnerLocationRepository
    {
        private readonly MobDbContext mobDbContext;

        public PartnerLocationRepository(MobDbContext mobDbContext)
        {
            this.mobDbContext = mobDbContext;
        }


        public async Task AddPartnerLocation(PartnerLocation partnerLocation)
        {
            partnerLocation.CreatedDate = DateTimeOffset.UtcNow;
            partnerLocation.LastUpdatedByUserId = partnerLocation.CreatedByUserId;
            partnerLocation.LastUpdatedDate = DateTimeOffset.UtcNow;

            mobDbContext.PartnerLocations.Add(partnerLocation);

            await mobDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<PartnerLocation> GetPartnerLocations()
        {
            return mobDbContext.PartnerLocations.AsQueryable();
        }

        // Update the records of a particular Partner Location
        public async Task<PartnerLocation> UpdatePartnerLocation(PartnerLocation partnerLocation)
        {
            mobDbContext.Entry(partnerLocation).State = EntityState.Modified;
            partnerLocation.LastUpdatedDate = DateTimeOffset.UtcNow;
            await mobDbContext.SaveChangesAsync();

            return partnerLocation;
        }

        public async Task<int> DeletePartnerLocation(Guid partnerLocationId)
        {
            var partnerLocation = await mobDbContext.PartnerLocations.FindAsync(partnerLocationId).ConfigureAwait(false);
            mobDbContext.PartnerLocations.Remove(partnerLocation);

            // Save the changes
            return await mobDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
