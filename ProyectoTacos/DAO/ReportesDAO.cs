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
    //asdasdad
    class ReportesDAO:ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        //Listar ventas por fecha
        public List<Venta> listarVentas(DateTime fecha1, DateTime fecha2)
        {
            List<Venta> lista = new List<Venta>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT * FROM venta WHERE fecha BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND status = 1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Venta venta = new Venta();
                        venta.Idventa = rdr.GetInt32(0);
                        venta.Status = Convert.ToInt32(rdr.GetString(1));
                        venta.Fecha = rdr.GetDateTime(2);
                        venta.Total = rdr.GetDouble(3);
                        lista.Add(venta);
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

        public List<Partida> listarPartida(Venta venta)
        {
            List<Partida> lista = new List<Partida>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT p.idproducto, p.nombre, d.cantidad, d.costo FROM partida d INNER JOIN producto p ON d.idproducto = p.idproducto where d.idventa='" + venta.Idventa + "'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Partida partida = new Partida();
                        partida.Idproducto = rdr.GetInt32(0);
                        partida.Nombre = rdr.GetString(1);
                        partida.Cantidad = rdr.GetInt32(2);
                        partida.Costo = rdr.GetDouble(3);
                        lista.Add(partida);
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

        //Listar Pedidos sin pagar
        public List<Pedidos> listarPedidos(DateTime fecha1, DateTime fecha2)
        {
            List<Pedidos> lista = new List<Pedidos>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = " SELECT * FROM pedido WHERE fecha BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND status = 1";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Pedidos pedido = new Pedidos();
                        pedido.Idpedido = rdr.GetInt32(0);
                        pedido.Fecha = rdr.GetDateTime(1);
                        pedido.Status = rdr.GetString(3);
                       // pedido.Idproveedor = rdr.GetInt32(4);
                        pedido.Total = rdr.GetDouble(6);
                        lista.Add(pedido);
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

        public List<DetallePedido> listarDetalle(Pedidos pedido)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT m.idmateria, m.nombre, d.cantidad, d.preciounit, d.preciocant FROM detalleped d INNER JOIN materiaprima m ON d.idmateria = m.idmateria where d.idpedido='"+pedido.Idpedido+"'";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        DetallePedido detalle = new DetallePedido();
                        detalle.Idmateria = rdr.GetInt32(0);
                        detalle.Nombre = rdr.GetString(1);
                        detalle.Cantidad = rdr.GetInt32(2);
                        detalle.Preciounit = rdr.GetDouble(3);
                        detalle.Preciocant = rdr.GetDouble(4);
                        lista.Add(detalle);
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

        //Listar Producto que más aparece

        public List<Producto> listarProducto(DateTime fecha1, DateTime fecha2)
        {
            List<Producto> lista = new List<Producto>();
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "SELECT p.idproducto,SUM(p.cantidad) as cantidad FROM venta v INNER JOIN partida p ON v.idventa = p.idventa WHERE v.fecha BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' AND v.status = 1 GROUP BY p.idproducto order by cantidad desc";
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
                        producto.Cantidad= rdr.GetInt32(1);
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

    }
}
