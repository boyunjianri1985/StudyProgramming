using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test23moshi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Director director = new Director();

            Builder instance = new RomanBuilder();

            string houseType = "RomanBuilder";

            director.Construct(instance);

            House house = instance.GetHouse();
            house.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int no = 1;
            string factoryType = "No" + no;
            CarFactory factory = new HongQiCarFactory();



            //    CarFactory factory = new 
            Car car = factory.CarCreate();
            car.StartUp();
            car.Run();
            car.Stop();

            CarFactory  factory1 = new BMWCarFactory();
            car = factory1.CarCreate();
            car.StartUp();
            car.Run();
            car.Stop();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GameSystem gameSystem = new GameSystem();

            //gameSystem.Run(new NormalActorA());

            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread_Singleton.Instance.SetName();
            MultiThread_Singleton.Instance.SetName();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Abstractfactory1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();
            // Abstractfactory2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();
        }



    }
}
