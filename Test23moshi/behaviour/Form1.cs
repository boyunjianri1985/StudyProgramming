using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace behaviour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccessObject dao;
            dao = new Categories();
            dao.Run();
            dao = new Products();
            dao.Run();
            // Wait for user 
            Console.Read();

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }
    }
}
