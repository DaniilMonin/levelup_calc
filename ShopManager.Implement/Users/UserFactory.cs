using Ninject;
using ShopManager.Data;
using ShopManager.Implement.Engines;

namespace ShopManager.Implement.Users
{
    internal sealed class UserFactory : IUserFactory
    {
        private readonly IKernel _kernel;

        public UserFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public User Build()
        {
            return _kernel.Get<User>();
        }
    }
}