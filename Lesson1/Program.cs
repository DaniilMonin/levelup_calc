using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();

            kernel.Bind<IInfoService>().To<V1Version>().InSingletonScope();
            kernel.Bind<ISettingsProvider>().To<ClassicSettingsProvider>().InSingletonScope();
            kernel.Bind<IBooksManager>().To<BooksManager>().InSingletonScope();
            kernel.Bind<IFirstStringsService>().To<FirstService>().InSingletonScope();

            kernel.Bind<Entity>().To<BookEntity>().InTransientScope();

            kernel.Bind<IFactory<BookEntity>>().To<EntityFactory<BookEntity>>().InSingletonScope();
            kernel.Bind<IFactory<CarEntity>>().To<EntityFactory<CarEntity>>().InSingletonScope();


            IFirstStringsService stringsService = kernel.Get<IFirstStringsService>();


            var carFactory = kernel.Get<IFactory<CarEntity>>();

            CarEntity c1 = carFactory.Build();
            CarEntity c2 = carFactory.Build();
            CarEntity c3 = carFactory.Build();
            CarEntity c4 = carFactory.Build();

            var bookFactory = kernel.Get<IFactory<BookEntity>>();

            BookEntity b1 = bookFactory.Build();
            BookEntity b2 = bookFactory.Build();
            BookEntity b3 = bookFactory.Build();
            BookEntity b4 = bookFactory.Build();
            BookEntity b5 = bookFactory.Build();

            int length = stringsService.GetStringLength();

        }
    }


    public interface IFactory<TData>
    {
        TData Build();
    }

    public sealed class EntityFactory<TEntity> : IFactory<TEntity>
        where TEntity : Entity
    {
        private readonly IKernel _kernel;

        public EntityFactory(ILogger logger, ISettingsProvider provider, IKernel kernel)
        {
            _kernel = kernel;
        }

        public TEntity Build()
        {
            return _kernel.Get<TEntity>();
        }
    }



    public abstract class Entity
    {
        private readonly ILogger _logger;
        private readonly ISettingsProvider _settingsProvider;

        protected Entity(ILogger logger, ISettingsProvider settingsProvider)
        {
            _logger = logger;
            _settingsProvider = settingsProvider;
        }

        public int Id { get; set; }
    }


    public sealed class BookEntity : Entity
    {
        public BookEntity(ILogger logger, ISettingsProvider settingsProvider) : base(logger, settingsProvider)
        {
        }
    }


    public sealed class CarEntity : Entity
    {
        public CarEntity(ILogger logger, ISettingsProvider settingsProvider) : base(logger, settingsProvider)
        {
        }
    }



    public interface IInfoService
    {
        Version GetCurrentVersion();
    }

    public sealed class V1Version : IInfoService
    {
        public Version GetCurrentVersion()
        {
            return new Version(1, 0, 0, 0);
        }
    }

    public sealed class V2Version : IInfoService
    {
        public Version GetCurrentVersion()
        {
            return new Version(2, 0, 0, 0);
        }
    }

    public sealed class V3Version : IInfoService
    {
        public Version GetCurrentVersion()
        {
            return new Version(2, 0, 0, 0);
        }
    }


    public interface IBaseManager
    {

    }

    public interface IBaseService
    {

    }

    public interface ILogger
    {
        void Log(string message);
    }

    public interface ISettingsProvider
    {
        TSetting Get<TSetting>(string settingName);
    }

    public abstract class BaseManager : IBaseManager
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly ILogger _logger;

        protected BaseManager(ISettingsProvider settingsProvider, ILogger logger)
        {
            _settingsProvider = settingsProvider;
            _logger = logger;
        }

        protected ISettingsProvider Settings => _settingsProvider;
        protected ILogger Logger => _logger;
    }

    public abstract class BaseService : IBaseService
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly ILogger _logger;

        protected BaseService(ISettingsProvider settingsProvider, ILogger logger)
        {
            _settingsProvider = settingsProvider;
            _logger = logger;
        }

        protected ISettingsProvider Settings => _settingsProvider;
        protected ILogger Logger => _logger;
    }

    internal sealed class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }

    internal sealed class ConsoleSettingsProvider : ISettingsProvider
    {
        public TSetting Get<TSetting>(string settingName)
        {
            return default(TSetting);
        }
    }

    internal sealed class ClassicSettingsProvider : ISettingsProvider
    {
        public TSetting Get<TSetting>(string settingName)
        {
            return default(TSetting);
        }
    }

    public interface IFirstStringsService : IBaseService
    {
        int GetStringLength();
    }

    internal sealed class FirstService : BaseService, IFirstStringsService
    {
        private readonly IBooksManager _stringsManager;

        public FirstService(IBooksManager stringsManager, ISettingsProvider settingsProvider, ILogger logger) : base(settingsProvider, logger)
        {
            _stringsManager = stringsManager;
        }

        public int GetStringLength()
        {
            return _stringsManager.GetNewBook().Id;
        }
    }

    public interface IBooksManager : IBaseManager
    {
        BookEntity GetNewBook();
    }

    public abstract class EntityManager<TEntity> : BaseManager
        where TEntity : Entity
    {
        private readonly IFactory<TEntity> _factory;

        protected EntityManager(IFactory<TEntity> factory, ISettingsProvider settingsProvider, ILogger logger) : base(settingsProvider, logger)
        {
            _factory = factory;
        }

        protected TEntity Build()
        {
            return _factory.Build();
        }
    }

    internal sealed class BooksManager : EntityManager<BookEntity>, IBooksManager
    {
        public BooksManager(IFactory<BookEntity> factory, ISettingsProvider settingsProvider, ILogger logger) : base(factory, settingsProvider, logger)
        {
        }

        public BookEntity GetNewBook()
        {

           BookEntity book = Build();

           book.Id = 10;

           return book;
        }
    }
   
}