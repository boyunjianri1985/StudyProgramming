using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
//意图：    
//在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后可以将该对象恢复到原先保存的状态
//适用性：
//1.必须保存一个对象某一个时刻的(部分)状态，这样以后需要时它才能恢复到先前的状态。
//2.如果一个用接口来让其它对象直接得到这些状态，将会暴露对象的实现细节并破坏对象的封装性。
    class Memento
    {
        private string name;
        private string phone;
        private double budget;

        //Constructor
        public Memento(string name, string phone, double budget)
        {
            this.name = name;
            this.phone = phone;
            this.budget = budget;
        }
        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public double Budget
        {
            get { return budget; }
            set { budget = value; }
        }
    }

    class ProspectMemory
    {
        private Memento memento;

        //Property
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }

    //Originator
    class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; Trace.WriteLine("Name:" + name); }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; Trace.WriteLine("Phone:" + phone); }
        }
        public double Budget
        {
            get { return Budget; }
            set { budget = value; Trace.WriteLine("Budget:" + budget); }
        }
        public Memento SaveMemento()
        {
            Trace.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }
        public void RestoreMemento(Memento memento)
        {
            Trace.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }




}
