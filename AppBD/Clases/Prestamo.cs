using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace AppBD.Clases
{
    class Prestamo
    {

        public Conexion con = new Conexion();
        public DataSet TABLA;
        public OleDbDataAdapter ORDEN;
        OleDbCommand ORDENU;
        DataTable dt = new DataTable();
        public string estado;
        public void consultarP(string consulta)
        {
            
            con.conectar();
           ORDEN = new OleDbDataAdapter("SELECT PRESTAMOS_DEVOLUCIONES.ID_PRESTAMO, FECHA_PRESTAMO," +
               "FECHA_DEVOLUCION, FUNCIONARIO_CONTRATISTA, DEPENDENCIA,  QUIEN_PRESTA," +
               "MOTIVO_PRESTAMO, NO_CARPETAS, OBSERVACIONES, DIAS, ESTADO" +
               " FROM [CONTRATO]" +
                " INNER JOIN ([CONTRATO PRESTAMO]  INNER JOIN [PRESTAMOS_DEVOLUCIONES] ON [CONTRATO PRESTAMO].ID_PRESTAMO=[PRESTAMOS_DEVOLUCIONES].ID_PRESTAMO) " +
                " ON [CONTRATO].CONTRATO_NO=[CONTRATO PRESTAMO].CONTRATO_NO " +
                "WHERE [CONTRATO].CONTRATO_NO =@CLABUSCAR", con.CANAL);
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.VarWChar));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = consulta;
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                estado = Convert.ToString(row["ESTADO"]);
                Console.WriteLine(estado);
                if (estado=="PRESTADO")
                {

                    break;
                }
                

            }

        }
        public void actualizarfechaactual()
        {
            con.conectar();
           
            string q = "UPDATE PRESTAMOS_DEVOLUCIONES SET FECHA_ACTUAL=@Fechanueva  ";
            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@Fechanueva", OleDbType.Date));
            ORDENU.Parameters["@Fechanueva"].Value = DateTime.Now;
            
            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
        }
    }
}
