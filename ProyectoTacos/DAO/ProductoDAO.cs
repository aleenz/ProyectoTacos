using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoTacos.Modelos;

namespace ProyectoTacos.DAO
{
    class ProductoDAO : ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();
    }
}
