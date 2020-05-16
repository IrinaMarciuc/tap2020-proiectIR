using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
    }
}
