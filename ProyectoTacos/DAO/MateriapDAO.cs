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
    class MateriapDAO : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        public void registrar(MateriaPrima materiap)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "Insert into materiaprima(nombre,unidadmed,inventario," +
                    "costomed,status) values (" +
                    "@nombre,@unidadmed,@inventario,@costomed," +
                    "@status)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@nombre", materiap.Nombre);
                cmd.Parameters.AddWithValue("@unidadmed", materiap.Unidadmed);
                cmd.Parameters.AddWithValue("@inventario", materiap.Inventario);
                cmd.Parameters.AddWithValue("@costomed", materiap.Costomed);
                cmd.Parameters.AddWithValue("@status", materiap.Status);
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

        public List<MateriaPrima> listarActivos()
        {
            List<MateriaPrima> lista = new List<MateriaPrima>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM materiaprima where status=1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        MateriaPrima matep = new MateriaPrima();
                        matep.Idmateria = rdr.GetInt32(0);
                        matep.Nombre = rdr.GetString(1);
                        matep.Unidadmed = rdr.GetString(2);
                        matep.Inventario = rdr.GetInt32(3);
                        matep.Costomed = rdr.GetDouble(4);
                        matep.Status = rdr.GetInt32(5);
                        lista.Add(matep);
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
        public List<MateriaPrima> listar()
        {
            List<MateriaPrima> lista = new List<MateriaPrima>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM materiaprima";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        MateriaPrima matep = new MateriaPrima();
                        matep.Idmateria = rdr.GetInt32(0);
                        matep.Nombre = rdr.GetString(1);
                        matep.Unidadmed = rdr.GetString(2);
                        matep.Inventario = rdr.GetInt32(3);
                        matep.Costomed = rdr.GetDouble(4);
                        matep.Status = rdr.GetInt32(5);
                        lista.Add(matep);
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

        public MateriaPrima buscarid(MateriaPrima matp)
        {
            MateriaPrima materiap = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM materiaprima WHERE idmateria='" + matp.Idmateria + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        materiap = new MateriaPrima();
                        materiap.Idmateria = rdr.GetInt32(0);
                        materiap.Nombre = rdr.GetString(1);
                        materiap.Unidadmed = rdr.GetString(2);
                        materiap.Inventario = rdr.GetInt32(3);
                        materiap.Costomed = rdr.GetDouble(4);
                        materiap.Status = rdr.GetInt32(5);
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
            return materiap;
        }
        public List<MateriaPrima> buscarnombre(MateriaPrima matp)
        {
            List<MateriaPrima> lista = new List<MateriaPrima>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM materiaprima WHERE nombre like'%" + matp.Nombre + "%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        MateriaPrima matep = new MateriaPrima();
                        matep.Idmateria = rdr.GetInt32(0);
                        matep.Nombre = rdr.GetString(1);
                        matep.Unidadmed = rdr.GetString(2);
                        matep.Inventario = rdr.GetInt32(3);
                        matep.Costomed = rdr.GetDouble(4);
                        matep.Status = rdr.GetInt32(5);
                        lista.Add(matep);
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
        public void modificar(MateriaPrima materiap)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE materiaprima SET " +
                    "nombre=@nombre," +
                    "costomed=@costomed" +
                    " WHERE idmateria=@idmateria";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idmateria", materiap.Idmateria);
                cmd.Parameters.AddWithValue("@nombre", materiap.Nombre);
                cmd.Parameters.AddWithValue("@costomed", materiap.Costomed);
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
        public void eliminar(MateriaPrima materiap)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE materiaprima SET " +
                    "status=@status" +
                    " WHERE idmateria=@idmateria";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idmateria", materiap.Idmateria);
                cmd.Parameters.AddWithValue("@status", materiap.Status);
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
    }
}
