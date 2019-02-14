using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{

    //动机：      访问者模式(Visitor Pattern)
    //在软件构建过程中，由于需求的改变，某些类层次结构中常常需要增加新的行为(方法),如果直接在基类中做这样的更改，将会给子类带来很繁重的变更负担，甚至破坏原有设计。
    //如何在不更改类层次结构的前提下，在运行时根据需要透明地为类层次结构上的各个类动态添加新的操作，从而避免上述问题？
    //适用性：
    //1.一个对象结构包含很多类对象，它们有不同的接口，而你想对这些对象实施一些依赖于其具体类的操作。
    //2.需要对一个对象结构中的对象进行很多不同的并且不相关的操作，而你想避免让这些操作"污染"这些对象的类。Visitor使得你可以将相关的操作集中起来定义在一个类中。当该对象结构被很多应用共享时，用Visitor模式让每个应用仅包含需要用到的操作。
    //3.定义对象结构的类很少改变，但经常需要在结构上定义新的操作。改变对象结构类需要重定义对所有访问者的接口，这可能需要很大的代价。如果对象结构类经常改变，那么可能还是在这些类中定义这些操作较好。


    #region Visitor
    interface IVisitor  //1个接口 ， 2个接口实现类，对抽象员工类的操作
    {
        void Visit(Element element);
    }

    // "ConcreteVisitor1"

    class IncomeVisitor : IVisitor // 对员工的收入操作
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Trace.WriteLine(string.Format("{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name, employee.Income));
        }
    }

    // "ConcreteVisitor2"

    class VacationVisitor : IVisitor   // 对员工的假期操作
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            Trace.WriteLine(string.Format("{0} {1}'s new vacation days: {2}", employee.GetType().Name, employee.Name, employee.VacationDays));
        }
    }

    #endregion"Visitor"


    #region Element

    abstract class Element  //员工实现的抽象方法
    {
        public abstract void Accept(IVisitor visitor);
    }

    // "ConcreteElement"

    class Employee : Element   //抽象实现类
    {
        string name;
        double income;
        int vacationDays;

        // Constructor
        public Employee(string name, double income,
          int vacationDays)
        {
            this.name = name;
            this.income = income;
            this.vacationDays = vacationDays;
        }

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        public int VacationDays
        {
            get { return vacationDays; }
            set { vacationDays = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    #region 3员工
    class Clerk : Employee
    {
        // Constructor
        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director123 : Employee
    {
        // Constructor
        public Director123()
            : base("Elly", 35000.0, 16)
        {
        }
    }

    class President123 : Employee
    {
        // Constructor
        public President123()
            : base("Dick", 45000.0, 21)
        {
        }
    }


    #endregion


    // "Element"



    // "ObjectStructure"

    class Employees
    {
        private ArrayList employees = new ArrayList();

        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in employees)
            {
                e.Accept(visitor);
            }
            Trace.WriteLine("--------------");
        }
    }

    #endregion
}
