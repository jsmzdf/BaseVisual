using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace AppBD.Clases
{
    class PrestamoContrato
    {
        public Conexion con = new Conexion();
        public DataSet TABLA;
        public OleDbDataAdapter ORDEN;
        DataTable dt = new DataTable();
        OleDbCommand ORDENU;
    }
}
