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
    public partial class Form5 : Form
    {
        
        public Contrasena contra = new Contrasena();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            contra.con.ruta = textBox3.Text;
            contra.consultarCrede(textBox1.Text);
            string pas1= contra.CLA;
            string pas2= contra.USU;
            if (pas1.Equals(textBox2.Text) && pas2.Equals(textBox1.Text)) {
                button1.Enabled = false;
                Form opciones = new Form1(textBox3.Text);
                
                opciones.ShowDialog();

            }
            else
            {
                MessageBox.Show("error de cédula o contraseña");
                textBox1.Text = "";
                textBox2.Text = "";
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            contra.con.ruta = textBox3.Text;
            contra.con.conectar();
            if (contra.con.result.Equals("ok")) { button1.Enabled = true; MessageBox.Show("Ubicació encontrada"); }
            else { MessageBox.Show("EL archivo no existe"); }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
