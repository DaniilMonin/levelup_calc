using System;
using Ninject;
using ShopManager.Core;
using ShopManager.Implement;
using ShopManager.Implement.Cars;

namespace ShopManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This Shop Manager!");

            IKernel kernel = new StandardKernel();

            ShopManager.Core.Bootstrapper.PrepairKernel(kernel);
            ShopManager.Implement.Bootstrapper.PrepairKernel(kernel);


            ManagementService mgm = kernel.Get<ManagementService>();

            ICarManager carManager = kernel.Get<ICarManager>();

            carManager.Refresh();
            carManager.GetAllEntitiesWhereEmptyNames();
        }
    }
}
