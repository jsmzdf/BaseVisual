﻿using System;
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
            contrato.con.ruta = this.ruta;
            prestamo.con.ruta = this.ruta;
            presCon.con.ruta = this.ruta;
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
            button8.Enabled = false;
            textBox1.Enabled = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button8.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                MessageBoxButtons sino = MessageBoxButtons.YesNo;
                DialogResult accion = MessageBox.Show("¿Quiere realizar acción?", "", sino, MessageBoxIcon.Question);
                if (accion == DialogResult.Yes)
                {
                    prestamo.obetenerUltimoID();
                    prestamo.generarPR(double.Parse(prestamo.id), textBox2.Text, textBox3.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                    presCon.addConPRes(double.Parse(prestamo.id), textBox1.Text);
                    textBox1.Enabled = true;
                    button6.Enabled = false;
                    label4.Text = "---";
                    button1.Enabled = false;
                    button6.Enabled = false;
                    MessageBox.Show("Se ha generado el préstamo");
                }
                else
                {
                    textBox1.Text = "";
                    button8.Enabled = true;
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                   
                  


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
            textBox1.Text = "";
            button8.Enabled = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            contrato.consultarC(textBox1.Text);
            try
            {
                //bool exixtencia = true;

                
              
                
                prestamo.consultarP(textBox1.Text);
                if (contrato.cod == textBox1.Text)
                {

                    Console.WriteLine("existe");
                    
                    button3.Enabled = true;
                    prestamo.TABLA = new DataSet();
                    prestamo.ORDEN.Fill(prestamo.TABLA, "Prestamo");
                    dataGridView2.DataSource = prestamo.TABLA;
                    dataGridView2.DataMember = "Prestamo";
                    if (prestamo.estado=="PRESTADO") {
                        MessageBox.Show("El contrato se encuentra prestado se puede hacer una devolución");
                        label4.Text = prestamo.idRef;
                        button6.Enabled = false;
                        button3.Enabled = true;
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Puede prestar el contrato");
                        button1.Enabled = true;
                        button6.Enabled = true;
                        button3.Enabled = false;
                    }
                }
                else
                {

                    MessageBox.Show("El Contrato no existe");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            
                try
                {
                    MessageBoxButtons sino = MessageBoxButtons.YesNo;
                    DialogResult accion = MessageBox.Show("¿Quiere realizar acción?", "", sino, MessageBoxIcon.Question);
                    if (accion == DialogResult.Yes)
                    {
                    prestamo.updateP(double.Parse( prestamo.idRef));
                    textBox1.Enabled = true;
                    button3.Enabled = false;
                    MessageBox.Show("Se ha hecho la devolución");
                }
                    else
                    {
                        textBox1.Text = "";
                        button8.Enabled = true;
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        label4.Text = "---";
                    button2.Enabled = false;
                    button3.Enabled = false;
                       



                    }
                }
                catch (Exception)
                {
                MessageBox.Show("Verifique que no esten modificando propiedades de la base o que no hayan movido en archcivo de lugar");

            }
            textBox1.Text = "";
            button8.Enabled = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            

        }
    }
}
