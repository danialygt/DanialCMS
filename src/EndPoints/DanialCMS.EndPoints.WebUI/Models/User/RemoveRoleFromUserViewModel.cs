using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.User
{
    public class RemoveRoleFromUserViewModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
