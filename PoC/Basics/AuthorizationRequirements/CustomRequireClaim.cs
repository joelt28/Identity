﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.AuthorizationRequirements
{
    public class CustomRequireClaim : IAuthorizationRequirement
    {
        public CustomRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }

        public string ClaimType { get; private set; }
    }

    public class CustomRequireClaimHandler : AuthorizationHandler<CustomRequireClaim>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequireClaim requirement)
        {
            var hasClaim = context.User.Claims.Any(o => o.Type == requirement.ClaimType);
            if (hasClaim)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
