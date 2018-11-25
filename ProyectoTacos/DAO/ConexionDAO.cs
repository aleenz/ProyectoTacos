using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.DAO
{
    class ConexionDAO
    {
        SqlConnection con;
        public SqlConnection Con { get => con; set => con = value; }
        public void conectar()
        {
            string connectionSTring = "Server=DESKTOP-E90SOJ0;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = iti708utl;";
            try
            {
                con = new SqlConnection(connectionSTring);
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
