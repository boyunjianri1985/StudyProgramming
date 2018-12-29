using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
    public interface IObserverAccount
    {
        void Update(BankAccount ba);
    }



    //public class BankAccount
    //{
    //    IObserverAccount emailer;        //依赖于接口
    //    IObserverAccount phoneNumber;    //依赖于接口

    //    private double _money;

    //    public IObserverAccount Emailer
    //    {
    //        get { return emailer; }
    //        set { this.emailer = value; }
    //    }
    //    public IObserverAccount PhoneNumber
    //    {
    //        get { return phoneNumber; }
    //        set { this.phoneNumber = value; }
    //    }
    //    public double Money
    //    {
    //        get { return _money; }
    //        set { this._money = value; }
    //    }

    //    public void WithDraw()
    //    {
    //        emailer.Update(this);
    //        phoneNumber.Update(this);
    //    }

    //}


    public class Emailer : IObserverAccount
    {
        private string _emailer;
        public Emailer(string emailer)
        {
            this._emailer = emailer;
        }
        public void Update(BankAccount ba)
        {
            //..
            Trace.WriteLine(string.Format("Notified : Emailer is {0} You withdraw  {1:C} ", _emailer, ba.Money));
        }
    }





    public class Mobile : IObserverAccount
    {
        private long _phoneNumber;
        public Mobile(long phoneNumber)
        {
            this._phoneNumber = phoneNumber;
        }
        public void Update(BankAccount ba)
        {
            Trace.WriteLine(string.Format("Notified :Phone number is {0} You withdraw  {1:C} ", _phoneNumber, ba.Money));
        }
    }



    public class BankAccount
    {
        private List<IObserverAccount> Observers = new List<IObserverAccount>();


        private double _money;

        public double Money
        {
            get { return _money; }
            set { this._money = value; }
        }

        public void WithDraw()
        {
            foreach (IObserverAccount ob in Observers)
            {
                ob.Update(this);

            }
        }
        public void AddObserver(IObserverAccount observer)
        {
            Observers.Add(observer);
        }
        public void RemoverObserver(IObserverAccount observer)
        {
            Observers.Remove(observer);
        }

    }





}
