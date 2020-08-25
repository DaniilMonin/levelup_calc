using Ninject;
using ShopManager.Data;
using ShopManager.Implement;
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

            SimpleValidation foo = new SimpleValidation();
            foo.Validate(new CarEntity());
        }


        public IUserManager UserManager => _userManager;
    }
}