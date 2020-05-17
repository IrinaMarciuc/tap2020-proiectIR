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
        private readonly WhatsInMyFridgeContext dataContext;
        public DataRepository(WhatsInMyFridgeContext dataContext)
        {
            this.dataContext = dataContext;
        }
        IQueryable<TEntity> IDataRepository.Query<TEntity>()
        {
            return dataContext.Set<TEntity>();
        }
        void IDataRepository.Delete<TEntity>(TEntity entity)
        {
            var dbEntity = dataContext.Set<TEntity>()
                .SingleOrDefault(e => e.Id == entity.Id);
            if (dbEntity != null)
            {
                dataContext.Remove(dbEntity);
            }
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            dataContext.Add(entity);
        }

        

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            dataContext.Update(entity);
        }
    }
}
