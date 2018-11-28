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
    class ProductoDAO : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();
        public void registrar(Producto producto)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "Insert into producto(nombre,descripcion,precioun," +
                    "foto,status) values (" +
                    "@nombre,@descripcion,@precioun,@foto," +
                    "@status)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precioun", producto.Precioun);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                producto.Foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
               // cmd.Parameters["@Imagen"].Value = ms.GetBuffer();
                cmd.Parameters.AddWithValue("@foto", ms.GetBuffer());
                // cmd.Parameters.AddWithValue("@foto", producto.Foto);
                cmd.Parameters.AddWithValue("@status", producto.Status);
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

        public List<Producto> listarActivos()
        {
            List<Producto> lista = new List<Producto>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM producto where status=1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Producto producto = new Producto();
                        producto.Idproducto = rdr.GetInt32(0);
                        producto.Nombre = rdr.GetString(1);
                        producto.Descripcion = rdr.GetString(2);
                        producto.Precioun = rdr.GetDouble(3);
                     //   producto.Foto = rdr.GetBytes(4); //Generar fotos para busqueda
                        producto.Status = rdr.GetInt32(5);
                        lista.Add(producto);
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
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM producto";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Producto producto = new Producto();
                        producto.Idproducto = rdr.GetInt32(0);
                        producto.Nombre = rdr.GetString(1);
                        producto.Descripcion = rdr.GetString(2);
                        producto.Precioun = rdr.GetDouble(3);
                        //   producto.Foto = rdr.GetBytes(4); //Generar fotos para busqueda
                        producto.Status = rdr.GetInt32(5);
                        lista.Add(producto);
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

        public Producto buscarid(Producto prod)
        {
            Producto producto = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM producto WHERE idproducto='" + prod.Idproducto + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        producto = new Producto();
                        producto.Idproducto = rdr.GetInt32(0);
                        producto.Nombre = rdr.GetString(1);
                        producto.Descripcion = rdr.GetString(2);
                        producto.Precioun = rdr.GetDouble(3);
                        //   producto.Foto = rdr.GetBytes(4); //Generar fotos para busqueda
                        producto.Status = rdr.GetInt32(5);
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
            return producto;
        }
        public List<Producto> buscarnombre(Producto prod)
        {
            List<Producto> lista = new List<Producto>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM producto WHERE nombre like'%" + prod.Nombre + "%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Producto producto = new Producto();
                        producto.Idproducto = rdr.GetInt32(0);
                        producto.Nombre = rdr.GetString(1);
                        producto.Descripcion = rdr.GetString(2);
                        producto.Precioun = rdr.GetDouble(3);
                        //   producto.Foto = rdr.GetBytes(4); //Generar fotos para busqueda
                        producto.Status = rdr.GetInt32(5);
                        lista.Add(producto);
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
        public void modificar(Producto prod)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE producto SET " +
                    "nombre=@nombre," +
                    "descripcion=@descripcion," +
                     "precioun=@precioun," +
                      "foto=@foto" +
                    " WHERE idproducto=@idproducto";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproducto", prod.Idproducto);
                cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                cmd.Parameters.AddWithValue("@precioun", prod.Precioun);
                cmd.Parameters.AddWithValue("@foto", prod.Foto);    //Cambiar por foto
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
        public void eliminar(Producto prod)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE producto SET " +
                    "status=0" +
                    " WHERE idproducto=@idproducto";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproducto", prod.Idproducto);
                cmd.Parameters.AddWithValue("@status", prod.Status);
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
        public void activar(Producto prod)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE producto SET " +
                    "status=1" +
                    " WHERE idproducto=@idproducto";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproducto", prod.Idproducto);
                cmd.Parameters.AddWithValue("@status", prod.Status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha dado activado el registro correctamente",
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
