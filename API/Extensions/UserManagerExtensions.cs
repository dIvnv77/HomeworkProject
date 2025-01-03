﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByEmailFromClaimsPrincipalAsync(
           this UserManager<ApplicationUser> userManager,
           ClaimsPrincipal user)
        {
            return await userManager.Users
                .FirstOrDefaultAsync(u => u.Email == user.FindFirstValue(ClaimTypes.Email));
        }
    }
}
