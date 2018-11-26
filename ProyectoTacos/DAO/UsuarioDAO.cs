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
                SQL = "Select usuario, rol, idpersona from usuario where usuario ='" + usuario + "' and contraseña = '" + Usuario.toMD5(contrasena) + "' ";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        u = new Usuario();
                        u.Nombre = rdr.GetString(0);
                        u.Rol = Convert.ToInt32(rdr.GetString(1));
                        PersonaBeans p_beans = new PersonaBeans();
                        u.Persona = p_beans.getPersona(rdr.GetInt32(2));

                    }
                    Usuario.Activo = u;

                }
                else
                {
                    Console.WriteLine("NO HAY");
                }
                Con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);

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

