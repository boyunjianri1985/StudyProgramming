using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test23moshi
{

    //适用性：
    //1.当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
    //2.当构造过程必须允许被构造的对象有不同的表示时。

    //解决的问题：一个房子的建造包括门、地、墙、窗户，不同国家可能建造的房子风格不一样，但结构一样
    //中心思想：创建1抽象类内有几个固定抽象方法
    //可变化的是这个抽象类即内部的 抽象方法
    public  class House
    {
        //該類中可能包含複雜的創建邏輯

        internal void Show()
        {
            
        }
    }

    public abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWall();
        public abstract void BuildWindows();
        public abstract void BuildFloor();
        public abstract void BuildHouseCeiling();

        public abstract House GetHouse();
    }
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildWall();
            builder.BuildHouseCeiling();
            builder.BuildDoor();
            builder.BuildWindows();
            builder.BuildFloor();
        }
    }
    public class ChineseBuilder : Builder
    {
        private House ChineseHouse = new House();
        public override void BuildDoor()
        {
            MessageBox.Show("this Door 's style of Chinese");
        }
        public override void BuildWall()
        {
            MessageBox.Show("this Wall 's style of Chinese");
        }
        public override void BuildWindows()
        {
            MessageBox.Show("this Windows 's style of Chinese");
        }
        public override void BuildFloor()
        {
            MessageBox.Show("this Floor 's style of Chinese");
        }
        public override void BuildHouseCeiling()
        {
            MessageBox.Show("this Ceiling 's style of Chinese");
        }
        public override House GetHouse()
        {
            return ChineseHouse;
        }
    }
    class RomanBuilder : Builder
    {
        private House RomanHouse = new House();
        public override void BuildDoor()
        {
            MessageBox.Show("this Door 's style of Roman");
        }
        public override void BuildWall()
        {
            MessageBox.Show("this Wall 's style of Roman");
        }
        public override void BuildWindows()
        {
            MessageBox.Show("this Windows 's style of Roman");
        }
        public override void BuildFloor()
        {
            MessageBox.Show("this Floor 's style of Roman");
        }
        public override void BuildHouseCeiling()
        {
            MessageBox.Show("this Ceiling 's style of Roman");
        }
        public override House GetHouse()
        {
            return RomanHouse;
        }
    }


}
