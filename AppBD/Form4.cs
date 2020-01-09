using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using AppBD.Clases;
using System.Collections;
namespace AppBD
{
    public partial class Form4 : Form
    {
        Contratista contratista = new Contratista();
        string ruta;
        public Form4(string ruta)
        {
            this.ruta = ruta;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            /*
           
            else
            {
                MessageBox.Show("error de cédula o contraseña");
                textBox1.Text = "";
                textBox2.Text = "";
            }*/
        }
    }
}
