using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test23moshi
{
    public class Thread_Singleton
    {
        private static Thread_Singleton instance = null;
        private Thread_Singleton() { }
        public static Thread_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Thread_Singleton();
                }
                return instance;
            }
        }

        public void SetName()
        {

        }
    }

}

class MultiThread_Singleton
{
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
    private MultiThread_Singleton() { }

    public void SetName()
    {

    }

}
