using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jiegouxing
{
    public abstract class Charactor
    {
        //Fields//my：工厂里存一个键值对集合，保存了3个类，要哪个，直接取出来用
        protected char _symbol;

        protected int _width;

        protected int _height;

        protected int _ascent;

        protected int _descent;

        protected int _pointSize;

        //Method
        public abstract void SetPointSize(int size);
        public abstract void Display();
    }

    // "CharactorA"
    public class CharactorA : Charactor
    {
        // Constructor 
        public CharactorA()
        {
            this._symbol = 'A';
            this._height = 100;
            this._width = 120;
            this._ascent = 70;
            this._descent = 0;
        }

        //Method
        public override void SetPointSize(int size)
        {
            this._pointSize = size;
        }

        public override void Display()
        {
            Trace.WriteLine(this._symbol +
              "pointsize:" + this._pointSize);
        }
    }

    // "CharactorB"
    public class CharactorB : Charactor
    {
        // Constructor 
        public CharactorB()
        {
            this._symbol = 'B';
            this._height = 100;
            this._width = 140;
            this._ascent = 72;
            this._descent = 0;
        }

        //Method
        public override void SetPointSize(int size)
        {
            this._pointSize = size;
        }

        public override void Display()
        {
            Trace.WriteLine(this._symbol +
              "pointsize:" + this._pointSize);
        }
    }

    // "CharactorC"
    public class CharactorC : Charactor
    {
        // Constructor 
        public CharactorC()
        {
            this._symbol = 'C';
            this._height = 100;
            this._width = 160;
            this._ascent = 74;
            this._descent = 0;
        }

        //Method
        public override void SetPointSize(int size)
        {
            this._pointSize = size;
        }

        public override void Display()
        {
            Trace.WriteLine(this._symbol +
              "pointsize:" + this._pointSize);
        }
    }

    // "CharactorFactory"
    public class CharactorFactory
    {
        // Fields
        private Hashtable charactors = new Hashtable(); //my：工厂里存一个键值对集合，保存了3个类，要哪个，直接取出来用

        // Constructor 
        public CharactorFactory()
        {
            charactors.Add("A", new CharactorA());
            charactors.Add("B", new CharactorB());
            charactors.Add("C", new CharactorC());
        }

        // Method
        public Charactor GetCharactor(string key)
        {
            Charactor charactor = charactors[key] as Charactor;

            if (charactor == null)
            {
                switch (key)
                {
                    case "A": charactor = new CharactorA(); break;
                    case "B": charactor = new CharactorB(); break;
                    case "C": charactor = new CharactorC(); break;
                    //
                }
                charactors.Add(key, charactor);
            }
            return charactor;
        }
    }


}
