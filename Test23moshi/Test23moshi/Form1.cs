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
            GameSystem gameSystem = new GameSystem();

            gameSystem.Run(new NormalActorA());
        }


    }
}
