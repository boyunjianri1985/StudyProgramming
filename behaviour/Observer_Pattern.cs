using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
    
   // 观 察者定义了对象间一对多的关系，当一个对象的状态变化时，所有依赖它的对象都得到通知并且自动地更新。在ATM取款，当取款成功后，以手机、邮件等方式进行通知。
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
        public void Update(BankAccount ba) // 一个小类可以放入一个大类，可以修改（也可以使用）其属性、字段
        {
            Trace.WriteLine(string.Format("Notified :Phone number is {0} You withdraw  {1:C} ", _phoneNumber, ba.Money));
        }
    }



    public class BankAccount //将观察者添加到列表中
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
