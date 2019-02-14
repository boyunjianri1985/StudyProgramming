using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jiegouxing
{
    // 外观类
    //Facade模式的个要点： 就是让客户一键控制所有设备的开启和关闭按钮 , 类似3层架构

    //Facade设计模式更注重从架构的层次去看整个系统，而不是单个类的层次。Facdae很多时候更是一种架构
    //注意区分Facade模式、Adapter模式、Bridge模式与Decorator模式。Facade模式注重简化接口，Adapter模式注重转换接口，
    //Bridge模式注重分离接口（抽象）与其实现，Decorator模式注重稳定接口的前提下为对象扩展功能。


    /// <summary> 
    /// 投影仪 
    /// </summary> 
    public class Projector
    {
        public void OpenProjector()
        {
            Console.WriteLine("打开投影仪");
        }
        public void CloseProjector()
        {
            Console.WriteLine("关闭投影仪");
        }
        public void SetWideScreen()
        {
            Console.WriteLine("投影仪状态为宽屏模式");
        }
        public void SetStandardScreen()
        {
            Console.WriteLine("投影仪状态为标准模式");
        }
    }

    /// <summary> 
    /// 功放机 
    /// </summary> 
    public class Amplifier
    {
        public void OpenAmplifier()
        {
            Console.WriteLine("打开功放机");
        }
        public void CloseAmplifier()
        {
            Console.WriteLine("关闭功放机");
        }
    }



    /// <summary> 
    /// 屏幕 
    /// </summary> 
    public class Screen
    {
        public void OpenScreen()
        {
            Console.WriteLine("打开屏幕");
        }
        public void CloseScreen()
        {
            Console.WriteLine("关闭屏幕");
        }
    }


    /// <summary> 
    /// DVD播放器 
    /// </summary> 
    public class DVDPlayer
    {
        public void OpenDVDPlayer()
        {
            Console.WriteLine("打开 DVD 播放器");
        }
        public void CloseDVDPlayer()
        {
            Console.WriteLine("关闭 DVD 播放器");
        }
    }


    /// <summary> 
    /// 灯光 
    /// </summary> 
    public class Light
    {
        public void OpenLight()
        {
            Console.WriteLine("打开灯光");
        }
        public void CloseLight()
        {
            Console.WriteLine("关闭灯光");
        }
    }

    //外观类中的代码：


    /// <summary> 
    /// 定义一个外观 
    /// </summary> 
    public class MovieFacade
    {
        /// <summary> 
        /// 在外观类中必须保存有子系统中各个对象 
        /// </summary> 
        private Projector projector;
        private Amplifier amplifier;
        private Screen screen;
        private DVDPlayer dvdPlayer;
        private Light light;
        public MovieFacade()
        {
            projector = new Projector();
            amplifier = new Amplifier();
            screen = new Screen();
            dvdPlayer = new DVDPlayer();
            light = new Light();
        }
        /// <summary> 
        /// 打开电影 
        /// </summary> 
        public void OpenMovie()
        {
            //先打开投影仪 
            projector.OpenProjector();
            //再打开功放 
            amplifier.OpenAmplifier();
            //再打开屏幕 
            screen.OpenScreen();
            //再打开 DVD 
            dvdPlayer.OpenDVDPlayer();
            //再打开灯光 
            light.OpenLight();
        }
        /// <summary> 
        /// 关闭电影 
        /// </summary> 
        public void CloseMovie()
        {
            //关闭投影仪 
            projector.CloseProjector();
            //关闭功放 
            amplifier.CloseAmplifier();
            //关闭屏幕 
            screen.CloseScreen();
            //关闭 DVD 
            dvdPlayer.CloseDVDPlayer();
            //关闭灯光 
            light.CloseLight();
        }
    }




}
