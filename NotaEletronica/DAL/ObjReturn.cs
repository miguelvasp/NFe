using System;
using System.Data;

namespace NotaEletronica.DAL
{
    public class ObjReturn
    {
        private Exception _objException;

        public Exception ObjException
        {
            get { return _objException; }
            set { _objException = value; }
        }

        private DataTable _objDataTable;

        public DataTable ObjDataTable
        {
            get { return _objDataTable; }
            set { _objDataTable = value; }
        }

        private object _objScalar;

        public object ObjScalar
        {
            get { return _objScalar; }
            set { _objScalar = value; }
        }

        private string _msgErro;

        public string MsgErro
        {
            get { return _msgErro; }
            set { _msgErro = value; }
        }

        public ObjReturn()
        {
            this.ObjDataTable = new DataTable();
            this.ObjScalar = new object();
        }
    }
}
