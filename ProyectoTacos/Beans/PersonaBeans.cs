using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
namespace ProyectoTacos.Beans
{
    class PersonaBeans
    {

        public Persona getPersona(int id)
        {
            PersonaDAO persona_dao;
            Persona persona = null;
            try
            {
                persona_dao = new PersonaDAO();
                persona = persona_dao.BuscarId(id);

                
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {

            }
            return persona;
        }
    }
}
