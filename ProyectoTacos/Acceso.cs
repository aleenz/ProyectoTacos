using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Beans;
namespace ProyectoTacos
{
    public partial class FRMAcceso : Form
    {
        public FRMAcceso()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }









       


        private void clean()
        {
            this.TXTUsuario.Text = "";
            this.TXTContrasena.Text = "";
        }

        private void BTNAcceder_Click(object sender, EventArgs e)
        {

            UsuarioBeans usuario_beans = new UsuarioBeans();
            string usuario = TXTUsuario.Text;
            string contrasena = TXTContrasena.Text;


            if(usuario=="" || contrasena == "")
            {
                MessageBox.Show("Debe introducir un nombre de usuario y una contraseña");
            }
            else
            {
                if(usuario_beans.IniciarSesion(TXTUsuario.Text, TXTContrasena.Text))
                {
                    MessageBox.Show("Debe introducir un nombre de usuario y una contraseña");

                }
                else
                {
                    MessageBox.Show("EW");

                }
            }
            
        }
    }
}
