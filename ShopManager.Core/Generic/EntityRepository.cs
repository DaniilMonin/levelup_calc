using System.Collections.Generic;
using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IEntityFactory<TEntity> _factory;

        protected EntityRepository(IEntityFactory<TEntity> factory)
        {
            _factory = factory;
        }

        public TEntity Create()
        {
            return _factory.Build();
        }

        public abstract IReadOnlyList<TEntity> Get();
        public abstract void Update(TEntity entity);
        public abstract void Delete(int id);
    }
}