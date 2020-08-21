using Ninject;
using ShopManager.Core;
using ShopManager.Core.Generic;

namespace ShopManager.Data.Db
{
    public static class Bootstrapper
    {
        public static void PrepairKernel(IKernel kernel)
        {
            kernel.Bind<IEntityRepository<User>>().To<DatabaseEntityRepository<User>>().InSingletonScope();
            kernel.Bind<IEntityRepository<Item>>().To<DatabaseEntityRepository<Item>>().InSingletonScope();
        }
    }
}