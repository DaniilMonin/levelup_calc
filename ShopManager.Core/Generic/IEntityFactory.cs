using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public interface IEntityFactory<TEntity>
        where TEntity : Entity
    {
        TEntity Build();
    }
}