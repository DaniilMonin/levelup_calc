using System.Collections.Generic;
using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public interface IEntityManager<TEntity> : IEntityManager
        where TEntity : Entity
    {
        IReadOnlyList<TEntity> GetAllEntitiesWhereEmptyNames();
    }
}