using System;
using System.Linq;
using Ninject;
using ShopManager.Core;
using ShopManager.Data;
using ShopManager.Data.Db.Context;
using ShopManager.Implement;
using ShopManager.Implement.Cars;
using ShopManager.Implement.Users;

namespace ShopManager
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbContext = new ShopManagerDatabaseContext())
            {
                /*dbContext.Add(new User() {Login = "sudo", Password = "qwerty"});

                dbContext.SaveChanges();*/


                foreach (User contextUser in dbContext.Users)
                {
                    contextUser.Login = "Root123";

                    dbContext.SaveChanges();

                    System.Console.WriteLine($"Id={contextUser.Id} with name={contextUser.Login}");


                }
            }




            Console.WriteLine("Hello World! This Shop Manager!");

            IKernel kernel = new StandardKernel();

            int genA = GC.GetGeneration(kernel);

            GC.Collect();

            int genB = GC.GetGeneration(kernel);

            ShopManager.Core.Bootstrapper.PrepairKernel(kernel);
            ShopManager.Data.Db.Bootstrapper.PrepairKernel(kernel);
            ShopManager.Implement.Bootstrapper.PrepairKernel(kernel);
            


            ManagementService mgm = kernel.Get<ManagementService>();

            ICarManager carManager = kernel.Get<ICarManager>();

            carManager.Refresh();
            carManager.GetAllEntitiesWhereEmptyNames();


            IUserManager userManager = kernel.Get<IUserManager>();
            userManager.Refresh();
        }
    }
}
