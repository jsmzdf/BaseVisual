using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBD.Clases;
namespace AppBD
{
    public partial class Form2 : Form
    {
        public DataSet TABLA;
        Conexion con = new Conexion();
        Prestamo prestamo = new Prestamo();
        Contrato contrato = new Contrato();
        PrestamoContrato presCon = new PrestamoContrato();
        
        string ruta;
        public Form2(string ruta)
        {
            this.ruta = ruta;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //bool exixtencia = true;
                
                contrato.con.ruta = this.ruta;
                contrato.consultarC(textBox1.Text);
                prestamo.con.ruta = this.ruta;
                prestamo.consultarP(textBox1.Text);
                if (contrato.cod==textBox1.Text)
                {
                    
                    Console.WriteLine("existe");
                }
                else
                {
                    MessageBox.Show("El Contrato no existe");
                }
                
            }
            catch (Exception) {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
        }
    }
}
