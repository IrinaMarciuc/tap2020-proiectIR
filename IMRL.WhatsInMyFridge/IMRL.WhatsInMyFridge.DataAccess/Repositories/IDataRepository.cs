using IMRL.WhatsInMyFridge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IMRL.WhatsInMyFridge.DataAccess.Repositories
{
      public interface IDataRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase;

        void Insert<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntityBase;

        void Delete<TEntity>(TEntity entityId) where TEntity : class, IEntityBase;
    }
}
