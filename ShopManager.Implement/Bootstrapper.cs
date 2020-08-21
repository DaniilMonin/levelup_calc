using Ninject;
using ShopManager.Core;
using ShopManager.Core.Generic;
using ShopManager.Data;
using ShopManager.Implement.Cars;
using ShopManager.Implement.Engines;
using ShopManager.Implement.Users;

namespace ShopManager.Implement
{
    public static class Bootstrapper
    {
        public static void PrepairKernel(IKernel kernel)
        {
            kernel.Bind<ICarFactory, IEntityFactory<CarEntity>>().To<CarFactory>().InSingletonScope();
            kernel.Bind<IEntityRepository<CarEntity>, EntityRepository<CarEntity>, ICarRepository>().To<CarRepository>().InSingletonScope();
            kernel.Bind<IEntityManager, IEntityManager<CarEntity>, EntityManager<CarEntity>, ICarManager>().To<CarManager>().InSingletonScope();


            kernel.Bind<IEngineFactory, IEntityFactory<EngineEntity>>().To<EngineFactory>().InSingletonScope();

            kernel.Bind<IEntityRepository<EngineEntity>, EntityRepository<EngineEntity>, IEngineRepository>().To<EngineRepository>().InSingletonScope();
            kernel.Bind<IEntityManager, IEntityManager<EngineEntity>, EntityManager<EngineEntity>, IEngineManager>().To<EngineManager>().InSingletonScope();

            kernel.Bind<IUserFactory, IEntityFactory<User>>().To<UserFactory>().InSingletonScope();
            kernel.Bind<IEntityManager, IEntityManager<User>, EntityManager<User>, IUserManager>().To<UserManager>().InSingletonScope();

            //RegisterEntity<CarEntity, CarFactory, CarRepository, CarManager>(kernel);
            //RegisterEntity<EngineEntity, EngineFactory, EngineRepository, EngineManager>(kernel);

            //kernel.RegisterEntity<CarEntity, ICarFactory, CarFactory, ICarRepository, CarRepository, ICarManager, CarManager>();
            //kernel.RegisterEntity<EngineEntity, EngineFactory, EngineRepository, EngineManager>();
        }
    }


    internal static class KernelExtensions
    {
        public static IKernel RegisterEntity<TEntity, TBaseEntityFactory, TEntityFactory, TBaseEntityRepository, TEntityRepository, TBaseEntityManager, TEntityManager>(
            this IKernel kernel)
            where TEntity : Entity
            
            where TBaseEntityFactory : IEntityFactory<TEntity>
            where TEntityFactory : class, TBaseEntityFactory

            where TBaseEntityRepository : IEntityRepository<TEntity>
            where TEntityRepository : class, TBaseEntityRepository

            where TBaseEntityManager : IEntityManager<TEntity>
            where TEntityManager : EntityRepository<TEntity>, TBaseEntityManager, IEntityManager
        {
            kernel.Bind<TEntityFactory, IEntityFactory<TEntity>>().To<TEntityFactory>().InSingletonScope();

            /*kernel.Bind<IEntityRepository<TEntity>, EntityRepository<TEntity>, TEntityRepository>()
                .To<TEntityRepository>().InSingletonScope();

            kernel.Bind<IEntityManager, IEntityManager<TEntity>, EntityManager<TEntity>, TEntityManager>()
                .To<TEntityManager>().InSingletonScope();*/

            return kernel;
        }
    }
}