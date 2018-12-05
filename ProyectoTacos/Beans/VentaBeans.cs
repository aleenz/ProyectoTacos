using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Beans
{
    class VentaBeans
    {
        private int idventa;

        public int Idventa { get => idventa; set => idventa = value; }

        public Error registrar(Venta nuevo)
        {
            VentaDAO ventaDAO;
            Error er;
            try
            {
                ventaDAO = new VentaDAO();
                er = ventaDAO.registrar(nuevo);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }
        public void ultimavent()
        {
            VentaDAO ventaDAO;
            try
            {
                ventaDAO = new VentaDAO();
                Idventa = ventaDAO.ultimavent();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
