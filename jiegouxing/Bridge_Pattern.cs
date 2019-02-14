using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// 我今天要说的就是Bridge模式。为了一幅画，
/// 我们需要准备36支型号不同的蜡笔，而改用毛笔三支就够了，当 然还要搭配上12种颜料。通过Bridge模式，
/// 我们把乘法运算3×12＝36改为了加法运算3＋12＝15，这一改进可不小。那么我们这里蜡笔和毛笔到 底有什么区别呢？
/// 实际上，蜡笔和毛笔的关键一个区别就在于笔和颜色是否能够分离。【GOF95】桥梁模式的用意是"将抽象化 (Abstraction)与
/// 实现化(Implementation)脱耦，使得二者可以独立地变化"。
/// 


//解决的问题：有2个孔的插头了 ，但实际中只有3孔插座 ，使用一个中间电源适配器，让2孔插在适配器上，适配器再插在3孔插座上
//中心思想： 适配器继承重新实现 3孔插座的 方法， 方法中用的是2孔插座的方法
//可变化：3孔插座的 方法

namespace jiegouxing
{
    /// <summary>
    /// 笔用抽象类拆开，颜色用类继承拆开（也可以用抽象类分开）
    /// </summary>
    abstract class Brush//抽象方法 含2个抽象方法 一个工友方法
    {
        protected abstract Color c { get; set; }
        public abstract void Paint();

        public void SetColor(Color c)
        { this.c = c; }
    }


    class BigBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using big brush and color {0} painting", c.color); }

        protected override Color c
        { get; set; }
    }

    class SmallBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using small brush and color {0} painting", c.color); }

        protected override Color c
        {
            get; set;
        }
    }



    abstract class Color  //抽象类包含一个共有方法
    {
        public string color { get; set; }
    
    }


    class Red : Color
    {
        public Red()
        { this.color = "red"; }

    }

    class Green : Color
    {
        public Green()
        { this.color = "green"; }
    }


    class Blue : Color
    {
        public Blue()
        { this.color = "blue"; }
    }

}
