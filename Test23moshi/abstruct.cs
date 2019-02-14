using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test23moshi
{
    //在软件系统中，经常面临着"一系统相互依赖的对象"的创建工作：同时，由于需求的变化，往往存在更多系列对象的创建工作。
    //如何应对这种变化？如何绕过常规的对象创建方法（new),提供一种"封装机制"来避免客户程序和这种"多系列具体对象创建工作"
    //的紧耦合？

    //解决的问题：客户要定  不同工厂里的不同多款产品
    //中心思想：创建3个抽象类， 1工厂包含2个产品， 客户来组装3个抽象类（即指定工厂和工厂中产品），
    //可变化的是一个抽象父两个抽象创建方法（两个子类），两个抽象子类抽象方法互相调用，使两者有了联系
    abstract class AbstractFactory //1.工厂用抽象类来变化
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA // 2. 工厂中 产品A用抽象类变化
    {
        public abstract void Interact(AbstractProductB b); // 与产品B有联系, 开始生产A产品
    }


    abstract class AbstractProductB  // 3. 工厂中 产品B用抽象类变化
    {
        public abstract void Interact(AbstractProductA a);// 与产品A有联系 , 开始生产B产品
    }




    class Client  //客户可以指定工厂和工厂中的产品清单
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;
        public Client(AbstractFactory factory)
        {
            AbstractProductA = factory.CreateProductA();
            AbstractProductB = factory.CreateProductB();
        }
        public void Run() 
        {
            AbstractProductB.Interact(AbstractProductA);
            AbstractProductA.Interact(AbstractProductB);
        }
    }


    class ConcreteFactory1 : AbstractFactory  //工厂可以变化，工厂1
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }


    class ConcreteFactory2 : AbstractFactory  //工厂可以变化，工厂2
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProdcutA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }


    class ProductA1 : AbstractProductA  // 产品可变化
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }


    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }


    class ProdcutA2 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }


    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }


}
