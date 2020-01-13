using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace AppBD.Clases
{
    class Contratista
    {

        public Conexion con = new Conexion();
        public DataSet TABLA;
        public OleDbDataAdapter ORDEN;
        DataTable dt;
        OleDbCommand ORDENU;
        public string cod;
        public string id;
        public string nombre;
        public ArrayList nombres = new ArrayList();
        public void consultarContratisa(string consulta)
        {
            
            con.conectar();
            ORDEN = new OleDbDataAdapter(" SELECT CONTRATISTA.ID_CONTRATISTA, " +
                "NOMBRE_CONTRATISTA1, IDENTIFICACION FROM [CONTRATO]" +
                " INNER JOIN ([CONTRATISTA_CONTRATO]  INNER JOIN [CONTRATISTA]" +
                " ON [CONTRATISTA_CONTRATO].ID_CONTRATISTA=[CONTRATISTA].ID_CONTRATISTA) " +
                " ON [CONTRATO].CONTRATO_NO=[CONTRATISTA_CONTRATO].CONTRATO_NO "+
                "WHERE [CONTRATO].CONTRATO_NO =@CLABUSCAR", con.CANAL);
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.VarWChar));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = consulta;
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                id = Convert.ToString(row["IDENTIFICACION"]);

            }
            foreach (DataRow row in dt.Rows)
            {
                nombre = Convert.ToString(row["NOMBRE_CONTRATISTA1"]);

            }
        }

        public void consutaexistencia(string consulta) {
         
            string consultaSoloContratista = "SELECT NOMBRE_CONTRATISTA1, IDENTIFICACION FROM [CONTRATISTA] WHERE IDENTIFICACION =@CLABUSCAR";
            con.conectar();
            ORDEN = new OleDbDataAdapter(consultaSoloContratista, con.CANAL);
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.VarChar));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = consulta;
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                id = Convert.ToString(row["IDENTIFICACION"]);

            }
            foreach (DataRow row in dt.Rows)
            {
                nombres.Add( Convert.ToString(row["NOMBRE_CONTRATISTA1"]));

            }
        }
        public void consultarID(string nombrec, double id) {

            string consultaSoloContratista = "SELECT ID_CONTRATISTA FROM [CONTRATISTA] WHERE IDENTIFICACION =@CLABUSCAR " +
                "AND NOMBRE_CONTRATISTA1=@CLABUSCAR1";
            con.conectar();
            ORDEN = new OleDbDataAdapter(consultaSoloContratista, con.CANAL);
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.Double));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = id;
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR1", OleDbType.VarChar));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR1"].Value = nombrec;
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                cod = Convert.ToString(row["ID_CONTRATISTA"]);

            }

        }


        public void obetenerUltimoID() {

            con.conectar();
            string q0 = "SELECT ID_CONTRATISTA, NOMBRE_CONTRATISTA1, IDENTIFICACION FROM CONTRATISTA";
            ORDEN = new OleDbDataAdapter(q0, con.CANAL);
            dt = new DataTable();
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];
            double codenumero=0;
            double aux = 0;
            foreach (DataRow row in dt.Rows)
            {
                cod = Convert.ToString(row["ID_CONTRATISTA"]);
                codenumero = double.Parse(cod);
                if (aux < codenumero) { aux = codenumero; }

            }
            cod = (aux + 1).ToString();
            
        }
        public void agregarContratista(double cedula,string nombre)
        {
            con.conectar();
            
            string q = "INSERT INTO [CONTRATISTA](ID_CONTRATISTA,IDENTIFICACION,NOMBRE_CONTRATISTA1) " +
            "values(@ID,@CEDULA,@NOMBRE)";
            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@ID", OleDbType.Double));
            ORDENU.Parameters["@ID"].Value = cod;
            ORDENU.Parameters.Add(new OleDbParameter("@CEDULA", OleDbType.Double));
            ORDENU.Parameters["@CEDULA"].Value = cedula;
            ORDENU.Parameters.Add(new OleDbParameter("@NOMBRE", OleDbType.VarChar));
            ORDENU.Parameters["@NOMBRE"].Value = nombre;
            
            
            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
            
        }
        

    }
}

