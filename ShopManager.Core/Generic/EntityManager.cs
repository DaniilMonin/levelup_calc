using System.Collections.Generic;
using System.Linq;
using ShopManager.Data;

namespace ShopManager.Core.Generic
{
    public class EntityManager<TEntity> : IEntityManager<TEntity>
        where TEntity : Entity
    {
        private readonly IEntityRepository<TEntity> _repository;
        private IReadOnlyList<TEntity> _index;

        protected EntityManager(IEntityRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<TEntity> Entities
        {
            get => _index;
            private set => _index = value;
        }

        public void Refresh()
        {
            Entities = _repository.Get();
        }

        public IReadOnlyList<TEntity> GetAllEntitiesWhereEmptyNames()
        {
            return _index.Where(x => string.IsNullOrWhiteSpace(x.DisplayName)).ToList();
        }

    }
}