using System;
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tank tank = new T50();
            DecoratorA da = new DecoratorA(tank); //且有红外功能
            DecoratorB db = new DecoratorB(da);   //且有红外和水陆两栖功能
            DecoratorC dc = new DecoratorC(db);   //且有红外、水陆两栖、卫星定们三种功能
            dc.Shot();
            dc.Run();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Picture root = new Picture("Root");

            root.Add(new Line("Line"));
            root.Add(new Circle("Circle"));

            Rectangle r = new Rectangle("Rectangle");
            root.Add(r);

            root.Draw();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //外观
            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Ann McKinsey");
            bool eligable = mortgage.IsEligible(customer, 125000);

            Trace.WriteLine("\n" + customer.Name +
                " has been " + (eligable ? "Approved" : "Rejected"));
            Trace.WriteLine("");
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

            MathProxy proxy = new MathProxy();

            double addresult = proxy.Add(2, 3);
            Trace.WriteLine(addresult);
            double subresult = proxy.Sub(6, 4);
            Trace.WriteLine(subresult);
            double mulresult = proxy.Mul(2, 3);
            Trace.WriteLine(mulresult);
            double devresult = proxy.Dev(2, 3);
            Trace.WriteLine(devresult);





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
