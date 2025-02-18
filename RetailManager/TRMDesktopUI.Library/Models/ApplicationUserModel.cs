using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Roles { get; set; }

        private string roleList;
        public string RoleList
        {
            get
            {
                var list = string.Join(", ", Roles.Select(x => x.Value));
                return list;
            }
        }
    }
}
