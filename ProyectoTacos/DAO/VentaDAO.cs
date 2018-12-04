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
    class VentaDAO : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();
        public Error registrar(Venta v)
        {

            SqlDataReader rdr;

            try
            {
                string SQL;
                conectar();
                SQL = "INSERT into venta(fecha,total,idcliente,status)" +
                    " values(@fecha,@total,@idcliente,1)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@fecha", v.Fecha);
                cmd.Parameters.AddWithValue("@total", v.Total);
                cmd.Parameters.AddWithValue("@idcliente", v.Idcliente);
                cmd.ExecuteNonQuery();

                SQL = "Select top 1 idventa from venta order by idventa DESC";
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
                Con.Close();


                SQL = "INSERT into abono(monto,formadepago,idventa)" +
                    " values(@monto,@formadepago,@idventa)";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@monto", v.Total);
                cmd.Parameters.AddWithValue("@formadepago", v.Metodo);
                cmd.Parameters.AddWithValue("@idventa", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Gracias por comer con nosotros :)");
                return null;
            }
            catch (SqlException ex)
            {
                return new Error(ex.ToString());
            }
           

        }
    }
}
