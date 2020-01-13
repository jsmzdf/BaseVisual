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
    public partial class Form3 : Form
    {
        public DataSet TABLA;
        Conexion con = new Conexion();
        Prestamo prestamo = new Prestamo();
        Contrato contrato = new Contrato();
        ContratisContrato contricon = new ContratisContrato();
        Contratista contratista = new Contratista();
        string ruta;
        
        public Form3(string ruta)
        {
            this.ruta = ruta;
            contratista.con.ruta = this.ruta;
            contrato.con.ruta = this.ruta;
            prestamo.con.ruta = this.ruta;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                button5.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;

                contrato.consultarC(textBox1.Text);
                textBox17.Text = contrato.objeto;
                contrato.TABLA = new DataSet();
                contrato.ORDEN.Fill(contrato.TABLA, "CONTRATO");
                dataGridView1.DataSource = contrato.TABLA;
                dataGridView1.DataMember = "CONTRATO";

                
                prestamo.consultarP(textBox1.Text);
                prestamo.TABLA = new DataSet();
                prestamo.ORDEN.Fill(prestamo.TABLA, "Prestamo");
                dataGridView2.DataSource = prestamo.TABLA;
                dataGridView2.DataMember = "Prestamo";

                
                contratista.consultarContratisa(textBox1.Text);
                label15.Text = contratista.nombre;
                label16.Text = contratista.id;
            } catch (Exception) { MessageBox.Show("Ingrese valoes correctos", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;


            con.conectar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            button5.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;


            con.conectar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {

                bool exixtencia = true;
                
                contratista.consutaexistencia(textBox12.Text);
                contrato.consultarC(textBox2.Text);
                string cc = contratista.id;
                ArrayList nombres = contratista.nombres;

                if (contrato.cod == textBox2.Text)
                {
                    MessageBox.Show("El número de contrato ya exixte");
                }
                else
                {
                    if (cc == textBox12.Text)
                    {
                        for (int i = 0; i < nombres.Count; i++)
                        {
                            if (nombres[i].ToString() == textBox13.Text)
                            {

                                contratista.consultarID(textBox13.Text, Double.Parse(textBox12.Text));

                                MessageBoxButtons sino = MessageBoxButtons.YesNo;
                                DialogResult accion = MessageBox.Show("¿Quiere realizar acción?", "", sino, MessageBoxIcon.Question);
                                if (accion == DialogResult.Yes)
                                {
                                    try
                                    {
                                        contrato.addC(textBox2.Text, textBox3.Text, int.Parse(textBox5.Text), textBox4.Text,
                                             textBox7.Text, textBox6.Text, textBox9.Text, int.Parse(textBox8.Text),
                                             Double.Parse(textBox11.Text), textBox10.Text);
                                        contricon.con.ruta = this.ruta;
                                        contricon.addConContri(double.Parse(contratista.cod), textBox2.Text);
                                        MessageBox.Show("Se Agregó un nuevo contrato");
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Ingrese valoes correctos", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                else { break; }



                            }
                            else { exixtencia = false; }
                        }
                    }
                    else { exixtencia = false; }
                    if (textBox12.Text != "" && textBox13.Text != "" || exixtencia == false)
                    {

                        MessageBoxButtons sino = MessageBoxButtons.YesNo;
                        DialogResult accion = MessageBox.Show("¿Quiere realizar acción?", "", sino, MessageBoxIcon.Question);
                        if (accion == DialogResult.Yes)
                        {
                            try
                            {

                                contrato.addC(textBox2.Text, textBox3.Text, int.Parse(textBox5.Text), textBox4.Text,
                                            textBox7.Text, textBox6.Text, textBox9.Text, int.Parse(textBox8.Text),
                                            Double.Parse(textBox11.Text), textBox10.Text);
                                contratista.obetenerUltimoID();
                                contratista.agregarContratista(double.Parse(textBox12.Text), textBox13.Text);

                                contricon.con.ruta = this.ruta;
                                contricon.addConContri(double.Parse(contratista.cod), textBox2.Text);
                                MessageBox.Show("Se Agregó un nuevo contrato");


                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ingrese valoes correctos", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
    
                        }




                    }
                }


            }
            catch (Exception) {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
            textBox1.Text = "";
            textBox5.Text = "";
            textBox15.Text = "";
            textBox8.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
                button5.Enabled = false;
                
                MessageBoxButtons sino = MessageBoxButtons.YesNo;
                DialogResult accion = MessageBox.Show("¿Quiere realizar acción?", "", sino, MessageBoxIcon.Question);
                if (accion == DialogResult.Yes)
                {
                    contrato.updateC(textBox16.Text, textBox15.Text, textBox14.Text);
                    textBox14.Enabled = true;
                }
                else
                {
                }
            try
            {
            } catch (Exception)
            {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
            textBox1.Text = "";
            textBox5.Text = "";
            textBox15.Text = "";
            textBox8.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            try
            {
                
                contrato.consultarC(textBox14.Text);
                
                contrato.TABLA = new DataSet();
                contrato.ORDEN.Fill(contrato.TABLA, "CONTRATO");
                dataGridView3.DataSource = contrato.TABLA;
                dataGridView3.DataMember = "CONTRATO";
                if (contrato.cod == textBox14.Text) {
                    textBox14.Enabled = false;
                        button5.Enabled = true; }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
