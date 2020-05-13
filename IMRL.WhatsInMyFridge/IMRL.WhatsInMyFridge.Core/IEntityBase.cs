using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core
{
    interface IEntityBase
    {
        public Guid Id { get; set; }
    }
}
