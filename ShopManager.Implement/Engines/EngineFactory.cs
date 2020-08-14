using Ninject;
using ShopManager.Data;

namespace ShopManager.Implement.Engines
{
    internal sealed class EngineFactory : IEngineFactory
    {
        private readonly IKernel _kernel;

        public EngineFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public EngineEntity Build()
        {
            return _kernel.Get<EngineEntity>();
        }
    }
}