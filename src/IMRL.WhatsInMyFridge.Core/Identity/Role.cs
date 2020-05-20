using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Identity
{
    public class Role:IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
