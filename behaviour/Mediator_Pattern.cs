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

// 房屋中介将 房东和租房者 集合起来，互通信息有他们自己完成 ：中介者模式
//中介，1个房屋 1实体类1个虚方法，发送用的聊天房屋的方法，聊天房屋有调用中介的接受，接收用自己的虚方法 ， 从 房屋 中 注册者 1 给 2发消息（注册者都在中介）， 其实就是 2 接受消息 
    //一个抽象类2个抽象方法

    abstract class AbstractChatroom  //1个抽象类 2个抽象方法，注册参与群，发送消息
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message); 
    }

    //ConcreteMediator
    /// <summary>
    ///中介者 房屋聊天室 ， 有键值对集合把注册这都集合起来，发送接受消息还是用 聊天者的方法
   /// </summary>
    class Chatroom : AbstractChatroom // 
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
        public override void Send(string from, string to, string message) //给租房者发消息，就是在中介注册了信息的住房者接受消息
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
    ///  中介，1个房屋 1实体类1个虚方法，发送用的聊天房屋的方法，聊天房屋有调用中介的接受，接收用自己的虚方法 ， 从 房屋 中 注册者 1 给 2发消息（注册者都在中介）， 其实就是 2 接受消息 
    /// </summary>
    /// 
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
