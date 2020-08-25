namespace ShopManager.Core.Management
{
    public interface IServiceRootProvider
    {
        void AsSingleton<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction;

        /// IEntityFactory<CarEntity> -> ICarEntityFactory -> CarEntityFactory
        void AsSingleton<TAbstraction, TImplementation, TImplementation2>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
            where TImplementation2 : class, TImplementation;

        void AsTransient<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction;


        void Start();
    }
}