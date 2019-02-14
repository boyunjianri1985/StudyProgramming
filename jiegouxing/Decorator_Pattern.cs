using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  装饰模式(Decorator Pattern)：  子类复子类，子类何其多
//    假如我们需要为游戏中开发一种坦克，除了各种不同型号的坦克外，我们还希望在不同场合中为其增加以下一种或多种功能;比如红外线夜视功能，比如水陆两栖功能，比如卫星定位功能等等。
// 就像 嵌套一样，把一个类存为另一个类的父类

// 故事 ： 给一个坦克不断在同一个方法上添加新方法 （就像不断的往一辆坦克上添加各种功能）

//


namespace zhuangshixin
{
    public abstract class Tank
    {
        public abstract void Shot();
        public abstract void Run();
    }

    public class T50 : Tank
    {
        public override void Shot()
        {
            Trace.WriteLine("T50坦克平均每秒射击5发子弹");
        }
        public override void Run()
        {

            Trace.WriteLine("T50坦克平均每时运行30公里");
        }
    }


    public class T75 : Tank
    {
        public override void Shot()
        {
            Trace.WriteLine("T75坦克平均每秒射击10发子弹");
        }
        public override void Run()
        {
            Trace.WriteLine("T75坦克平均每时运行35公里");
        }
    }

    public class T90 : Tank
    {
        public override void Shot()
        {
            Trace.WriteLine("T90坦克平均每秒射击10发子弹");
        }
        public override void Run()
        {
            Trace.WriteLine("T90坦克平均每时运行40公里");
        }
    }


    public abstract class Decorator : Tank //Do As 接口继承 非实现继承 ， 继承抽象坦克后，添加一个实例成员记录父坦克
    {
        private Tank tank; //父类中保存了一个非抽象成员（实例成员）
         public  Decorator(Tank tank)
        {
            this.tank = tank;
        }
        public override void Shot()
        {
            tank.Shot();
        }
        public override void Run()
        {
            tank.Run();
        }

    }


        public class DecoratorA : Decorator
        {
            public DecoratorA(Tank tank)
                : base(tank)            //把tank保存为自己的私有类
            {
            }
            public override void Shot() // 每个实例类实现自己方法后，又调用父类方法，形成迭代
            {
                //Do some extension //功能扩展 且有红外功能
                Trace.WriteLine("且有红外功能");  // 先用自己的方法，在调用 tank 的方法。 相当于在原来的tank 方法上附加了一个方法
                base.Shot();
            }
            public override void Run()
            {

                base.Run();
            }
        }

        public class DecoratorB : Decorator
        {
            public DecoratorB(Tank tank)
                : base(tank)
            {
            }
            public override void Shot()
            {
                //Do some extension //功能扩展 且有水陆两栖功能
                Trace.WriteLine("且有功能扩展 且有水陆两栖功能");
                base.Shot();
            }
            public override void Run()
            {

                base.Run();
            }
        }


        public class DecoratorC : Decorator
        {
            public DecoratorC(Tank tank)
                : base(tank)
            {
            }
            public override void Shot()
            {
                //Do some extension //功能扩展 且有卫星定位功能
                Trace.WriteLine("且有功能扩展 且有卫星定位功能");
                base.Shot();
            }
            public override void Run()
            {

                base.Run();
            }

        }
    }




