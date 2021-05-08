﻿
namespace TrashMob.Poco
{
    using TrashMob.Models;

    public static class PocoExtensions
    {
        public static DisplayUser ToDisplayUser(this User user)
        {
            return new DisplayUser
            {
                City = user.City,
                Country = user.Country,
                GivenName = user.GivenName,
                Id = user.Id,
                MemberSince = user.MemberSince,
                Region = user.Region            
            };
        }
    }
}