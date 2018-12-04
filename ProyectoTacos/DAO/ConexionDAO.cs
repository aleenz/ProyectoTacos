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
            //DESKTOP-5EUQD5F
            //DESKTOP-E90SOJ0
            string connectionSTring = "Server=SANCHEZ;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;";
            try
            {
                con = new SqlConnection(connectionSTring);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
