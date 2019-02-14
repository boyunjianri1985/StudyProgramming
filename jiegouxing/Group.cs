using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jiegouxing
{

       //组合模式有时候又叫做部分-整体模式，它使我们树型结构的问题中，模糊了简单元素和复杂元素的概念，
       // 客户程序可以向处理简单元素一样来处理复杂元素,从而使得客户程序与复杂元素的内部结构解耦。
    //my： Picture 相当于一个 容器，  具体做事的 是子类 ，具体用哪个子类划线，可以对容器操作 ， 外部只调用 Picture 操作即可

    //故事：工具箱里有很多工具，使用时组合使用 


    public abstract class Graphics //一个抽象类 含一个抽象方法，1个字段1个设置字段方法
    {
        protected string _name;

        public Graphics(string name)
        {
            this._name = name;
        }
        public abstract void Draw();
    }

    public class Picture : Graphics   //子类实现抽象类后，内部有链表可放多个抽象父类，画图用列表中实例类画图 
    {
        protected ArrayList picList = new ArrayList();

        public Picture(string name)
            : base(name)
        { }
        public override void Draw()  
        {
            Trace.WriteLine("Draw a" + _name.ToString());

            foreach (Graphics g in picList)
            {
                g.Draw();
            }
        }

        public void Add(Graphics g)
        {
            picList.Add(g);
        }
        public void Remove(Graphics g)
        {
            picList.Remove(g);
        }
    }

    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Trace.WriteLine("Draw a" + _name.ToString());
        }
    }

    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Trace.WriteLine("Draw a" + _name.ToString());
        }
    }

    public class Rectangle : Graphics
    {
        public Rectangle(string name)
            : base(name)
        { }

        public override void Draw()
        {
            Trace.WriteLine("Draw a" + _name.ToString());
        }
    }

}
