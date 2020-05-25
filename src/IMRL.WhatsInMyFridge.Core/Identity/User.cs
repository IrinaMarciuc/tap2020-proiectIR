using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Identity
{
    public class User:IEntityBase
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Role { get; set; }
        
        public string PasswordHash { get; set; }

        public User(string Username, string Role) {
            this.Username = Username;
            this.Role = Role;
        }
        public User()
        {
        
        }
    }
}
