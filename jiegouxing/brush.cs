using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jiegouxing
{
    public abstract class Brushs
    {
        protected abstract colors cl { get; set; }
        public abstract void Paint();

        public void setColor(colors c)
        {
            this.cl = c;
        }
    }



    public abstract class colors
    {
        public abstract String color { get; set; }
    }
}
