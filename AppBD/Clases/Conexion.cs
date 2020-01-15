using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
namespace AppBD.Clases
{
   public class Conexion
    {
        public string ruta;
        public string result;
       public OleDbConnection CANAL;
       
        
        public void conectar() {
            string curFile = @""+ruta;
             result=File.Exists(curFile) ? "ok" : "fail";

            if (result.Equals("ok")) {
             
                CANAL = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta+
                    "; Jet OLEDB:Database Password=admindatabase2.0");
            }
           
           
        }

        
    }
}
