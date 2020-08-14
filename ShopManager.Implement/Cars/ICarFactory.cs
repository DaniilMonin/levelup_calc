using ShopManager.Core.Generic;
using ShopManager.Data;

namespace ShopManager.Implement.Cars
{
    public interface ICarFactory : IEntityFactory<CarEntity>
    {
        CarEntity BuildCarWithAge(int age);
    }
}