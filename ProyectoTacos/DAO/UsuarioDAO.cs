using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;

namespace ProyectoTacos.DAO
{
    class UsuarioDAO:ConexionDAO
    {


        SqlCommand cmd = new SqlCommand();


      
        public Usuario IniciarSesion(string usuario, string contrasena)
        {
            Usuario u = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select usuario, rol, persona from usuario where usuario ='" + usuario + "' and contrasena = '" + Usuario.toMD5(contrasena) + "' ";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        u = new Usuario();
                        u.Nombre = rdr.GetString(1);
                        u.Rol = rdr.GetInt16(2);
                        PersonaBeans p_beans = new PersonaBeans();
                        u.Persona = p_beans.getPersona(rdr.GetInt16(3));

                    }
                    Usuario.Activo = u;

                }
                Con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return u;
        }



       






    }
}

