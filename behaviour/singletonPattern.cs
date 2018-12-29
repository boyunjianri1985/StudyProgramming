using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23Singleton
{
    public class SingleThread_Singleton
    {
        private static SingleThread_Singleton instance = null;
        public static SingleThread_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingleThread_Singleton();
                }
                return instance;
            }
        }
        private SingleThread_Singleton() { }

        public void sayHello()
        {
            MessageBox.Show("hello!");

        }

    }


    public class MultiThread_Singleton
    {
        //volatile 保证严格意义的多线程编译器在代码编译时对指令不进行微调。
        private static volatile MultiThread_Singleton instance = null;
        private static object lockHelper = new object();

        public static MultiThread_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new MultiThread_Singleton();
                        }
                    }
                }

                return instance;
            }
        }
        private MultiThread_Singleton()
        {
        }
        public void sayHello()
        {
            MessageBox.Show("hello!");

        }

    }





}
