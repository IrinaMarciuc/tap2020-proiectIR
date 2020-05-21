using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Identity
{
    public class User:IEntityBase
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public User(string Username, string Email, string PasswordHash) {
            this.Username = Username;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }
    }
}
