using Microsoft.AspNetCore.Authorization;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Authorization.Contents
{
    public class ContentAuthorizationRequirement : IAuthorizationRequirement
    {
        public bool AllowWriter { get; set; }
        public bool AllowEditors { get; set; }
    }





}
