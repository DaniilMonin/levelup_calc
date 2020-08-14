using System.Collections.Generic;

namespace ShopManager.Core
{
    public sealed class ManagementService
    {
        private readonly IList<IEntityManager> _managers;

        public ManagementService(IList<IEntityManager> managers)
        {
            _managers = managers;
        }

        public void Refresh()
        {
            foreach (IEntityManager manager in _managers)
            {
                manager.Refresh();
            }
        }
    }
}