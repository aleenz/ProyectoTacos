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
using ProyectoTacos.Modelos;
namespace ProyectoTacos.Vistas
{
    public partial class RegistrarCliente : Form
    {
        String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };


        Form antiguo;
        public RegistrarCliente(Form antiguo)
        {
            InitializeComponent();
            this.antiguo = antiguo;
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            for (int i = 1; i <= 31; i++) this.CBXDia.Items.Add(i);
            foreach(String mes in meses) this.CBXMes.Items.Add(mes);
            for (int i = 2018; i >= 1800; i--) this.CBXAno.Items.Add(i);

            CBXDia.SelectedIndex = 0;
            CBXMes.SelectedIndex = 0;
            CBXGenero.SelectedIndex = 0;
            CBXAno.SelectedIndex = 0;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            antiguo.Show();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (TXTNombreUsuario.Text == "" || TXTContrasena1.Text == "" || TXTContrasena2.Text == ""
                || TXTNombre.Text == "" || TXTApaterno.Text == "" || TXTAmaterno.Text == ""
                || CBXGenero.Text == "" || TXTDireccion.Text == "" || TXTColonia.Text == ""
                || TXTCP.Text == "" || TXTTelefono.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (TXTContrasena1.Text != TXTContrasena2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                Persona p = new Persona();
                p.Nombre = TXTNombre.Text;
                p.Apaterno = TXTApaterno.Text;
                p.Amaterno = TXTAmaterno.Text;
                p.Genero = CBXGenero.Text;
                p.Telefono = TXTTelefono.Text;
                p.FechaNac = new DateTime(Convert.ToInt16(CBXAno.Text), CBXMes.SelectedIndex+1, Convert.ToInt16(CBXDia.Text));
                Domicilio d = new Domicilio();
                d.Calle = TXTDireccion.Text;
                d.Colonia = TXTColonia.Text;
                d.CP = TXTCP.Text;


                p.Domicilio = d;

                Usuario user = new Usuario();
                user.Nombre = TXTNombreUsuario.Text;
                user.Rol = 0;
                user.Persona = p;

                UsuarioBeans u_beans = new UsuarioBeans();
                Error er = u_beans.RegistroCliente(user, Usuario.toMD5(TXTContrasena1.Text));
                if (er != null) MessageBox.Show(er.Descripcion);

                antiguo.Show();
                this.Close();
            }


           


        }
    }
}
