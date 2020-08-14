using System.Collections.Generic;
using ShopManager.Core.Generic;
using ShopManager.Data;

namespace ShopManager.Implement.Cars
{
    internal sealed class CarRepository : EntityRepository<CarEntity>, ICarRepository
    {
        private readonly ICarFactory _factory;

        public CarRepository(ICarFactory factory/*, IErrorManager errorManager*/) : base(factory/*, errorManager*/)
        {
            _factory = factory;

        }


        public override IReadOnlyList<CarEntity> Get()
        {
            return new List<CarEntity>()
            {
                new CarEntity(),
                new CarEntity(),
                new CarEntity(),
            };
        }

        public override void Update(CarEntity entity)
        {
            
        }

        public override void Delete(int id)
        {
            
        }
    }
}
