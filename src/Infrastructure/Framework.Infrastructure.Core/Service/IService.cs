using Framework.Infrastructure.Common.DataTable;
using Framework.Infrastructure.Core.Data;
using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Infrastructure.Core.Service
{
    public interface IService<TContext, TEntity, TKey>
        where TEntity : IBaseEntityWithTypeId<TKey>
        where TContext : class
    {
        IRepository<TContext, TEntity, TKey> Repository { get; }

        TEntity Find(TKey key);

        IEnumerable<TEntity> FindAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey key);

        void Delete(TEntity entity);

        DataTableResponse<UEntity> DataTablePaging<UEntity>(IQueryable<TEntity> source, DataTableRequest request);

    }
}
