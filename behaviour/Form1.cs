using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _23Singleton;

namespace behaviour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccessObject dao;
            dao = new Categories();
            dao.Run();
            dao = new Products();
            dao.Run();
            // Wait for user 
            Console.Read();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Document doc = new Document();
            DocumentCommand discmd = new DisplayCommand(doc);

            DocumentCommand undcmd = new UndoCommand(doc);

            DocumentCommand redcmd = new RedoCommand(doc);

            DocumentInvoker invoker = new DocumentInvoker(discmd, undcmd, redcmd);

            invoker.Display();

            invoker.Undo();

            invoker.Redo();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //就是实现 IEnumerable 接口，可以使用 foreach 循环遍历
            IEnumerable iter = new ConList();


            foreach (var VARIABLE in iter)
            {
                Trace.WriteLine(VARIABLE.ToString());
            }

            //IIterator iterator = null;

            //IList list = new ConcreteList();

            //iterator = list.GetIterator();

            //while (iterator.MoveNext())
            //{
            //    int i = (int)iterator.CurrentItem();
            //    Trace.WriteLine(i.ToString());

            //    iterator.Next();
            //}


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //当银行的钱数发生变化时，手机短信，邮件，等多种通知方式通知
            // 一个银行类中有 一个联系方式通知的IObserverAccount抽象的 列表， 如果钱数有变化，遍历这个列表的抽象类，每一个都发送消息
            BankAccount ba = new BankAccount();
            IObserverAccount emailer = new Emailer("abcdwxc@163.com");
            IObserverAccount mobile = new Mobile(13901234567);

            ba.Money = 2000;
            ba.AddObserver(emailer);
            ba.AddObserver(mobile);

            ba.WithDraw();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string englist = "This is an apple.";
            string chinese = Translator.Translate(englist);
            Trace.WriteLine(chinese);

        }




        private void button6_Click(object sender, EventArgs e)
        {

            // 把所有的信息都放在 中介者的房屋中，有在房屋中 对某个人发送信息
            //中介者 房屋聊天室 ， 有键值对集合把注册这都集合起来，发送接受消息还是用 聊天者的方法
            Chatroom chatroom = new Chatroom();
            //Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new Beatle("Yoko");
            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            //chatting participants
            Yoko.Send("John", "Hi John");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //就像列表一样首尾相连把一个抽象类设置为自己的私有类，这样，从列表的第一个开始对请求处理，符合条件的就用那个类处理，可以设置为 1个请求多人处理也可以1个请求1人处理

            //Setup Chain of Responsibility
            Director Larry = new Director();
            VicePresident Sam = new VicePresident();
            PresidentEx Tammy = new PresidentEx();
            Larry.SetSuccessor(Sam);   //设置了3层关系 ：  Larry 爷爷，  Sam ，爸爸，  Tammy 儿子  ， 如果爷爷 没需求，爸爸也没有  ，再看 儿子 （3 个 各自有 需求价格）
            Sam.SetSuccessor(Tammy);

            //Generate and process purchase requests
            Purchase p = new Purchase(1034, 350.00, "Supplies");
            Larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            Larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            Larry.ProcessRequest(p);

            //Wait for user



        }

        private void button9_Click(object sender, EventArgs e)
        {

            //就是用一个类保存自己的成员到另一个保存类中，还可以从保存类中恢复自己的成员
            SalesProspect s = new SalesProspect();
            s.Name = "xiaoming";
            s.Phone = "(010)65236523";
            s.Budget = 28000.0;

            //Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento(); //将 SalesProspect 类的成员函数保存到存储类中

            //Continue changing originator
            s.Name = "deke";
            s.Phone = "(029)85423657";
            s.Budget = 80000.0;

            //Restore saved state 
            s.RestoreMemento(m.Memento);   //从存储类中恢复到现有类中数据



        }

        private void button8_Click(object sender, EventArgs e)
        {
            SingleThread_Singleton.Instance.sayHello();
            MultiThread_Singleton.Instance.sayHello();
            MultiThread_Singleton.Instance.sayHello();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();
            // Abstractfactory2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();


        }





        private void button11_Click(object sender, EventArgs e)
        {

            //Two contexts following different strategies 
            SortdList studentRecords = new SortdList(); // 内部包含一个排序抽象类，多个排序算法类实现这个抽象类 ， 运算类 有一个抽象算法类， 抽象算法类列表， 实际使用时先设置用那个抽象类，再用这个抽象类的方法去排序

            studentRecords.Add("Satu");
            studentRecords.Add("Jim");
            studentRecords.Add("Palo");
            studentRecords.Add("Terry");
            studentRecords.Add("Annaro");

            studentRecords.SetSortStrategy(new QuickSort()); //用3
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();




        }

        private void button12_Click(object sender, EventArgs e)
        {


            Employees es = new Employees();
            es.Attach(new Clerk());  // 添加员工
            es.Attach(new Director123());
            es.Attach(new President123());

            // Employees are 'visited'
            es.Accept(new IncomeVisitor());  //对员工的操作放在不同的类中 ， 然后调用不同类去操作员工
            es.Accept(new VacationVisitor());

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Account account = new Account("Jim Johnson");

            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);


            //Deposited ¥500.00 --- 
            //Balance = ¥500.00
            //Status = SilverState


            //Deposited ¥300.00 --- 
            //Balance = ¥800.00
            //Status = SilverState


            //Deposited ¥550.00 --- 
            //Balance = ¥1,350.00
            //Status = GoldState


            //Interest Paid --- 
            //Balance = ¥1,417.50
            //Status = GoldState

            //Withdrew ¥2,000.00 --- 
            //Balance = ¥-582.50
            //Status = RedState

            //No funds available for withdrawal!
            //Withdrew ¥1,100.00 --- 
            // Balance = ¥-582.50
            //Status = RedState



        }

    }
}
