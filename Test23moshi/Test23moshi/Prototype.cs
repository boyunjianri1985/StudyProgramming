using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test23moshi
{
  // 适用性： my理解： 先用类  的 浅复制（尤其这个类创建代价很大，比如需要数据库的数据） ， 如果正式使用时 ， 再更新数据库即可
  //1．当一个系统应该独立于它的产品创建，构成和表示时；
  //  2．当要实例化的类是在运行时刻指定时，例如，通过动态装载；
  //  3．为了避免创建一个与产品类层次平行的工厂类层次时；
  //  4．当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。

    public abstract class NormalActor
    {
        public abstract NormalActor clone();
    }
    public class NormalActorA : NormalActor
    {
        public override NormalActor clone()
        {
            Trace.WriteLine("NormalActorA is call");
            return (NormalActor)this.MemberwiseClone();

        }
    }
    public class NormalActorB : NormalActor
    {
        public override NormalActor clone()
        {
            Trace.WriteLine("NormalActorB  was called");
            return (NormalActor)this.MemberwiseClone();

        }
    }
    public class GameSystem
    {
        public void Run(NormalActor normalActor)
        {
            NormalActor normalActor1 = normalActor.clone();
            NormalActor normalActor2 = normalActor.clone();
            NormalActor normalActor3 = normalActor.clone();
            NormalActor normalActor4 = normalActor.clone();
            NormalActor normalActor5 = normalActor.clone();

        }
    }


}
