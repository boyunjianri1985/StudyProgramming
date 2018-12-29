using System;
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

            IIterator iterator = null;

            IList list = new ConcreteList();

            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.CurrentItem();
                Trace.WriteLine(i.ToString());

                iterator.Next();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
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


        }




        private void button6_Click(object sender, EventArgs e)
        {


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
            SortdList studentRecords = new SortdList(); // 内部包含一个抽象类，多个算法实现这个抽象类，实际使用时再调用不同类去处理

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
