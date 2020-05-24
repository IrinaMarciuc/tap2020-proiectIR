using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

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
            using (var scope = new TransactionScope())
            {
                dataContext.SaveChanges();
                scope.Complete();
            }   
        }
    }
}
