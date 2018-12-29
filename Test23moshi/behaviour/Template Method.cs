using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
//在上面的例子中，需要注意的是：
//1．对于Connect()和Disconnect()方法实现为了virtual，而Select()和Display()方法则为abstract，这是因为如果这个方法有默认的实现，则实现为virtual，否则为abstract。
//2．Run()方法作为一个模版方法，它的一个重要特征是：在基类里定义，而且不能够被派生类更改。有时候它是私有方法（private method），但实际上它经常被声明为protected。它通过调用其它的基类方法（覆写过的）来工作，但它经常是作为初始化过程的一部分被调用的，这样就没必要让客户端程序员能够直接调用它了。
//3．在一开始我们提到了不管读的是哪张数据表，它们都有共同的操作步骤，即共同点。因此可以说Template Method模式的一个特征就是剥离共同点。
//Template Mehtod实现要点：
//1．Template Method模式是一种非常基础性的设计模式，在面向对象系统中有着大量的应用。它用最简洁的机制（虚函数的多态性）为很多应用程序框架提供了灵活的扩展点，是代码复用方面的基本实现结构。
//2．除了可以灵活应对子步骤的变化外，“不用调用我，让我来调用你（Don't call me ,let me call you)”的反向控制结构是Template Method的典型应用。“Don’t call me.Let me call you”是指一个父类调用一个子类的操作，而不是相反。
//3．在具体实现方面，被Template Method调用的虚方法可以具有实现，也可以没有任何实现（抽象方法，纯虚方法），但一般推荐将它们设置为protected方法。
  // MY :数据库之中使用 模板 ，  用 虚方法， 抽象类都可以
    public abstract class DataAccessObject
    {
        protected string connectionString;

        protected DataSet dataSet;

        protected virtual void Connect()
        {
            connectionString =

                "Server=.;User Id=sa;Password=;Database=Northwind";

        }

        protected abstract void Select();

        protected abstract void Display();


        protected virtual void Disconnect()
        {
            connectionString = "";
        }

        // The "Template Method" 

        public void Run()
        {
            Connect();

            Select();

            Display();

            Disconnect();
        }
    }



    class Categories : DataAccessObject
    {
        protected override void Select()
        {
            string sql = "select CategoryName from Categories";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(

                sql, connectionString);

            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Categories");

        }

        protected override void Display()
        {

            Trace.WriteLine("Categories ---- ");

            DataTable dataTable = dataSet.Tables["Categories"];

            foreach (DataRow row in dataTable.Rows)
            {

                Trace.WriteLine(row["CategoryName"].ToString());

            }

            Trace.WriteLine("");

        }
    }

    class Products : DataAccessObject
    {
        protected override void Select()
        {
            string sql = "select top 10 ProductName from Products";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(

                sql, connectionString);

            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Products");

        }

        protected override void Display()
        {

            Trace.WriteLine("Products ---- ");

            DataTable dataTable = dataSet.Tables["Products"];

            foreach (DataRow row in dataTable.Rows)
            {
                Trace.WriteLine(row["ProductName"].ToString());

            }

            Trace.WriteLine("");

        }

    }

}
