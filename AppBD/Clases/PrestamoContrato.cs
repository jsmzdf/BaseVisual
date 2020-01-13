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
        public void addConPRes(double idPRestam, string con_no)
        {
            con.conectar();
            string q = "INSERT INTO [CONTRATO PRESTAMO](ID_PRESTAMO,CONTRATO_NO) " +
               "values(@ID_PRESTAMO,@CONTRATO_NO)";
            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@ID_PRESTAMO", OleDbType.Double));
            ORDENU.Parameters["@ID_PRESTAMO"].Value = idPRestam;
            ORDENU.Parameters.Add(new OleDbParameter("@CONTRATO_NO", OleDbType.VarChar));
            ORDENU.Parameters["@CONTRATO_NO"].Value = con_no;

            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
        }
    }
}
