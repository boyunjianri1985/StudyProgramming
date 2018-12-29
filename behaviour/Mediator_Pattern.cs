using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{
//在软件构建过程中，经常会出现多个对象互相关联交互的情况，对象之间常常会维持一种复杂的引用关系，
//如果遇到一些需求的更改，这种直接的引用关系将面临不断的变化。
//在这种情况下，我们可使用一个“中介对象”来管理对象间的关联关系，
//避免相互交互的对象之间的紧耦合引用关系，从而更好地抵御变化。
    abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    //ConcreteMediator
    /// <summary>
    /// 内部有一个记录外壳类的Hashtable，把Chatroom登记录入一个外壳类中。 Send
    /// </summary>
    class Chatroom : AbstractChatroom
    {
        private Hashtable participants = new Hashtable();
        public override void Register(Participant participant)
        {
            if (participants[participant.Name] == null)
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }
        public override void Send(string from, string to, string message)
        {
            Participant pto = (Participant)participants[to];
            if (pto != null)
            {
                pto.Receive(from, message);
            }
        }
    }

    //AbstractColleague
    /// <summary> 
    /// 类似适配器，外壳类  ， chatroom是干活的
    /// </summary>
    class Participant
    {
        private Chatroom chatroom;
        private string name;

        //Constructor
        public Participant(string name)
        {
            this.name = name;
        }
        //Properties
        public string Name
        {
            get { return name; }
        }
        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }

        }
        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }
        public virtual void Receive(string from, string message)
        {
            Trace.WriteLine(string.Format("from-{0} to-{1}:'{2}'", from, name, message));
        }
    }



    //ConcreteColleaguel
    class Beatle : Participant
    {
        //Constructor
        public Beatle(string name)
            : base(name)
        { }
        public override void Receive(string from, string message)
        {
            Trace.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }




    //ConcreteColleague2
    class NonBeatle : Participant
    {
        //Constructor
        public NonBeatle(string name)
            : base(name)
        { }
        public override void Receive(string from, string message)
        {
            Trace.Write("To a non-Beatle:");
            base.Receive(from, message);
        }
    }





}
