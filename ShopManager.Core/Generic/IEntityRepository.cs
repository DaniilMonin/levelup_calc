using System.Collections.Generic;
using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public interface IEntityRepository<TEntity>
        where TEntity : Entity
    {
        TEntity Create();

        IReadOnlyList<TEntity> Get();

        void Update(TEntity entity);

        void Delete(int id);
    }
}