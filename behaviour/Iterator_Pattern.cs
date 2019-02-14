using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
    #region 枚举器

    public class ConList : IEnumerable
    {
         int[] list;
        public ConList()
        {
            list = new int[] { 1, 2, 3, 4, 5 };
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                 yield return list[i];
            }
           
        }
    }


    #endregion






    public class ConcreteList : IList
    {
        int[] list;

        public ConcreteList()
        {
            list = new int[] { 1, 2, 3, 4, 5 };
        }

        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return list.Length; }
        }

        public int GetElement(int index)
        {
            return list[index];
        }
    }

    public class ConcreteIterator : IIterator
    {
        private ConcreteList list;

        private int index;

        public ConcreteIterator(ConcreteList list)
        {
            this.list = list;

            index = 0;
        }

        public bool MoveNext()
        {
            if (index < list.Length)

                return true;

            else

                return false;
        }

        public Object CurrentItem()
        {
            return list.GetElement(index);
        }

        public void First()
        {
            index = 0;
        }

        public void Next()
        {
            if (index < list.Length)
            {
                index++;
            }
        }
    }

    public interface IList
    {
        IIterator GetIterator();
    }

    public interface IIterator
    {
        bool MoveNext();

        Object CurrentItem();

        void First();

        void Next();
    }

}
