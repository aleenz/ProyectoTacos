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
                        pedido.Status = rdr.GetInt32(3);
                        pedido.Idproveedor = rdr.GetInt32(4);
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
