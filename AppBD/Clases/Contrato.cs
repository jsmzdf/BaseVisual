using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace AppBD.Clases
{   
    class Contrato
    {
        public Conexion con = new Conexion();
        public DataSet TABLA;
        public OleDbDataAdapter ORDEN;
        DataTable dt = new DataTable();
        public string cod = "";
        OleDbCommand ORDENU;
        public void consultarC(string consulta)
        {
            
            
            con.conectar();
            ORDEN = new OleDbDataAdapter("SELECT * FROM [CONTRATO] WHERE CONTRATO_NO =@CLABUSCAR", con.CANAL);
            ORDEN.SelectCommand.Parameters.Add(new OleDbParameter("@CLABUSCAR", OleDbType.VarChar));
            ORDEN.SelectCommand.Parameters["@CLABUSCAR"].Value = consulta;
            TABLA = new DataSet();
            ORDEN.Fill(TABLA);
            dt = TABLA.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                cod = Convert.ToString(row["CONTRATO_NO"]);

            }

        }
        public void updateC()
        {



            /*con.conectar();
            string q = "update  [CONTRATO] set Placa = @PLACA,CapacidadPuestos=@CAPACIDADPUESTOS,Vacantes=@VACANTES where NumeroBus=" + textBox1.Text;
            ORDENU = new OleDbCommand(q, con.CANAL);
            
            ORDENU.Parameters.Add(new OleDbParameter("@PLACA", OleDbType.VarWChar, 6));
            ORDENU.Parameters["@PLACA"].Value = textBox2.Text;
            ORDENU.Parameters.Add(new OleDbParameter("@CAPACIDADPUESTOS", OleDbType.Integer));
            ORDENU.Parameters["@CAPACIDADPUESTOS"].Value = int.Parse(textBox3.Text);
            ORDENU.Parameters.Add(new OleDbParameter("@VACANTES", OleDbType.Integer));
            ORDENU.Parameters["@VACANTES"].Value = int.Parse(textBox3.Text);
            */

            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
        }
        public void addC(string con_no,string con_secop,int ano, string ubicacion,string caprtas,
            string sed_no,string obj,int plazoDias,double contratovalor,string interventor)
        {
            
            string q = "INSERT INTO [CONTRATO](CONTRATO_NO,CONTRATO_SECOP,[AÑO],[UBICACIÓN],CARPETAS_NO,SED_NO,OBJETO,PLAZO_DIAS,CONTRATO_VALOR,INTERVENTOR) " +
                "values(@CONTRATO_NO,@CONTRATO_SECOP,@ANO,@UBICACION,@CARPETAS_NO,@SED_NO,@OBJETO,@PLAZO_DIAS,@CONTRATO_VALOR,@INTERVENTOR)";
            ORDENU = new OleDbCommand(q, con.CANAL);
            ORDENU.Parameters.Add(new OleDbParameter("@CONTRATO_NO", OleDbType.VarChar));
            ORDENU.Parameters["@CONTRATO_NO"].Value = con_no;
            ORDENU.Parameters.Add(new OleDbParameter("@CONTRATO_SECOP", OleDbType.VarChar));
            ORDENU.Parameters["@CONTRATO_SECOP"].Value = con_secop;
            ORDENU.Parameters.Add(new OleDbParameter("@ANO", OleDbType.Numeric));
            ORDENU.Parameters["@ANO"].Value = ano;
            ORDENU.Parameters.Add(new OleDbParameter("@UBICACION", OleDbType.VarChar));
            ORDENU.Parameters["@UBICACION"].Value = ubicacion;
            ORDENU.Parameters.Add(new OleDbParameter("@CARPETAS_NO", OleDbType.VarChar));
            ORDENU.Parameters["@CARPETAS_NO"].Value = caprtas;
            ORDENU.Parameters.Add(new OleDbParameter("@SED_NO", OleDbType.VarChar));
            ORDENU.Parameters["@SED_NO"].Value = sed_no;
            ORDENU.Parameters.Add(new OleDbParameter("@OBJETO", OleDbType.VarChar));
            ORDENU.Parameters["@OBJETO"].Value = obj;
            ORDENU.Parameters.Add(new OleDbParameter("@PLAZO_DIAS", OleDbType.VarChar));
            ORDENU.Parameters["@PLAZO_DIAS"].Value = plazoDias;
            ORDENU.Parameters.Add(new OleDbParameter("@CONTRATO_VALOR", OleDbType.Double));
            ORDENU.Parameters["@CONTRATO_VALOR"].Value = contratovalor;
            ORDENU.Parameters.Add(new OleDbParameter("@INTERVENTOR", OleDbType.VarChar));
            ORDENU.Parameters["@INTERVENTOR"].Value = interventor;
            ORDENU.Connection.Open();
            ORDENU.ExecuteNonQuery();
            ORDENU.Connection.Close();
            
        }
    }
}
