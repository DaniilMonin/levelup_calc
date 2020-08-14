using Ninject;

namespace ShopManager.Core
{
    public static class Bootstrapper
    {
        public static void PrepairKernel(IKernel kernel)
        {
            kernel.Bind<ManagementService>().ToSelf().InSingletonScope();
        }
    }
}