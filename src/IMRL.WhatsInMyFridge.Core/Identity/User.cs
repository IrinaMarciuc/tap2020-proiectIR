using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Identity
{
    class User:IEntityBase
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
