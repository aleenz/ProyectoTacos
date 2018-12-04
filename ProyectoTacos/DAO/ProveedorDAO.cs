using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoTacos.Modelos;
using System.Windows.Forms;

namespace ProyectoTacos.DAO
{
    class ProveedorDAO : ConexionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public void registrar(provedoor prov)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "Insert into proveedor(RFC,nombre,correo," +
                    "materiap, calle,cp,status,numero,telefono,colonia) values (" +
                    "@RFC,@nombre,@correo,@materiap,@calle,@cp,@status,@numero,@telefono," +
                    "@colonia)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@RFC", prov.Rfc);
                cmd.Parameters.AddWithValue("@nombre", prov.Nombre);
                cmd.Parameters.AddWithValue("@correo", prov.Correo);
                cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                cmd.Parameters.AddWithValue("@materiap", prov.Materiap);
                cmd.Parameters.AddWithValue("@calle", prov.Calle);
                cmd.Parameters.AddWithValue("@numero", prov.Numero);
                cmd.Parameters.AddWithValue("@colonia", prov.Colonia);
                cmd.Parameters.AddWithValue("@cp", prov.Cp);
                cmd.Parameters.AddWithValue("@status", prov.Status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha dado de alta el" +
                    " Registro correctamente!", "Success!", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error" + ex,
                    "Advertencia!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                Con.Close();
            }
        }
        public void modificar(provedoor prov)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE proveedor SET " +
                    "RFC=@RFC,nombre=@nombre,correo=@correo," +
                    "telefono=@telefono,materiap=@materiap," +
                    "calle=@calle,numero=@numero,colonia=@colonia," +
                    "cp=@cp WHERE idproveedor =@idproveedor";

                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproveedor", prov.Idproveedo);
                cmd.Parameters.AddWithValue("@RFC", prov.Rfc);
                cmd.Parameters.AddWithValue("@nombre", prov.Nombre);
                cmd.Parameters.AddWithValue("@correo", prov.Correo);
                cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                cmd.Parameters.AddWithValue("@materiap", prov.Materiap);
                cmd.Parameters.AddWithValue("@calle", prov.Calle);
                cmd.Parameters.AddWithValue("@numero", prov.Numero);
                cmd.Parameters.AddWithValue("@colonia", prov.Colonia);
                cmd.Parameters.AddWithValue("@cp", prov.Cp);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha actualizado el registro correctamente",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        }
        public void eliminar(provedoor prov)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE proveedor SET " +
                    "status=0" +
                    " WHERE idproveedor=@idproveedor";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproveedor", prov.Idproveedo);
                cmd.Parameters.AddWithValue("@status", prov.Status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha dado de baja el registro correctamente",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        }
        public List<provedoor> listarActivos()
        {
            List<provedoor> lista = new List<provedoor>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM proveedor where status=1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        provedoor prov = new provedoor();
                        prov.Idproveedo = rdr.GetInt32(0);
                        prov.Rfc = rdr.GetString(1);
                        prov.Nombre = rdr.GetString(2);
                        prov.Correo = rdr.GetString(3);
                        prov.Telefono = rdr.GetInt64(9);
                        prov.Materiap = rdr.GetString(4);
                        prov.Calle = rdr.GetString(5);
                        prov.Colonia = rdr.GetString(10);
                        prov.Cp = rdr.GetInt32(6);
                        prov.Status = rdr.GetInt32(7);
                        prov.Numero = rdr.GetInt32(8);
                        lista.Add(prov);
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
        public List<provedoor> buscarnombre(provedoor prov)
        {
            List<provedoor> lista = new List<provedoor>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM proveedor WHERE nombre like'%" + prov.Nombre + "%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        provedoor prove = new provedoor();
                        prove.Idproveedo = rdr.GetInt32(0);
                        prove.Rfc = rdr.GetString(1);
                        prove.Nombre = rdr.GetString(2);
                        prove.Correo = rdr.GetString(3);
                        prove.Telefono = rdr.GetInt64(9);
                        prove.Materiap = rdr.GetString(4);
                        prove.Calle = rdr.GetString(5);
                        prove.Colonia = rdr.GetString(10);
                        prove.Cp = rdr.GetInt32(6);
                        prove.Status = rdr.GetInt32(7);
                        prove.Numero = rdr.GetInt32(8);
                        lista.Add(prove);
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
        public List<provedoor> listarinactivos()
        {
            List<provedoor> lista = new List<provedoor>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM proveedor where status=0";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        provedoor prov = new provedoor();
                        prov.Idproveedo = rdr.GetInt32(0);
                        prov.Rfc = rdr.GetString(1);
                        prov.Nombre = rdr.GetString(2);
                        prov.Correo = rdr.GetString(3);
                        prov.Telefono = rdr.GetInt64(9);
                        prov.Materiap = rdr.GetString(4);
                        prov.Calle = rdr.GetString(5);
                        prov.Colonia = rdr.GetString(10);
                        prov.Cp = rdr.GetInt32(6);
                        prov.Status = rdr.GetInt32(7);
                        prov.Numero = rdr.GetInt32(8);
                        lista.Add(prov);

                        ;
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
        public List<provedoor> listartodos()
        {
            List<provedoor> lista = new List<provedoor>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM proveedor";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        provedoor prov = new provedoor();
                        prov.Idproveedo = rdr.GetInt32(0);
                        prov.Rfc = rdr.GetString(1);
                        prov.Nombre = rdr.GetString(2);
                        prov.Correo = rdr.GetString(3);
                        prov.Telefono = rdr.GetInt64(9);
                        prov.Materiap = rdr.GetString(4);
                        prov.Calle = rdr.GetString(5);
                        prov.Colonia = rdr.GetString(10);
                        prov.Cp = rdr.GetInt32(6);
                        prov.Status = rdr.GetInt32(7);
                        prov.Numero = rdr.GetInt32(8);
                        lista.Add(prov);


                        ;
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
        public provedoor buscarid(provedoor prov)
        {
            provedoor prove = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM proveedor WHERE idproveedor='" + prov.Idproveedo + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        prove = new provedoor();
                        prove.Idproveedo = rdr.GetInt32(0);
                        prove.Rfc = rdr.GetString(1);
                        prove.Nombre = rdr.GetString(2);
                        prove.Correo = rdr.GetString(3);
                        prove.Telefono = rdr.GetInt64(9);
                        prove.Materiap = rdr.GetString(4);
                        prove.Calle = rdr.GetString(5);
                        prove.Colonia = rdr.GetString(10);
                        prove.Cp = rdr.GetInt32(6);
                        prove.Status = rdr.GetInt32(7);
                        prove.Numero = rdr.GetInt32(8);

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
            return prove;
        }



        public void activar(provedoor prov)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE proveedor SET " +
                    "status=1" +
                    " WHERE idproveedor=@idproveedor";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproveedor", prov.Idproveedo);
                cmd.Parameters.AddWithValue("@status", prov.Status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha activado el registro correctamente",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        }
    }

}
