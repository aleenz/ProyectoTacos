using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Vistas
{
    public partial class ModificarUsuario : Form
    {
        ConsultaUsuarios antiguo;
        String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public ModificarUsuario(ConsultaUsuarios antiguo)
        {
            InitializeComponent();
            
            this.antiguo = antiguo;
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

                Usuario user = new Usuario();
                if (CBXRol.SelectedIndex == 0)
                {
                    if(TXTEmail.Text == "")
                    {
                        MessageBox.Show("Debe llenar todos los campos");
                        return;
                    }
                    Cliente p = new Cliente();
                    p.Nombre = TXTNombre.Text;
                    p.Apaterno = TXTApaterno.Text;
                    p.Amaterno = TXTAmaterno.Text;
                    p.Genero = CBXGenero.Text;
                    p.Telefono = TXTTelefono.Text;
                    p.FechaNac = new DateTime(Convert.ToInt16(CBXAno.Text), CBXMes.SelectedIndex + 1, Convert.ToInt16(CBXDia.Text));
                    Domicilio d = new Domicilio();
                    d.Calle = TXTDireccion.Text;
                    d.Colonia = TXTColonia.Text;
                    d.CP = TXTCP.Text;
                    p.Domicilio = d;
                    p.Email = TXTEmail.Text;
                    p.FechaIng = DateTime.Now;

                    user.Nombre = TXTNombreUsuario.Text;

                    user.Rol = 0;
                    user.Persona = p;
                }
                else
                {
                    Empleado p = new Empleado();
                    p.Nombre = TXTNombre.Text;
                    p.Apaterno = TXTApaterno.Text;
                    p.Amaterno = TXTAmaterno.Text;
                    p.Genero = CBXGenero.Text;
                    p.Telefono = TXTTelefono.Text;
                    p.FechaNac = new DateTime(Convert.ToInt16(CBXAno.Text), CBXMes.SelectedIndex + 1, Convert.ToInt16(CBXDia.Text));
                    Domicilio d = new Domicilio();
                    d.Calle = TXTDireccion.Text;
                    d.Colonia = TXTColonia.Text;
                    d.CP = TXTCP.Text;
                    p.Domicilio = d;
                    p.FechaIng = DateTime.Now;

                    user.Nombre = TXTNombreUsuario.Text;
                    user.Rol = CBXRol.SelectedIndex;
                    user.Persona = p;
                }





               

                UsuarioBeans u_beans = new UsuarioBeans();
                Error er = u_beans.RegistroCliente(user, Usuario.toMD5(TXTContrasena1.Text));
                if (er != null) MessageBox.Show(er.Descripcion);

                this.limpiar();
            }

        }

        private void limpiar()
        {
            foreach(Control x in panel1.Controls)
            {
                if(x is GroupBox)
                {
                    foreach(Control c in x.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                        else if (c is ComboBox)
                        {
                            if (c.Name != "CBXRol") (c as ComboBox).SelectedIndex = 0;

                        }
                    }
                }
                
                
            }
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 31; i++) this.CBXDia.Items.Add(i);
            foreach (String mes in meses) this.CBXMes.Items.Add(mes);
            for (int i = 2018; i >= 1800; i--) this.CBXAno.Items.Add(i);

            CBXDia.SelectedIndex = 0;
            CBXMes.SelectedIndex = 0;
            CBXGenero.SelectedIndex = 0;
            CBXAno.SelectedIndex = 0;
        }

        private void CBXRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBXRol.SelectedIndex == 0)
            {
                TXTEmail.Enabled = true;
            }
            else
            {
                TXTEmail.Enabled = false;
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            antiguo.actualizar();
            antiguo.main.abrirForm(antiguo);
        }
    }
}
