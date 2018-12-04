using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.Modelos;
using System.Windows.Forms;

namespace ProyectoTacos.DAO
{
  
    class PedidiosDao : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        

        public void registrarpedido(Pedidos pedi)
        {
            try
            {
                string sql;
                conectar();
                sql = "insert into pedido (fecha,fecharec,status,idproveedor,idempleado,total) " +
                    "values (@fecha,@fecharec,@status,@idproveedor,@idempleado,@total )";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@fecha", pedi.Fecha);
                cmd.Parameters.AddWithValue("@fecharec", pedi.Fecharec);
                cmd.Parameters.AddWithValue("@status", pedi.Status);
                cmd.Parameters.AddWithValue("@idproveedor", pedi.Idproveedor);
                cmd.Parameters.AddWithValue("@idempleado", pedi.Idempleado);
                cmd.Parameters.AddWithValue("@total", pedi.Total);
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
 public void registrardetallepedido(Pedidos pedi)
        {
            try
            {
                string SQL;
                conectar();
                SQL = "insert into detalleped (cantidad,preciounit,preciocant," +
                    "idpedido,idmateria) values (@cantidad,@preciounit,@preciocant," +
                    "@idpedido,@idmateria)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@cantidad", pedi.Cantidad);
                cmd.Parameters.AddWithValue("@preciounit", pedi.Preciounit);
                cmd.Parameters.AddWithValue("@preciocant", pedi.Preciocant);
                cmd.Parameters.AddWithValue("@idpedido", pedi.Idpedido);
                cmd.Parameters.AddWithValue("@idmateria", pedi.Idmateria);
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


        public Pedidos Regidpedido()
        {
            Pedidos peido = null;
            SqlDataReader rdr;
            try
            {
                string sql;
                conectar();
                sql = "SELECT TOP 1 idpedido+1 FROM pedido ORDER BY idpedido DESC";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = sql;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        peido = new Pedidos();
                        peido.Idpedido = rdr.GetInt32(0);
                    }
                }
                else
                {
                 //   peido.Idpedido = 1;
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
            return peido;

        }
        public List <Pedidos> listarabiertos()
        {
            List<Pedidos> lista = new List<Pedidos>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM pedido where status=1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Pedidos pedi = new Pedidos();
                        pedi.Idpedido = rdr.GetInt32(0);
                        pedi.Fecha = rdr.GetDateTime(1);
                        pedi.Fecharec = rdr.GetDateTime(2);
                        pedi.Status = rdr.GetString(3);
                        pedi.Idproveedor = rdr.GetInt32(4);
                        pedi.Idempleado = rdr.GetInt32(5);
                        pedi.Total = rdr.GetDouble(6);
                     
                        lista.Add(pedi);
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
        public List<Pedidos> listartodos()
        {
            List<Pedidos> lista = new List<Pedidos>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM pedido";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Pedidos pedi = new Pedidos();
                        pedi.Idpedido = rdr.GetInt32(0);
                        pedi.Fecha = rdr.GetDateTime(1);
                        pedi.Fecharec = rdr.GetDateTime(2);
                        pedi.Status = rdr.GetString(3);
                        pedi.Idproveedor = rdr.GetInt32(4);
                        pedi.Idempleado = rdr.GetInt32(5);
                        pedi.Total = rdr.GetDouble(6);

                        lista.Add(pedi);
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
        public List<Pedidos> listarid(Pedidos pedid)
        {
            List<Pedidos> lista = new List<Pedidos>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM pedido where idpedido like '%"+pedid.Idpedido+"%'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Pedidos pedi = new Pedidos();
                        pedi.Idpedido = rdr.GetInt32(0);
                        pedi.Fecha = rdr.GetDateTime(1);
                        pedi.Fecharec = rdr.GetDateTime(2);
                        pedi.Status = rdr.GetString(3);
                        pedi.Idproveedor = rdr.GetInt32(4);
                        pedi.Idempleado = rdr.GetInt32(5);
                        pedi.Total = rdr.GetDouble(6);

                        lista.Add(pedi);
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
        public void eliminar (Pedidos ped)
        
        {
                    try
            {
                string SQL;
                conectar();
                SQL = "update pedido set status =0 where idpedido=@idpedido";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idPedido", ped.Idpedido);
                cmd.Parameters.AddWithValue("@status", 0);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha dado de baja el registro correctamente",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Erroraqui!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
          
    }

        public Pedidos buscarid(Pedidos ped)

        {
            Pedidos pedido = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "select * from pedido where idpedido ='"+ped.Idpedido+"'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        pedido = new Pedidos();
                        pedido.Idpedido = rdr.GetInt32(0);
                        pedido.Fecha = rdr.GetDateTime(1);
                        pedido.Fecharec = rdr.GetDateTime(2);
                        pedido.Status = rdr.GetString(3);
                        pedido.Idproveedor = rdr.GetInt32(4);
                        pedido.Idempleado = rdr.GetInt32(5);
                        pedido.Total = rdr.GetDouble(6);
                    }
                }
                
                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Erroraqui!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return pedido;
        }

        public void fecharec(Pedidos ped)

        {
            try
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                int day = dt.Day;
                int mon = dt.Month;
                int year = dt.Year;
                string a = System.Convert.ToString(year + "/" + mon + "/" + day);
                string SQL;
                conectar();
                SQL = "update pedido set fecharec=@fecharec where idpedido=@idpedido";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@idPedido", ped.Idpedido);
                cmd.Parameters.AddWithValue("@fecharec", a);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha dado de cerrado el pedido correctamente",
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
       
        public void actualizarinv(Pedidos ped)

        {
            try
            {

                string SQL;
                conectar();
                SQL = "update materiaprima set inventario=inventario+@inventario where idmateria=@idmateria";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@inventario", ped.Cantidad);
                cmd.Parameters.AddWithValue("@idmateria", ped.Idmateria);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Se ha actualizado el inventario",
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

        public Pedidos buscardetalle(Pedidos ped)

        {
            Pedidos pedido = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "select cantidad,idmateria from detalleped where idpedido ='" + ped.Idpedido + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        pedido = new Pedidos();
                        pedido.Cantidad = rdr.GetInt32(0);
                        pedido.Idmateria = rdr.GetInt32(1);
                    }
                }

                Con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Erroraqui!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
            return pedido;
        }
    }
}