using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.Modelos;
namespace ProyectoTacos.DAO
{
    class PersonaDAO:ConexionDAO
    {
        SqlCommand cmd = new SqlCommand();

        public Persona BuscarId(int id)
        {
            Persona persona = null;
            SqlDataReader rdr;
            try
            {
                string SQL;
                conectar();
                SQL = "Select * from persona where idpersona = '" + id + "' ";
                Con.Open();
                cmd.Connection = Con;
                cmd.CommandText = SQL;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read()) { 
                    
                        /*TODO: PONER LOS CAMPOS CON RESPECTO A LA BDD*/
                        persona = new Persona();
                        persona.IdPersona = rdr.GetInt32(1);
                      
                    }

                }
                Con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return persona;
        }
    }
}
