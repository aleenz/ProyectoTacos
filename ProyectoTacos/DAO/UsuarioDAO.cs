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
                SQL = "Select u.usuario, u.rol, u.idpersona from usuario as u inner join persona as p on u.idpersona = p.idpersona where u.usuario ='" + usuario + "' and u.contraseña = '" + Usuario.toMD5(contrasena) + "' and p.status = 1";
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
                    SQL = "INSERT into persona(nombre,apaterno,amaterno,fechanac,genero,telefono,cp,domicilio,colonia,status)" +
                        " values(@nombre,@apaterno,@amaterno,@fechanac,@genero,@telefono,@cp,@domicilio,@colonia,@status)";
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
                    cmd.Parameters.AddWithValue("@status", 1);

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

                    if(u.Rol == 0)
                    {
                        SQL = "INSERT into cliente(email,fechareg,idpersona)" +
                        " values(@email,@fechareg,@idpersona)";
                        cmd = new SqlCommand();
                        cmd.Connection = Con;
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@email", (u.Persona as Cliente).Email);
                        cmd.Parameters.AddWithValue("@fechareg", (u.Persona as Cliente).FechaIng);
                        cmd.Parameters.AddWithValue("@idpersona", id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SQL = "INSERT into empleado(fechaing,idpersona)" +
                       " values(@fechareg,@idpersona)";
                        cmd = new SqlCommand();
                        cmd.Connection = Con;
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@fechareg", (u.Persona as Empleado).FechaIng);
                        cmd.Parameters.AddWithValue("@idpersona", id);
                        cmd.ExecuteNonQuery();
                    }
                    

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

        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM usuario";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Usuario u = new Usuario();
                        u.IdUsuario = rdr.GetInt32(0);
                        u.Nombre = rdr.GetString(1);
                        u.Rol = Convert.ToInt32(rdr.GetString(3));

                       
                       
                        if(u.Rol == 0)
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Cliente c = p_dao.buscarCliente(rdr.GetInt32(4));
                            u.Persona = c;
                            
                        }
                        else
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Empleado e = p_dao.buscarEmpleado(rdr.GetInt32(4));
                            u.Persona = e;
                        }


                        lista.Add(u);
                    }
                }
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return lista;
        }

        public List<Usuario> listaract()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM usuario";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Usuario u = new Usuario();
                        u.IdUsuario = rdr.GetInt32(0);
                        u.Nombre = rdr.GetString(1);
                        u.Rol = Convert.ToInt32(rdr.GetString(3));



                        if (u.Rol == 0)
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Cliente c = p_dao.buscarCliente(rdr.GetInt32(4));
                            u.Persona = c;

                        }
                        else
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Empleado e = p_dao.buscarEmpleado(rdr.GetInt32(4));
                            u.Persona = e;
                        }

                        if(u.Persona.Status == 1)
                        lista.Add(u);
                    }
                }
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return lista;
        }

        public List<Usuario> buscar(string por, string str)
        {
            List<Usuario> lista = new List<Usuario>();
            SqlDataReader rdr;
            try
            {
                bool filtrado = false;
                string SQL;
                conectar();
                if(por != "nombre")
                {
                    SQL = "SELECT * FROM usuario WHERE "+ por + " like'%" + str + "%'";
                    filtrado = true;
                }
                else
                {
                    SQL = "SELECT * FROM usuario";

                }
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Usuario u = new Usuario();
                        u.IdUsuario = rdr.GetInt32(0);
                        u.Nombre = rdr.GetString(1);
                        u.Rol = Convert.ToInt32(rdr.GetString(3));



                        if (u.Rol == 0)
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Cliente c;
                            if(!filtrado) c = p_dao.buscarCliente(rdr.GetInt32(4), por, str);
                            else c = p_dao.buscarCliente(rdr.GetInt32(4));
                            u.Persona = c;

                        }
                        else
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Empleado e;
                            if (!filtrado) e = p_dao.buscarEmpleado(rdr.GetInt32(4), por, str);
                            else e = p_dao.buscarEmpleado(rdr.GetInt32(4));
                            u.Persona = e;
                        }
                        if (u.Persona != null)
                        {
                            lista.Add(u);
                        }

                       
                    }
                }
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return lista;
        }

        public Usuario buscarId(int id)
        {
            Usuario u = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM usuario where idusuario = " + id +";";
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
                        u.Rol = Convert.ToInt32(rdr.GetString(3));
                        u.IdUsuario = rdr.GetInt32(0);


                        if (u.Rol == 0)
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Cliente c = p_dao.buscarCliente(rdr.GetInt32(4));
                            u.Persona = c;

                        }
                        else
                        {
                            PersonaDAO p_dao = new PersonaDAO();
                            Empleado e = p_dao.buscarEmpleado(rdr.GetInt32(4));
                            u.Persona = e;
                        }


                        
                    }
                }
                Con.Close();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return u;
        }

        public Error modificarUsuario(Usuario u)
        {
            Error er = null;

            
                try
                {
                    string SQL;
                    conectar();
                SQL = "UPDATE persona set nombre = @nombre, apaterno = @apaterno, amaterno = @amaterno, fechanac = @fechanac, genero = @genero, telefono = @telefono, cp = @cp, domicilio = @domicilio, colonia = @colonia where idPersona = @idpersona;";
                    Con.Open();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;

                Console.WriteLine("USUARIO: " + u.Persona.Nombre + " " + u.Persona.IdPersona);

                cmd.Parameters.AddWithValue("@nombre", u.Persona.Nombre);
                    cmd.Parameters.AddWithValue("@apaterno", u.Persona.Apaterno);
                    cmd.Parameters.AddWithValue("@amaterno", u.Persona.Amaterno);
                    cmd.Parameters.AddWithValue("@fechanac", u.Persona.FechaNac);
                    cmd.Parameters.AddWithValue("@genero", u.Persona.Genero);
                    cmd.Parameters.AddWithValue("@telefono", u.Persona.Telefono);
                    cmd.Parameters.AddWithValue("@cp", u.Persona.Domicilio.CP);
                    cmd.Parameters.AddWithValue("@domicilio", u.Persona.Domicilio.Calle);
                    cmd.Parameters.AddWithValue("@colonia", u.Persona.Domicilio.Colonia);
                    cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);

                    cmd.ExecuteNonQuery();

                  

                    if (u.Rol == 0)
                    {
                    SQL = "UPDATE cliente set email = @email where idpersona = @idpersona;";
                        cmd = new SqlCommand();
                        cmd.Connection = Con;
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@email", (u.Persona as Cliente).Email);
                        cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);
                        cmd.ExecuteNonQuery();
                    }


                SQL = "update usuario set usuario = @usuario, rol = @rol where idusuario = @idusuario;";
                    cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@usuario", u.Nombre);
                    cmd.Parameters.AddWithValue("@rol", u.Rol);
                    cmd.Parameters.AddWithValue("@idusuario", u.IdUsuario);
                    cmd.ExecuteNonQuery();

               

                }
                catch (Exception ex)
                {
                    er = new Error(ex.ToString());
                }
            return er;
            }

        public Error modificarUsuario(Usuario u, string pass)
        {
            Error er = null;


            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE persona set nombre = @nombre, apaterno = @apaterno, amaterno = @amaterno, fechanac = @fechanac, genero = @genero, telefono = @telefono, cp = @cp, domicilio = @domicilio, colonia = @colonia where idPersona = @idpersona;";
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
                cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);

                cmd.ExecuteNonQuery();



                if (u.Rol == 0)
                {
                    SQL = "UPDATE cliente set email = @email where idpersona = @idpersona;";
                    cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@email", (u.Persona as Cliente).Email);
                    cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);
                    cmd.ExecuteNonQuery();
                }
                


                SQL = "update usuario set usuario = @usuario, rol = @rol, contraseña = @pass where idusuario = @idusuario;";
                cmd = new SqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@usuario", u.Nombre);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@idusuario", u.IdUsuario);

                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                er = new Error(ex.ToString());
            }
            return er;
        }

        public Error eliminar(Usuario u)
        {
            Error er = null;


            try
            {
                string SQL;
                conectar();
                SQL = "update persona set status = 0 where idpersona = @idpersona";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);

                cmd.ExecuteNonQuery();

                


            }
            catch (Exception ex)
            {
                er = new Error(ex.ToString());
            }
            return er;
        }

        public Error activar(Usuario u)
        {
            Error er = null;


            try
            {
                string SQL;
                conectar();
                SQL = "update persona set status = 1 where idpersona = @idpersona";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idpersona", u.Persona.IdPersona);

                cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                er = new Error(ex.ToString());
            }
            return er;
        }
    }










}

