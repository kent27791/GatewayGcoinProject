using Framework.Infrastructure.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace Framework.Infrastructure.Core.Data
{
    public interface IRepository<TContext, TEntity, TKey>
        where TEntity : IBaseEntityWithTypeId<TKey>
        where TContext : class
    {
        IQueryable<TEntity> Query();

        TEntity Find(TKey key);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey key);

        void Delete(TEntity entity);

        IQueryable<TEntity> FromSql(RawSqlString sql, params object[] parameters);

        IDbConnection GetDbConnection();

    }
}
