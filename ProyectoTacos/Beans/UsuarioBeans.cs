using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
namespace ProyectoTacos.Beans
{
    class UsuarioBeans
    {

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
    }
}
