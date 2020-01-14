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
        public string idRef;
        public string estado;
        public string id;

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
                idRef=  Convert.ToString(row["ID_PRESTAMO"]);

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

        public void updateP(double consulta)
        {
            con.conectar();
            string q = "update  [PRESTAMOS_DEVOLUCIONES] set [FECHA_DEVOLUCION] = @FECHAACT, " +
                "ESTADO = @CNO where ID_PRESTAMO= @CONSULTA";
            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@FECHAACT", OleDbType.Date));
            ORDENU.Parameters["@FECHAACT"].Value = DateTime.Now;
            ORDENU.Parameters.Add(new OleDbParameter("@CNO", OleDbType.VarChar));
            ORDENU.Parameters["@CNO"].Value = "DEVUELTO";
            ORDENU.Parameters.Add(new OleDbParameter("@CONSULTA", OleDbType.Double));
            ORDENU.Parameters["@CONSULTA"].Value = consulta;



            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
        }
        public void generarPR(double idPrestamo,string funcionarioContratista, string dependencia, string quienPresta,
            string motivoPrestamo,string numeroCarpetas,string observaciones)
        {
            
            string q = "INSERT INTO [PRESTAMOS_DEVOLUCIONES](ID_PRESTAMO,FECHA_PRESTAMO," +
                "FUNCIONARIO_CONTRATISTA,DEPENDENCIA,ESTADO,QUIEN_PRESTA,MOTIVO_PRESTAMO," +
                "NO_CARPETAS,OBSERVACIONES,FECHA_ACTUAL) " +
                "values(@IDPRES,@FEHCAPRES,@FUNCONTRA," +
                "@DEPENDEN,@ESTADO,@QUIENPRES," +
                "@MOTIVOPRES,@NOCARPE,@BOSER,@FECHAACT)";

            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@IDPRES", OleDbType.Double));
            ORDENU.Parameters["@IDPRES"].Value = idPrestamo;
            ORDENU.Parameters.Add(new OleDbParameter("@FEHCAPRES", OleDbType.Date));
            ORDENU.Parameters["@FEHCAPRES"].Value = DateTime.Now;
            ORDENU.Parameters.Add(new OleDbParameter("@FUNCONTRA", OleDbType.VarChar));
            ORDENU.Parameters["@FUNCONTRA"].Value = funcionarioContratista;
            ORDENU.Parameters.Add(new OleDbParameter("@DEPENDENCIA", OleDbType.VarChar));
            ORDENU.Parameters["@DEPENDENCIA"].Value = dependencia;
            ORDENU.Parameters.Add(new OleDbParameter("@ESTADO", OleDbType.VarChar));
            ORDENU.Parameters["@ESTADO"].Value = "PRESTADO";
            ORDENU.Parameters.Add(new OleDbParameter("@QUIENPRES", OleDbType.VarChar));
            ORDENU.Parameters["@QUIENPRES"].Value = quienPresta;
            ORDENU.Parameters.Add(new OleDbParameter("@MOTIVOPRES", OleDbType.VarChar));
            ORDENU.Parameters["@MOTIVOPRES"].Value = motivoPrestamo;
            ORDENU.Parameters.Add(new OleDbParameter("@NOCARPE", OleDbType.VarChar));
            ORDENU.Parameters["@NOCARPE"].Value = numeroCarpetas;
            ORDENU.Parameters.Add(new OleDbParameter("@BOSER", OleDbType.VarChar));
            ORDENU.Parameters["@BOSER"].Value = observaciones;
            ORDENU.Parameters.Add(new OleDbParameter("@FECHAACT", OleDbType.Date));
            ORDENU.Parameters["@FECHAACT"].Value = DateTime.Now;
            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
            

        }
        public void obetenerUltimoID()
        {

            con.conectar();
            string q0 = "SELECT ID_PRESTAMO FROM [PRESTAMOS_DEVOLUCIONES]";
            ORDEN = new OleDbDataAdapter(q0, con.CANAL);
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];
            double codenumero = 0;
            double aux = 0;
            foreach (DataRow row in dt.Rows)
            {
                id = Convert.ToString(row["ID_PRESTAMO"]);
                codenumero = double.Parse(id);
                if (aux < codenumero) { aux = codenumero; }

            }
            id = (aux + 1).ToString();
            
        }
    }
}
