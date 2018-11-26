using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;
using System.Windows.Forms;

namespace ProyectoTacos.DAO
{
    class UsuarioDAO:ConexionDAO
    {


        SqlCommand cmd = new SqlCommand();



        public Usuario IniciarSesion(string usuario, string contrasena)
        {
            SqlDataReader rdr;

            Usuario u = null;
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

        private bool nombreExiste(string usuario)
        {
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select * from usuario where usuario ='" + usuario + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows) return true;
                else return false;


            }
            catch (SqlException)
            {
                return false;
                throw;
            }
            finally
            {
                Con.Close();
            }
            
        }

        public Error RegistrarUsuario(Usuario u, string contrasena)
        {
            Error er = null;
            SqlDataReader rdr;

            if (!nombreExiste(u.Nombre))
            {
                try
                {
                    string SQL;
                    conectar();
                    SQL = "INSERT into persona(nombre,apaterno,amaterno,fechanac,genero,telefono,cp,domicilio,colonia)" +
                        " values(@nombre,@apaterno,@amaterno,@fechanac,@genero,@telefono,@cp,@domicilio,@colonia)";
                    Con.Open();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@nombre", u.Persona.Nombre);
                    cmd.Parameters.AddWithValue("@apaterno", u.Persona.Apaterno);
                    cmd.Parameters.AddWithValue("@amaterno", u.Persona.Amaterno);
                    cmd.Parameters.AddWithValue("@fechanac", u.Persona.FechaNac);
                    cmd.Parameters.AddWithValue("@genero", u.Persona.Genero);
                    cmd.Parameters.AddWithValue("@telefono", u.Persona.Telefono);
                    cmd.Parameters.AddWithValue("@cp", u.Persona.Domicilio.CP);
                    cmd.Parameters.AddWithValue("@domicilio", u.Persona.Domicilio.Calle);
                    cmd.Parameters.AddWithValue("@colonia", u.Persona.Domicilio.Colonia);



                    cmd.ExecuteNonQuery();

                    SQL = "Select top 1 idpersona from persona order by idpersona DESC";
                    cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;
                    rdr = cmd.ExecuteReader();
                    int id = 1;
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = rdr.GetInt32(0);
                        }

                    }
                        rdr.Close();
                    SQL = "INSERT into usuario(usuario,contraseña,rol,idpersona)" +
                        " values(@usuario,@contrasena,@rol,@idpersona)";
                    cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@usuario", u.Nombre);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@rol", u.Rol);
                    cmd.Parameters.AddWithValue("@idpersona", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Exito");

                }
                catch (Exception ex)
                {
                    er = new Error(ex.ToString());
                }
            }
            else er = new Error("El usuario indicado ya existe");


            return er;
        }

       
        }









    
}

