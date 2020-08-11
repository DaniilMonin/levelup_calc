using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<object> list = new List<object>();

            
            ArrayList arrayList = new ArrayList();

            //arrayList.Add()



            /*MyList<FooItem, int> list = new MyList<FooItem, int>();

            list.Current = new FooItem();

            list.Build();*/

            /*MyList<Item> list2 = new MyList<Item>();

            list2.Current = new FooItem();*/
        }
    }

    public sealed class FooItem : Item
    {
        public override void WriteInformation()
        {
            Console.WriteLine("Foo");
        }
    }

    public abstract class Item : IItem<int>, IUniqueItem
    {
        private string _displayName;
        private int _id;

        /*public Item(string displayName)
        {

        }*/

        public string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public virtual void WriteInformation()
        {
            Console.WriteLine("Item");
        }
    }

    public interface IItem<TUniqueId>
        where TUniqueId : struct
    {
        string DisplayName { get; set; }

        TUniqueId Id { get; set; }

        void WriteInformation();
    }

    public interface IUniqueItem
    {
        int Id { get; set; }
    }

    public class MyList<TItem, TUniqueItem>
        where TItem : IItem<TUniqueItem>, IUniqueItem
        where TUniqueItem : struct
    {
        private TItem _current;

        public TItem Current
        {
            get => _current;
            set => _current = value;
        }

        public void Build()
        {
            Current.WriteInformation();
        }
    }
}