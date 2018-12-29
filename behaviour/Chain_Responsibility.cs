using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
    //动机(Motivate)：职责链模式(Chain of Responsibility Pattern)
//在软件构建过程中，一个请求可能被多个对象处理，但是每个请求在运行时只能有一个接受者，如果显示指定，将必不可少地带来请求发送者与接受者的紧耦合。
//如何使请求的发送者不需要指定具体的接受者？让请求的接受者自己在运行时决定来处理请求，从而使两者解耦。

    public abstract class Approver
    {
        protected Approver successor;  //包含自己的抽象类，可以  建出很多 层楼
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);

    }

    //ConcreteHandler
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
         {
             if (purchase.Amount < 10000.0)
             {
                 Trace.WriteLine(string.Format("{0} approved request# {1}", this.GetType().Name, purchase.Number));

             }
             else if(successor !=null)
             {
                 successor.ProcessRequest(purchase);
             }
         }
    }
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
         {
             if (purchase.Amount < 25000.0)
             {
                 Trace.WriteLine(string.Format("{0} approved request# {1}", this.GetType().Name, purchase.Number));

             }
             else if (successor != null)
             {
                 successor.ProcessRequest(purchase);
             }
         }
    }



    public class PresidentEx : Approver
    {
        
        public override void ProcessRequest(Purchase purchase)
         {
             if (purchase.Amount < 100000.0)
             {
                 Trace.WriteLine(string.Format("{0} approved request# {1}", this.GetType().Name,
                     purchase.Number.ToString()));

             }
             else
             {
                 Trace.WriteLine(string.Format("Request! {0} requires an executive meeting!", purchase.Number.ToString()));
             }
         }
    }



    //Request details
   public class Purchase
    {
        private int number;
        private double amount;
        private string purpose;

        //Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this.number = number;
            this.amount = amount;
            this.purpose = purpose;
        }
        //Properties
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }






}
