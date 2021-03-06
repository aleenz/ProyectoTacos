﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoTacos.Modelos;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.IO;
using ProyectoTacos.Prefabs;

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
                cmd.Parameters.AddWithValue("@status", producto.Status);
                cmd.Parameters.Add("@foto", SqlDbType.Image);
                MemoryStream ms = new MemoryStream();
                producto.Foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@foto"].Value = ms.GetBuffer();
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
                        if (!rdr["foto"].Equals(DBNull.Value))
                        {
                            MemoryStream ms = new MemoryStream((byte[])rdr["foto"]);
                            producto.Foto = new PictureBox();
                            producto.Foto.Image = new Bitmap(ms);
                        }
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
                        if (!rdr["foto"].Equals(DBNull.Value))
                        {
                            MemoryStream ms = new MemoryStream((byte[])rdr["foto"]);
                            producto.Foto = new PictureBox();
                            producto.Foto.Image = new Bitmap(ms);
                        }
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
                        if (!rdr["foto"].Equals(DBNull.Value))
                        {
                        MemoryStream ms = new MemoryStream((byte[])rdr["foto"]);
                        producto.Foto = new PictureBox();
                        producto.Foto.Image = new Bitmap(ms);
                        }
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
                        if (!rdr["foto"].Equals(DBNull.Value))
                        {
                            MemoryStream ms = new MemoryStream((byte[])rdr["foto"]);
                            producto.Foto = new PictureBox();
                            producto.Foto.Image = new Bitmap(ms);
                        }
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
                cmd.Parameters.Add("@foto", SqlDbType.Image);
                MemoryStream ms = new MemoryStream();
                prod.Foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@foto"].Value = ms.GetBuffer();
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

        // Comandos de Uso de Materia
        public void registraruso(Usomateria usoma)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "Insert into usomateria(cantidad,unidadmed,idproducto," +
                    "idmateria) values (" +
                    "@cantidad,@unidadmed,@idproducto,@idmateria)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@cantidad", usoma.Cantidad);
                cmd.Parameters.AddWithValue("@unidadmed", usoma.Unidadmed);
                cmd.Parameters.AddWithValue("@idproducto", usoma.Idproducto);
                cmd.Parameters.AddWithValue("@idmateria", usoma.Idmatep);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Se ha dado de alta el" + " Registro correctamente!", "Success!", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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

        public Producto ultimoprod()
        {
            Producto prod = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT TOP 1 * FROM producto ORDER BY idproducto DESC";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        prod = new Producto();
                        prod.Idproducto = rdr.GetInt32(0);
                        prod.Nombre = rdr.GetString(1);
                        //prod.Descripcion = rdr.GetString(2);
                        //prod.Precioun = rdr.GetInt32(3);
                        //prod.Foto = rdr.GetDouble(4);
                        //prod.Status = rdr.GetInt32(5);
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
            return prod;
        }

        public List<Usomateria> listaingred(Producto prod)
        {
            List<Usomateria> lista = new List<Usomateria>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM usomateria WHERE idproducto='" + prod.Idproducto + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Usomateria usomateria = new Usomateria();
                        usomateria.Cantidad = rdr.GetInt32(0);
                        usomateria.Unidadmed = rdr.GetString(1);
                        usomateria.Idproducto = rdr.GetInt32(2);
                        usomateria.Idmatep = rdr.GetInt32 (3);
                        lista.Add(usomateria);
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

        public Usomateria buscarm(Usomateria uso)
        {
            Usomateria usomateria = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM usomateria WHERE idproducto='" + uso.Idproducto + "' and idmateria='" + uso.Idmatep + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        usomateria = new Usomateria();
                        usomateria.Cantidad = rdr.GetInt32(0);
                        usomateria.Unidadmed = rdr.GetString(1);
                        usomateria.Idproducto = rdr.GetInt32(2);
                        usomateria.Idmatep = rdr.GetInt32(3);
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
            return usomateria;
        }

        public void modificaruso(Usomateria usoma)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "UPDATE usomateria SET " +
                    "cantidad=@cantidad" +
                    " WHERE idproducto=@idproducto AND idmateria=@idmateria";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@cantidad", usoma.Cantidad);
                cmd.Parameters.AddWithValue("@idproducto", usoma.Idproducto);
                cmd.Parameters.AddWithValue("@idmateria", usoma.Idmatep);
                cmd.ExecuteNonQuery();
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

        public void eliminaruso(Usomateria usoma)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "DELETE FROM usomateria WHERE idproducto=@idproducto AND idmateria=@idmateria";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idproducto", usoma.Idproducto);
                cmd.Parameters.AddWithValue("@idmateria", usoma.Idmatep);
                cmd.ExecuteNonQuery();
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

        public int verificarDisponibilidad(Producto pv)
        {
            int disp = 1000000000;
           
            List<Usomateria> lista = listaingred(pv);
            string SQL;
            SqlDataReader rdr;

            conectar();
            try
            {
                Con.Open();
                foreach (Usomateria uso in lista)
                {
                
                   
                        SQL = "Select inventario FROM materiaprima WHERE idmateria=@idmateria" ;
                        
                        cmd.Connection = Con;
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@idmateria", uso.Idmatep);
                       
                        rdr = cmd.ExecuteReader();
                    cmd = new SqlCommand();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            
                            int inv = rdr.GetInt32(0);
                            double c = inv / uso.Cantidad;
                            int d = Convert.ToInt32(Math.Floor(c));
                            if (d < disp) disp = d;
                        }
                    }
                    rdr.Close();
                }
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
            return disp;
        }

        public void partida(ProductoVenta prodve)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "Insert into partida(cantidad,costo,idventa,idproducto) values (" +
                    "@cantidad,@costo,@idventa,@idproducto)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@cantidad", prodve.Cantidad);
                cmd.Parameters.AddWithValue("@costo", prodve.Costo);
                cmd.Parameters.AddWithValue("@idventa", prodve.Idventa);
                cmd.Parameters.AddWithValue("@idproducto", prodve.Producto.Idproducto);
                cmd.ExecuteNonQuery();
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

    }
}
