using System;
using Ninject;
using ShopManager.Data;

namespace ShopManager.Implement.Cars
{
    internal sealed class CarFactory : ICarFactory
    {
        private readonly IKernel _kernel;

        public CarFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CarEntity Build()
        {
            return _kernel.Get<CarEntity>();
        }

        public CarEntity BuildCarWithAge(int age)
        {
            CarEntity entity = Build();
            entity.Year = DateTime.Now.Year - age;

            return entity;
        }
    }
}