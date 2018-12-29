using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{




   public abstract class DocumentCommand
    {
        public Document _document;

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

    public class DocumentInvoker
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
