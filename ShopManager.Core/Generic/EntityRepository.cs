using System.Collections.Generic;
using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IEntityFactory<TEntity> _factory;
        private readonly IErrorManager _errorManager;

        protected EntityRepository(IEntityFactory<TEntity> factory/*, IErrorManager errorManager*/)
        {
            _factory = factory;
            //_errorManager = errorManager;
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