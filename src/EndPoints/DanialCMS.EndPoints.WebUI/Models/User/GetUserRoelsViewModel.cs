using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.User
{
    public class GetUserRoelsViewModel
    {
        public List<string> RolesName { get; set; } =
             new List<string>();
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}
