using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jiegouxing
{
    //解决的问题：有2个孔的插头了 ，但实际中只有3孔插座 ，使用一个中间电源适配器，让2孔插在适配器上，适配器再插在3孔插座上
    //中心思想： 适配器继承重新实现 3孔插座的 方法， 方法中用的是2孔插座的方法
    //可变化：3孔插座的 方法

    public class ThreeHole
    {
        // 客户端需要的方法
        public virtual void Request()
        {
            // 可以把一般实现放在这里
        }
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public class TwoHole1
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，这里适配器类没有TwoHole类，
    /// 而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class PowerAdapter1 : ThreeHole
    {
        // 引用两个孔插头的实例,从而将客户端与TwoHole联系起来
        public TwoHole1 twoholeAdaptee = new TwoHole1();

        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public override void Request()
        {
            twoholeAdaptee.SpecificRequest();
        }
    }
}
