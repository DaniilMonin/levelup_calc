using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;

namespace Lesson1
{
    class Program
    {
         static void Main(string[] args)
        {






            /*object foo1 = new object();
            object foo2 = new object();

            Console.WriteLine($"Thread {Thread.CurrentThread.Name} -- START");

            Thread thread = new Thread(o =>
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name}");

                Console.WriteLine($"Thread {Thread.CurrentThread.Name} -- START");

                lock (foo1)
                {
                    int hashCode2 = foo1.GetHashCode();

                    Thread.Sleep(1000);

                    lock (foo2)
                    {
                        
                    }

                    Thread.Sleep(10000);

                    Console.WriteLine($"Thread {Thread.CurrentThread.Name} -- LOCK {hashCode2}");
                }

                Console.WriteLine($"Thread {Thread.CurrentThread.Name} -- END");
            });

            thread.Name = "Child Thread 1";


            thread.Start();

            lock (foo2)
            {
                Thread.Sleep(1000);

                int hashCode = foo2.GetHashCode();

                lock (foo1)
                {
                    
                }

                Thread.Sleep(5000);
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} -- END {hashCode}");
            }*/
        }

        /*
         *Should be in main
         *
         *
         *
         *
         *
         */

        /*
            AboutForm aboutForm = new AboutForm();
            FindAndReplaceForm findAndReplaceForm = new FindAndReplaceForm();


            aboutForm.AddId(100).AddLocale("ru_RU".RemoveSecondChar().RemoveSecondChar());

          
            List<int> jkl = new List<int>() { 1, 2, 3 };


            jkl.Where(x => x > 2).FirstOrDefault();


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
            
             */
        //Thread.
    }



    public static class BaseFormExtension
    {
        public static string RemoveSecondChar(this string text)
        {
            return text.Remove(1, 1);
        }


        public static BaseForm AddId(this BaseForm form, int id)
        {
            form.Id = id;

            return form;
        }

        public static BaseForm AddLocale(this BaseForm form, string locale)
        {
            form.CurrentLocale = locale;

            return form;
        }

    }




    public sealed class LocalizableCaptionAttribute : Attribute
    {
        private readonly string _resourceId;

        public LocalizableCaptionAttribute(string resourceId)
        {
            _resourceId = resourceId;
        }

        public string ResourceId => _resourceId;
    }

    public abstract class BaseForm
    {

        public BaseForm()
        {
            LocalizableCaptionAttribute att = this
                .GetType()
                .GetTypeInfo()
                .GetCustomAttribute<LocalizableCaptionAttribute>();

            Caption = att.ResourceId;
        }

        public int Id { get; set; }

        public string CurrentLocale { get; set; }

        public string Caption { get; private set; }
    }


    [LocalizableCaption("localizeString_1")]
    public class AboutForm : BaseForm
    {
        
    }


    [LocalizableCaption("localizeString_2")]
    public class FindAndReplaceForm : BaseForm
    {

    }



    public interface IFactory<TData>
    {
        [Obsolete("OLD CODE DETECTED")]
        TData Build();

        TData BuildWithNewId(int id);
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

        public TEntity BuildWithNewId(int id)
        {
            TEntity entity = Build();
            entity.Id = id;

            return entity;
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


    public abstract class ChainsAction
    {
        public virtual bool DoWork(int id)
        {
            return true;
        }
    }

    public class ChainsOfRespons
    {
        private readonly IReadOnlyList<ChainsAction> _chainsActions;

        public ChainsOfRespons(IReadOnlyList<ChainsAction> chainsActions)
        {
            _chainsActions = chainsActions;
        }

        public void Run(int id)
        {
            foreach (ChainsAction action in _chainsActions)
            {
                if (action.DoWork(id))
                {
                    break;
                }
            }
        }
    }


    /*public class BookFactory
    {
        public BookEntity Build()
        {
            return new BookEntity(null, null, null)
            {
                Id = 1,
            };
        }
    }*/

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