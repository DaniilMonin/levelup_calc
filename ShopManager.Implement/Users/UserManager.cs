using ShopManager.Core.Generic;
using ShopManager.Data;
using ShopManager.Implement.Engines;

namespace ShopManager.Implement.Users
{
    public sealed class UserManager : EntityManager<User>, IUserManager
    {
        public UserManager(IEntityRepository<User> repository) : base(repository)
        {
        }
    }
}