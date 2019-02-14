using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zhuangshixin;
using  System.Threading;

namespace jiegouxing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Brush b = new BigBrush(); // 画刷可以新建3中不同画刷
            b.SetColor(new Red()); // 画刷可以选择不同颜料
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();

            b = new SmallBrush();
            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();
            b.SetColor(new Green());
            b.Paint();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tank tank = new T50();
            DecoratorA da = new DecoratorA(tank); //且有红外功能
            da.Shot();
            
            DecoratorB db = new DecoratorB(da);   //且有红外和水陆两栖功能
            db.Shot();
            DecoratorC dc = new DecoratorC(db);   //且有红外、水陆两栖、卫星定们三种功能
            dc.Shot();
            dc.Run();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Picture root = new Picture("Root"); //一个工具箱可以不断往里添加工具（组合到一块），使用时所有工具一起作用

            root.Add(new Line("Line"));
            root.Add(new Circle("Circle"));

            Rectangle r = new Rectangle("Rectangle");
            root.Add(r);

            root.Draw();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MovieFacade movie = new MovieFacade();
            Projector projector = new Projector();

            //首先是观看电影 
            movie.OpenMovie();

            //然后是将投影仪模式调到宽屏模式 
            projector.SetWideScreen();
            //再将投影仪模式调回普通模式 
            projector.SetStandardScreen();
            Console.WriteLine();

            //最后就是关闭电影了 
            movie.CloseMovie();
            Console.ReadKey(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CharactorFactory factory = new CharactorFactory();

            // Charactor "A"
            CharactorA ca = (CharactorA)factory.GetCharactor("A");
            ca.SetPointSize(12);
            ca.Display();

            // Charactor "B"
            CharactorB cb = (CharactorB)factory.GetCharactor("B");
            ca.SetPointSize(10);
            ca.Display();

            // Charactor "C"
            CharactorC cc = (CharactorC)factory.GetCharactor("C");
            ca.SetPointSize(14);
            ca.Display();
        }

        private void button7_Click(object sender, EventArgs e)
        {

/*            MathProxy proxy = new MathProxy();

            double addresult = proxy.Add(2, 3);
            Trace.WriteLine(addresult);
            double subresult = proxy.Sub(6, 4);
            Trace.WriteLine(subresult);
            double mulresult = proxy.Mul(2, 3);
            Trace.WriteLine(mulresult);
            double devresult = proxy.Dev(2, 3);
            Trace.WriteLine(devresult);*/
            List<MathProxy> objs = new List<MathProxy>();
            var action = new Action(() =>
            {
                System.Diagnostics.Trace.WriteLine(string.Format("CurrentThreadID:{0},CallTime；{1}",System.Threading.Thread.CurrentThread.ManagedThreadId,Environment.TickCount));
                var math = MathProxy.Instance;
                objs.Add(math);
                System.Diagnostics.Trace.WriteLine(string.Format("CurrentThreadID:{0},InstanceCreateTime；{1}",System.Threading.Thread.CurrentThread.ManagedThreadId,math.CreateTimeStamp));
            });

            var th1 = new Thread(new ThreadStart(action));
            var th2 = new Thread(new ThreadStart(action));
            var th3 = new Thread(new ThreadStart(action));
            var th4 = new Thread(new ThreadStart(action));

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            while (objs.Count<4)
            {
                Thread.Sleep(20);
            }
            if (objs.Count >= 4)
            {
                for (int i = 0; i < objs.Count-1; i++)
                {
                    var r = object.ReferenceEquals(objs[i], objs[i + 1]);
                    Trace.WriteLine("Compare Result:"+r);
                    var r1 = System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(objs[i]);
                    var r2 = System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(objs[i+1]);

                }
            }


            Console.WriteLine();
            Thread.Sleep(2000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////类的适配器现在客人可以通过电适配要使用2个孔的插头插在3个孔上
            //IThreeHole threehole = new PowerAdapter();
            //threehole.Request();
            //Console.ReadLine();

            //对象的适配器
            // 现在客户端可以通过电适配要使用2个孔的插头了
            ThreeHole threehole = new PowerAdapter1();
            threehole.Request();
            Console.ReadLine();



        }
    }
}
