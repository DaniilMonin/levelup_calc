using ShopManager.Core.Generic;
using ShopManager.Data;

namespace ShopManager.Implement.Engines
{
    internal sealed class EngineManager : EntityManager<EngineEntity>, IEngineManager
    {
        public EngineManager(IEntityRepository<EngineEntity> repository) : base(repository)
        {
        }
    }
}