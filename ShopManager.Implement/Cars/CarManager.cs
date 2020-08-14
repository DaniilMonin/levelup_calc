using ShopManager.Core.Generic;
using ShopManager.Data;

namespace ShopManager.Implement.Cars
{
    internal sealed class CarManager : EntityManager<CarEntity>, ICarManager
    {
        public CarManager(IEntityRepository<CarEntity> repository) : base(repository)
        {
        }
    }
}