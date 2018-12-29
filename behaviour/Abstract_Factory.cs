using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23Singleton
{
    /// <summary>
    /// 适用性：  把成员做成抽象成员来 让子类实现抽象是成员，可实现 抽象成员的多态   http://www.cnblogs.com/abcdwxc/archive/2007/08/29/874891.html
    //1.一个系统要独立于它的产品的创建、组合和表示时。
    //2.一个系统要由多个产品系统中的一个来配置时。
    //3.当你要强调一系列相关的产品对象的设计以便进行联合使用时。
    //4.当你提供一个产品类库，而只想显示它们的接口不是实现时。
    //动机(Motivate)：
    //在软件系统中，经常面临着"一系统相互依赖的对象"的创建工作：同时，由于需求的变化，往往存在更多系列对象的创建工作。
    //如何应对这种变化？如何绕过常规的对象创建方法（new),提供一种"封装机制"来避免客户程序和这种"多系列具体对象创建工作"的紧耦合？
    /// </summary>
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA
    {
        public abstract void Interact(AbstractProductB b);
    }


    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }




    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;
        public Client(AbstractFactory factory)
        {
            AbstractProductA = factory.CreateProductA();
            AbstractProductB = factory.CreateProductB();
        }
        /// <summary>
        /// 把成员做成抽象成员来 让子类实现抽象是成员，可实现 抽象成员的多态
        /// </summary>
        public void Run()
        {
            AbstractProductB.Interact(AbstractProductA);
            AbstractProductA.Interact(AbstractProductB);
        }
    }


    class ConcreteFactory1 : AbstractFactory
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


    class ConcreteFactory2 : AbstractFactory
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


    class ProductA1 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            MessageBox.Show(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }


    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            MessageBox.Show(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }


    class ProdcutA2 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            MessageBox.Show(this.GetType().Name + "interact with" + b.GetType().Name);
        }
    }


    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            MessageBox.Show(this.GetType().Name + "interact with" + a.GetType().Name);
        }
    }





}
