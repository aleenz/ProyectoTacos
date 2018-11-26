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
                        persona.IdPersona = rdr.GetInt32(0);
                        persona.Nombre = rdr.GetString(1);
                        persona.Apaterno = rdr.GetString(2);
                        persona.Amaterno = rdr.GetString(3);
                        persona.FechaNac = rdr.GetDateTime(4);
                        persona.Genero = rdr.GetString(5);
                        persona.Telefono = rdr.GetInt64(6).ToString();

                        Domicilio d = new Domicilio();
                        d.CP = rdr.GetInt32(7).ToString();
                        d.Calle = rdr.GetString(8);
                        d.Colonia = rdr.GetString(9);

                        persona.Domicilio = d;
                      
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
