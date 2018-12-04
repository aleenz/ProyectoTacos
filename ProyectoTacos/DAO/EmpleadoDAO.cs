using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.DAO
{
    class EmpleadoDAO : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT p.idPersona, p.nombre, p.apaterno, p.amaterno,p.fechanac, p.genero, p.telefono,p.cp,p.domicilio,p.colonia,p.status, c.idEmpleado,c.fechaing  from Persona as p inner join Empleado as c on p.idpersona = c.idpersona";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Empleado c = new Empleado();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6) + "";

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7) + "";
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;
                        c.Status = rdr.GetInt32(10);
                        c.IdEmpleado = rdr.GetInt32(11);
                        c.FechaIng = rdr.GetDateTime(12);

                        lista.Add(c);
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

        public List<Empleado> listaract()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT p.idPersona, p.nombre, p.apaterno, p.amaterno,p.fechanac, p.genero, p.telefono,p.cp,p.domicilio,p.colonia,p.status, c.idEmpleado,c.fechaing  from Persona as p inner join Empleado as c on p.idpersona = c.idpersona where status = 1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Empleado c = new Empleado();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6) + "";

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7) + "";
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;
                        c.Status = rdr.GetInt32(10);
                        c.IdEmpleado = rdr.GetInt32(11);
                        c.FechaIng = rdr.GetDateTime(12);

                        lista.Add(c);
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

        public List<Empleado> buscar(string por, string str)
        {
            List<Empleado> lista = new List<Empleado>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();

                SQL = "SELECT p.idPersona, p.nombre, p.apaterno, p.amaterno,p.fechanac, p.genero, p.telefono,p.cp,p.domicilio,p.colonia,p.status, c.idEmpleado,c.fechaing  from Persona as p inner join Empleado as c on p.idpersona = c.idpersona where " + por + " like '%" + str + "%'";

                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Empleado c = new Empleado();
                        c.IdPersona = rdr.GetInt32(0);
                        c.Nombre = rdr.GetString(1);
                        c.Apaterno = rdr.GetString(2);
                        c.Amaterno = rdr.GetString(3);
                        c.FechaNac = rdr.GetDateTime(4);
                        c.Genero = rdr.GetString(5);
                        c.Telefono = rdr.GetInt64(6) + "";

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7) + "";
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        c.Domicilio = d;
                        c.Status = rdr.GetInt32(10);
                        c.IdEmpleado = rdr.GetInt32(11);
                        c.FechaIng = rdr.GetDateTime(12);

                        lista.Add(c);



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

        public Empleado buscarId(int id)
        {

            return (buscar("c.idEmpleado", id + ""))[0];
        }

        public Error eliminar(Empleado c)
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
                cmd.Parameters.AddWithValue("@idpersona", c.IdPersona);

                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                er = new Error(ex.ToString());
            }
            return er;
        }

        public Error activar(Empleado c)
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
                cmd.Parameters.AddWithValue("@idpersona", c.IdPersona);

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
