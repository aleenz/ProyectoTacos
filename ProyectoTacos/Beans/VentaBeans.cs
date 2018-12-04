using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Beans
{
    class VentaBeans
    {
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
    }
}
