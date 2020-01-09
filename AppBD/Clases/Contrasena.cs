using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace AppBD.Clases
{
    public class Contrasena
    {
        public Conexion con = new Conexion();
        public DataSet TABLA;
        DataTable dt = new DataTable();
        public OleDbDataAdapter ORDEN;
        private string resulultVali="";
        private string valor1 = "";
        private string valor2 = "";

        public void consultarCrede(string consulta)
        {

            con.conectar();
            resulultVali = con.result.ToString();

            if (resulultVali.Equals("ok"))
            {
                ORDEN = new OleDbDataAdapter(" SELECT * FROM [CONTRASENAS]" +
            "WHERE CEDULA =@CLABUSCAR", con.CANAL);
                ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.VarChar));
                ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = consulta;
                dt = new DataTable();
                TABLA = new DataSet();
                ORDEN.Fill(TABLA);
                dt = TABLA.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    valor1 = Convert.ToString(row["CONTRASENA"]);
                    
                }
                foreach (DataRow row in dt.Rows)
                {
                    valor2 = Convert.ToString(row["CEDULA"]);
                    
                }
                

            }

         
        }
        public string USU
        {
            
            get { return valor2; }
        }
        public string CLA
        {
          
            get { return valor1; }
        }



    }
}
