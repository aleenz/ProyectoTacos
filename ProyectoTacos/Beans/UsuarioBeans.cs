using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
namespace ProyectoTacos.Beans
{
    class UsuarioBeans
    {
        private List<Usuario> lst_usuarios = new List<Usuario>();
        internal List<Usuario> Lst_Usuarios { get => lst_usuarios; set => lst_usuarios = value; }

        public bool IniciarSesion(string usuario, string contrasena)
        {
            UsuarioDAO usuarioDAO;
            try
            {
                usuarioDAO = new UsuarioDAO();
                Usuario u = usuarioDAO.IniciarSesion(usuario, contrasena);
                if (u != null) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;

                throw;
            }
        }

        public Error RegistroCliente(Usuario user, string contrasena)
        {
            UsuarioDAO usuarioDAO;
            Error er = null;
            try
            {
                usuarioDAO = new UsuarioDAO();
                er = usuarioDAO.RegistrarUsuario(user, contrasena);
                
            }
            catch (SqlException)
            {

                throw;
            }
            return er;
        }

        public void listar()
        {
            UsuarioDAO usuarioDAO;
            try
            {
                usuarioDAO = new UsuarioDAO();
                lst_usuarios = usuarioDAO.listar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaract()
        {
            UsuarioDAO usuarioDAO;
            try
            {
                usuarioDAO = new UsuarioDAO();
                lst_usuarios = usuarioDAO.listaract();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void buscar(string por, string str)
        {
            UsuarioDAO usuarioDAO;
            try
            {
                usuarioDAO = new UsuarioDAO();
                lst_usuarios = usuarioDAO.buscar( por,  str);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Usuario buscarId(int id)
        {
            UsuarioDAO usuarioDAO;
            try
            {
                usuarioDAO = new UsuarioDAO();
                return usuarioDAO.buscarId(id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }


        public Error modificarUsuario(Usuario nuevo)
        {
            UsuarioDAO usuarioDAO;
            Error er;
            try
            {
                usuarioDAO = new UsuarioDAO();
                er = usuarioDAO.modificarUsuario(nuevo);
               
               
            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }

        public Error modificarUsuario(Usuario nuevo, string pass)
        {
            UsuarioDAO usuarioDAO;
            Error er;
            try
            {
                usuarioDAO = new UsuarioDAO();
                er = usuarioDAO.modificarUsuario(nuevo, pass);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }

        public Error eliminar(Usuario nuevo)
        {
            UsuarioDAO usuarioDAO;
            Error er;
            try
            {
                usuarioDAO = new UsuarioDAO();
                er = usuarioDAO.eliminar(nuevo);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }

        public Error activar(Usuario nuevo)
        {
            UsuarioDAO usuarioDAO;
            Error er;
            try
            {
                usuarioDAO = new UsuarioDAO();
                er = usuarioDAO.activar(nuevo);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }
    }
    
}

