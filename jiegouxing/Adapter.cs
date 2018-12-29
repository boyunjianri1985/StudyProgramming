using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhuangshixin
{
    //适用性：
    //1．系统需要使用现有的类，而此类的接口不符合系统的需要。
    //2．想要建立一个可以重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。这些源类不一定有很复杂的接口。
    //3．（对对象适配器而言）在设计里，需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。
    //Adapter模式的几个要点：
    //Adapter模式主要应用于“希望复用一些现存的类，但是接口又与复用环境要求不一致的情况”，在遗留代码复用、类库迁移等方面非常有用。
    //GOF23定义了两种Adapter模式的实现结构：对象适配器和类适配器。但类适配器采用“多继承”的实现方式，带来不良的高耦合，所以一般不推荐使用。对象适配器采用“对象组合”的方式，更符合松耦合精神。
 
    interface IStack
    {
        void Push(object item);
        void Pop();
        object Peek();
    }

    //对象适配器(Adapter与Adaptee组合的关系)  
    public class Adapter : IStack //适配对象 , 相当于一个外壳类， 实现 系统需要的接口
    {
        ArrayList adaptee;//被适配的对象 , 他才是真正干活的 类
        public Adapter()
        {
            adaptee = new ArrayList();
        }
        public void Push(object item)
        {
            adaptee.Add(item);
        }
        public void Pop()
        {
            adaptee.RemoveAt(adaptee.Count - 1);
        }
        public object Peek()
        {
            return adaptee[adaptee.Count - 1];
        }

        public override string ToString()
        {
            return  adaptee.ToArray().ToString();
        }
    }
    public class Adapter2 : ArrayList, IStack
    {
        public void Push(object item)
        {
            this.Add(item);
        }
        public void Pop()
        {
            this.RemoveAt(this.Count - 1);
        }
        public object Peek()
        {
            return this[this.Count - 1];
        }
    }

}
