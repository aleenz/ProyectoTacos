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
    public partial class ModificarUsuarios : Form
    {
        String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        Usuario actual;
        Form antiguo;
        public ModificarUsuarios(Usuario u, Form antiguo)
        {
            this.antiguo = antiguo;
            actual = u;
            InitializeComponent();
            TXTNombreUsuario.Text = u.Nombre;
            CBXRol.SelectedIndex = u.Rol;
            TXTDireccion.Text = u.Persona.Domicilio.Calle;
            TXTColonia.Text = u.Persona.Domicilio.Colonia;
            TXTCP.Text = u.Persona.Domicilio.CP;
            TXTTelefono.Text = u.Persona.Telefono;
            if(u.Persona is Cliente)
            {
                TXTEmail.Text = (u.Persona as Cliente).Email;
                
            }
            TXTNombre.Text = u.Persona.Nombre;
            TXTApaterno.Text = u.Persona.Apaterno;
            TXTAmaterno.Text = u.Persona.Amaterno;
            switch (u.Persona.Genero)
            {
                case "Masculino":
                    CBXGenero.SelectedIndex = 0;
                    break;
                case "Femenino":
                    CBXGenero.SelectedIndex = 1;
                    break;
                case "Otro":
                    CBXGenero.SelectedIndex = 2;
                    break;
            }
            for (int i = 1; i <= 31; i++) this.CBXDia.Items.Add(i);
            foreach (String mes in meses) this.CBXMes.Items.Add(mes);
            for (int i = 2018; i >= 1800; i--) this.CBXAno.Items.Add(i);



            CBXDia.SelectedIndex = u.Persona.FechaNac.Day - 1;
            CBXMes.SelectedIndex = u.Persona.FechaNac.Month - 1;
            CBXAno.SelectedIndex = (2018 - u.Persona.FechaNac.Year);
        }

        private void ModificarUsuarios_Load(object sender, EventArgs e)
        {
           

            
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (TXTNombreUsuario.Text == "" 
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
                    if (TXTEmail.Text == "")
                    {
                        MessageBox.Show("Debe llenar todos los campos");
                        return;
                    }
                    Cliente p = new Cliente();
                    p.IdPersona = actual.Persona.IdPersona;
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

                    user.Nombre = TXTNombreUsuario.Text;
                    user.IdUsuario = actual.IdUsuario;
                    user.Rol = 0;
                    user.Persona = p;

                    

                }
                else
                {
                    Empleado p = new Empleado();
                    p.IdPersona = actual.Persona.IdPersona;

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


                    user.IdUsuario = actual.IdUsuario;

                    user.Nombre = TXTNombreUsuario.Text;
                    user.Rol = CBXRol.SelectedIndex;
                    user.Persona = p;
                }



                UsuarioBeans u_beans = new UsuarioBeans();
                Error er;

                if (TXTContrasena1.Text == "")
                {
                    er = u_beans.modificarUsuario(user);
                }
                else
                {
                   er = u_beans.modificarUsuario(user,Usuario.toMD5(TXTContrasena1.Text));
                }



                if (er != null) MessageBox.Show(er.Descripcion);
                else MessageBox.Show("Registro Actualizado correctamente");

                this.Close();
                antiguo.Update();

                antiguo.Show();
            }
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
            antiguo.Show();

            
        }
    }
}
