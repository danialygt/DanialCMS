using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Authorization.Contents
{

    public class ContentAuthorizationHandler : AuthorizationHandler<ContentAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ContentAuthorizationRequirement requirement)
        {
            DtoUpdateContent doc = context.Resource as DtoUpdateContent;

            string user = context.User.Identity.Name;
            StringComparison compare = StringComparison.OrdinalIgnoreCase;
            if (doc != null && user != null &&
                requirement.AllowWriter && doc?.WriterName.Equals(user, compare) != null ||
                requirement.AllowEditors && doc?.Editors.Any(e =>
                            e.Name.Equals(user, compare)) != null)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }





}
