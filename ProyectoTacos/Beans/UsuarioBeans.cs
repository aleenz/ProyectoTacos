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
    }
}
