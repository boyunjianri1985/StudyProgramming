using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
//对象拥有不同的状态，往往会行使不同的行为...
//动机：
//在软件构建过程中，某些对象的状态如果改变以及其行为也会随之而发生变化，比如文档处于只读状态，其支持的行为和读写状态支持的行为就可能完全不同。
//如何在运行时根据对象的状态来透明更改对象的行为？而不会为对象操作和状态转化之间引入紧耦合？
//意图：
//允许一个对象在其内部状态改变时改变它的行为。从而使对象看起来似乎修改了其行为。  ------《设计模式》GOF
//    
    
   
  // "State"

  abstract class State
  {
    protected Account account;     //Account包含State，是为了使用状态， State包含Account 是为了记录当前的青蛙，好修改你状态account.State = new SilverState(this);
    protected double balance;

    protected double interest;
    protected double lowerLimit;
    protected double upperLimit;

    // Properties
    public Account Account
    {
      get{ return account; }
      set{ account = value; }
    }

    public double Balance
    {
      get{ return balance; }
      set{ balance = value; }
    }

    public abstract void Deposit(double amount);  //不同的状态有不同的行为
    public abstract void Withdraw(double amount);
    public abstract void PayInterest();
  }

  // "ConcreteState"
  // Account is overdrawn

  class RedState : State
  {
    double serviceFee;

    // Constructor
    public RedState(State state)
    {
      this.balance = state.Balance;
      this.account = state.Account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = -100.0;
      upperLimit = 0.0;
      serviceFee = 15.00;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      amount = amount - serviceFee;
      Trace.WriteLine(string.Format("No funds available for withdrawal!"));
    }

    public override void PayInterest()
    {
      // No interest is paid
    }

    private void StateChangeCheck()  // 一条青蛙 可以 自己变换状态。
    {
      if (balance > upperLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }

  // "ConcreteState"

  // Silver is non-interest bearing state

  class SilverState : State
  {
    // Overloaded constructors

    public SilverState(State state) :
      this( state.Balance, state.Account)
    {  
    }

    public SilverState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = 0.0;
      upperLimit = 1000.0;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }

    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }

    private void StateChangeCheck()
    {
      if (balance < lowerLimit)
      {
        account.State = new RedState(this);
      }
      else if (balance > upperLimit)
      {
        account.State = new GoldState(this);
      }
    }
  }

  // "ConcreteState"

  // Interest bearing state

  class GoldState : State
  {
    // Overloaded constructors
    public GoldState(State state)
      : this(state.Balance,state.Account)
    {  
    }

    public GoldState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a database
      interest = 0.05;
      lowerLimit = 1000.0;
      upperLimit = 10000000.0;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }

    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }

    private void StateChangeCheck()
    {
      if (balance < 0.0)
      {
        account.State = new RedState(this);
      }
      else if (balance < lowerLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }

  // "Context"

    class Account      /// 这就是哪只青蛙
    {
        private State state;   //可以有不同的状态777  ，  State 中包含并可修改 Account 。  Account中包含并可修改 State ，State根据钱数量的多少new 不同的 抽象子类 State,,Account行为也是调用State行为而变化
        private string owner;

        // Constructor
        public Account(string owner)
        {
            // New accounts are 'Silver' by default
            this.owner = owner;
            state = new SilverState(0.0, this);
        }

        // Properties
        public double Balance
        {
            get { return state.Balance; }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public void Deposit(double amount)
        {
            state.Deposit(amount);
            Trace.WriteLine(string.Format("Deposited {0:C} --- ", amount));
            Trace.WriteLine(string.Format(" Balance = {0:C}", this.Balance));
            Trace.WriteLine(string.Format(" Status = {0}\n", this.State.GetType().Name));
            Trace.WriteLine(string.Format(""));
        }

        public void Withdraw(double amount)
        {
            state.Withdraw(amount);
            Trace.WriteLine(string.Format("Withdrew {0:C} --- ", amount));
            Trace.WriteLine(string.Format(" Balance = {0:C}", this.Balance));
            Trace.WriteLine(string.Format(" Status = {0}\n",
                this.State.GetType().Name));
        }

        public void PayInterest()
        {
            state.PayInterest();
            Trace.WriteLine(string.Format("Interest Paid --- "));
            Trace.WriteLine(string.Format(" Balance = {0:C}", this.Balance));
            Trace.WriteLine(string.Format(" Status = {0}\n",
                this.State.GetType().Name));
        }
    }
}
