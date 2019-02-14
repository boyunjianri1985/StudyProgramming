using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jiegouxing
{
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }


    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public abstract class TwoHole
    {
        public  void  SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }

    public class PowerAdapter : TwoHole1 , IThreeHole
    {

        public void Request()
        {
            this.SpecificRequest();
        }
    }


}
