using Ninject;
using ShopManager.Implement.Users;

namespace MyShopWebService.Composition
{
    public sealed class CompositionRoot
    {
        private IUserManager _userManager;

        public CompositionRoot()
        {
            IKernel kernel = new StandardKernel();

            ShopManager.Core.Bootstrapper.PrepairKernel(kernel);
            ShopManager.Data.Db.Bootstrapper.PrepairKernel(kernel);
            ShopManager.Implement.Bootstrapper.PrepairKernel(kernel);

            _userManager = kernel.Get<IUserManager>();
        }


        public IUserManager UserManager => _userManager;
    }
}