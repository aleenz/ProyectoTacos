using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.Modelos;
namespace ProyectoTacos.DAO
{
    class PersonaDAO:ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        public Persona BuscarId(int id)
        {
            Persona persona = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select * from persona where idpersona = '" + id + "' ";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read()) { 
                    
                        persona = new Persona();
                        persona.IdPersona = rdr.GetInt32(0);
                        persona.Nombre = rdr.GetString(1);
                        persona.Apaterno = rdr.GetString(2);
                        persona.Amaterno = rdr.GetString(3);
                        persona.FechaNac = rdr.GetDateTime(4);
                        persona.Genero = rdr.GetString(5);
                        persona.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        persona.Domicilio = d;
                      
                    }

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
            return persona;
        }

        public Cliente buscarCliente(int id)
        {
            Cliente c = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select p.idPersona, p.nombre, p.apaterno,p.amaterno, p.fechanac, p.genero, p.telefono, p.cp, p.domicilio, p.colonia, p.status, c.email, c.fechareg, c.idcliente from persona as p inner join cliente as c  on c.idpersona = p.idpersona where c.idpersona = '" + id + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        c = new Cliente();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;

                        c.Status = rdr.GetInt32(10);

                        c.Email = rdr.GetString(11);
                        c.FechaIng = rdr.GetDateTime(12);
                        c.IdCliente = rdr.GetInt32(13);

                    }

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
            return c;
        }

        public Empleado buscarEmpleado(int id)
        {
            Empleado c = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select p.idPersona, p.nombre, p.apaterno,p.amaterno, p.fechanac, p.genero, p.telefono, p.cp, p.domicilio, p.colonia, p.status,  e.fechaing from persona as p inner join empleado as e  on e.idpersona = p.idpersona where e.idpersona = '" + id + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        c = new Empleado();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;

                        c.Status = rdr.GetInt32(10);

                        c.FechaIng = rdr.GetDateTime(11);
                    }

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
            return c;
        }

        public Cliente buscarCliente(int id, string por, string str)
        {
            Cliente c = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select p.idPersona, p.nombre, p.apaterno,p.amaterno, p.fechanac, p.genero, p.telefono, p.cp, p.domicilio, p.colonia, p.status, c.email, c.fechareg from persona as p inner join cliente as c  on c.idpersona = p.idpersona where c.idpersona = '" + id + "' and p."+por+" like '%"+str+"%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        c = new Cliente();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;

                        c.Status = rdr.GetInt32(10);

                        c.Email = rdr.GetString(11);
                        c.FechaIng = rdr.GetDateTime(12);
                    }

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
            return c;
        }

        public Empleado buscarEmpleado(int id,string por, string str)
        {
            Empleado c = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select p.idPersona, p.nombre, p.apaterno,p.amaterno, p.fechanac, p.genero, p.telefono, p.cp, p.domicilio, p.colonia, p.status,  e.fechaing from persona as p inner join empleado as e  on e.idpersona = p.idpersona where e.idpersona = '" + id + "' and p." + por + " like '%" + str + "%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        c = new Empleado();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;

                        c.Status = rdr.GetInt32(10);

                        c.FechaIng = rdr.GetDateTime(11);
                    }

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
            return c;
        }
    }
}
