using System;
using System.Collections.Generic;
using System.Text;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using IMRL.WhatsInMyFridge.Core;
using System.Linq;

namespace IMRL.WhatsInMyFridge.DataAccess.SqlServer.Repositories
{
    public class DataRepository : IDataRepository
    {
        void IDataRepository.Delete<TEntity>(TEntity entityId)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IDataRepository.Query<TEntity>()
        {
            throw new NotImplementedException();
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
