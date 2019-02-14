using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{



    //Command模式它封装的是命令，把命令发出者的责任和命令执行者的责任分开
   public abstract class DocumentCommand  // 1个抽象类内含一个实例类并有初始方法（适配器），1个执行抽象方法
    {                                   //子类实现抽象方法，调用适配器的中发各种方法，实现子类的各个功能（）
        public Document _document; //适配

        public DocumentCommand(Document doc)
        {
            this._document = doc;
        }

        /**/
        /// <summary>

        /// 执行

        /// </summary>

        public abstract void Execute();

    }
    public class DisplayCommand : DocumentCommand  
    {
        public DisplayCommand(Document doc)

            : base(doc)
        {

        }

        public override void Execute()
        {
            _document.Display();
        }
    }

    public class UndoCommand : DocumentCommand
    {
        public UndoCommand(Document doc)

            : base(doc)
        {

        }

        public override void Execute()
        {
            _document.Undo();
        }
    }


    public class RedoCommand : DocumentCommand
    {
        public RedoCommand(Document doc)

            : base(doc)
        {

        }

        public override void Execute()
        {
            _document.Redo();
        }
    }

    /// <summary>
    /// 命令执行者，只是执行菜单的命令，菜单用 抽象类 
    /// </summary>
    public class DocumentInvoker  //实体类中包含3个抽象类，使用3个子类实现各自功能 
    {
        DocumentCommand _discmd;

        DocumentCommand _undcmd;

        DocumentCommand _redcmd;

        public DocumentInvoker(DocumentCommand discmd, DocumentCommand undcmd, DocumentCommand redcmd)
        {

            this._discmd = discmd;

            this._undcmd = undcmd;

            this._redcmd = redcmd;

        }

        public void Display()
        {
            _discmd.Execute();
        }

        public void Undo()
        {
            _undcmd.Execute();
        }

        public void Redo()
        {
            _redcmd.Execute();
        }
    }

    /// <summary>
    /// 命令发出者 ， 
    /// </summary>
    public class Document
    {
        /**/
        /// <summary>

        /// 显示操作

        /// </summary>

        public void Display()
        {
            Trace.WriteLine("Display");
        }

        /**/
        /// <summary>

        /// 撤销操作

        /// </summary>

        public void Undo()
        {
            Trace.WriteLine("Undo");
        }

        /**/
        /// <summary>

        /// 恢复操作

        /// </summary>

        public void Redo()
        {
            
            Trace.WriteLine("Redo");
        }
    }



}
