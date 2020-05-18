using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WhatsInMyFridgeContext dataContext;
        public UnitOfWork(WhatsInMyFridgeContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Commit()
        {
            dataContext.SaveChanges();
        }
    }
}
