using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test23moshi
{  
    //灵活地动态创建“拥有某些稳定接口中”的新对象----所需工作仅仅是注册的地方不断地Clone.
    //Prototype模式中的Clone方法可以利用.net中的object类的memberwiseClone()方法或者序列化来实现深拷贝。

    //解决的问题：不同车工厂生产出不同款式的车，但车有固定的抽象（启动，跑，停止）
    //中心思想：灵活地动态创建“拥有某些稳定接口中”的新对象----所需工作仅仅是注册的地方不断地Clone.
    //可变化：各种Color子类 可变化（实现了抽象类（可将自己复制出去）） 
    // 就是把自己的副本复制出去
    public abstract class ColorPrototype //抽象类
    {
        public abstract ColorPrototype Clone(); //抽象方法
    }

    public class Color : ColorPrototype  //实现抽象类的对象
    {
        private int _red;
        private int _green;
        private int _blue;

        /// <summary>
        /// Constructor
        /// </summary>
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }
        /// <summary>
        /// Create a shallow copy
        /// </summary>
        public override ColorPrototype Clone() //抽象方法：将自己的 浅拷贝 复制出去
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);
            return this.MemberwiseClone() as ColorPrototype;
        }
    }
    public class ColorManager //实力类管理器,把实例类都放进键值对中（使用类索引器）
    {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();
        /// <summary>
        /// Indexer
        /// </summary>
        public ColorPrototype this[string key] //类索引器作用，把类当索引器使用，其实内部是对自己的内部的属性的设置
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }




}
