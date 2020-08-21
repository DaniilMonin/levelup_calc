using System.Collections.Generic;
using Ninject;
using ShopManager.Core.Generic;
using ShopManager.Data;

namespace ShopManager.Implement.Engines
{
    internal sealed class EngineRepository : EntityRepository<EngineEntity>, IEngineRepository
    {
        private readonly IEngineFactory _factory;

        [Inject]
        public EngineRepository(IEngineFactory factory/*, IErrorManager errorManager*/) : base(factory/*, errorManager*/)
        {
            _factory = factory;

        }


        public override IReadOnlyList<EngineEntity> Get()
        {
            return new List<EngineEntity>()
            {
                new EngineEntity(),
                new EngineEntity(),
                new EngineEntity(),
            };
        }

        public override void Update(EngineEntity entity)
        {
            //Dictionary<int,int>
        }

        public override void Delete(int id)
        {

        }
    }
}