using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
//动机：
//在软件构建过程中，某些对象使用的算法可能多种多样，经常改变，如果将这些算法都编码对象中，将会使对象变得异常复杂;而且有时候支持不使用的算法也是一个性能负担。
//如何在运行时根据需要透明地更改对象的算法？将算法与对象本身解耦，从而避免上述问题？



    //Stategy  表达抽象算法
    abstract class SortStrategy
    {
        public abstract void Sort(ArrayList list);
    }

    //ConcreteStrategy
    class ShellSort : SortStrategy
    {
        public override void Sort(System.Collections.ArrayList list)
        {
            list.Sort(); //no-implement
            Trace.WriteLine("ShellSorted List");

        }
    }


    //ConcreteStrategy
    class MergeSort : SortStrategy
    {
        public override void Sort(System.Collections.ArrayList list)
        {
            list.Sort(); //no-implement
            Trace.WriteLine("MergeSort List ");
        }
    }


    //ConcreteStrategy
    class QuickSort : SortStrategy
    {
        public override void Sort(System.Collections.ArrayList list)
        {
            list.Sort(); //Default is Quicksort
            Trace.WriteLine("QuickSorted List");
        }
    }



    //Context
    class SortdList
    {
        private ArrayList list = new ArrayList();
        private SortStrategy sortstrategy;  //对象组合
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }
        public void Add(string name)
        {
            list.Add(name);
        }
        public void Sort()
        {
            sortstrategy.Sort(list);
            //Display results 
            foreach (string name in list)
            {
                Trace.WriteLine(" " + name);
            }
            Trace.WriteLine("");
        }
    }



}
