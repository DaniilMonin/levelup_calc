using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using ShopManager.Core;
using ShopManager.Core.Management;
using ShopManager.Data;
using ShopManager.Data.Db.Context;
using ShopManager.Implement;
using ShopManager.Implement.Cars;
using ShopManager.Implement.Infrastructure;
using ShopManager.Implement.Users;

namespace ShopManager
{
    class Program
    {
        static async Task Main(string[] args)
        {

            ShopManagerDapperContext context = new ShopManagerDapperContext();

            //int count = await context.RunInsertAsync().ConfigureAwait(false);

            IEnumerable<ProductLiteDTO> products = await context.GetAllProducts().ConfigureAwait(false);


            IServiceRootProvider serviceRootProvider = new AutofacServiceRootProvider();

            


            Foo f = new Foo();

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
           // ShopManager.Implement.Bootstrapper.PrepairKernel(kernel);
            


            ManagementService mgm = kernel.Get<ManagementService>();

            ICarManager carManager = kernel.Get<ICarManager>();

            carManager.Refresh();
            carManager.GetAllEntitiesWhereEmptyNames();


            IUserManager userManager = kernel.Get<IUserManager>();
            userManager.Refresh();
        }


    }

    public class Bar
    {

    }

    public class Foo : FluentValidation.AbstractValidator<Bar>
    {

    }
}
