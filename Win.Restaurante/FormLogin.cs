using BL.Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Restaurante
{
    public partial class FormLogin : Form
    {
        SeguridadBL _seguridad; 

        public FormLogin()
        {
            InitializeComponent();
            _seguridad = new SeguridadBL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;
            

            usuario = textBox1.Text;
            contrasena = textBox2.Text;
            

            var resultado = _seguridad.login(usuario, contrasena);

            if (resultado == true) 
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("La contrasena o el usuario esta incorrecto");
            }
            
        }
    }
}
