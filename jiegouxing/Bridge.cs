using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhuangshixin
{
    //呵呵，您是不是已经看出来了，不错，我今天要说的就是Bridge模式。为了一幅画，我们需要准备36支型号不同的蜡笔，
    //而改用毛笔三支就够了，当 然还要搭配上12种颜料。通过Bridge模式，我们把乘法运算3×12＝36改为了加法运算3＋12＝15，
    //这一改进可不小。那么我们这里蜡笔和毛笔到 底有什么区别呢？
    //毛笔有大中小三号，颜料有红绿蓝等12种，于是便可出现3×12种组合。每个参与者（毛笔与颜料）都可以在自己的自由度 上随意转换。
    //    蜡笔由于无法将笔与颜色分离，造成笔与颜色两个自由度无法单独变化，使得只有创建36种对象才能完成任务。
    //Bridge模式将继承关系转换为组合关系，从而降低了系统间的耦合，减少了代码编写量。  
    abstract class Brush  // 把 3中 画刷 和 12 中颜色  桥接再一看 画画， 你可用 任一画刷 和 任一颜色
    {

        public abstract void Paint();

        protected Color c;        
        public void SetColor(Color c)
        { this.c = c; }
    }
    class BigBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using big brush and color {0} painting", c.color); }
    }

    class SmallBrush : Brush
    {
        public override void Paint()
        { Console.WriteLine("Using small brush and color {0} painting", c.color); }
    }
    class Color
    {
        public string color;
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
