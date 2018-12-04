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
    class EmpleadoBeans
    {
        private List<Empleado> lst_Empleados = new List<Empleado>();
        internal List<Empleado> Lst_Empleados { get => lst_Empleados; set => lst_Empleados = value; }
        public void listar()
        {
            EmpleadoDAO EmpleadoDAO;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                lst_Empleados = EmpleadoDAO.listar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaract()
        {
            EmpleadoDAO EmpleadoDAO;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                lst_Empleados = EmpleadoDAO.listaract();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar(string por, string str)
        {
            EmpleadoDAO EmpleadoDAO;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                lst_Empleados = EmpleadoDAO.buscar(por, str);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Empleado buscarId(int id)
        {
            EmpleadoDAO EmpleadoDAO;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                return EmpleadoDAO.buscarId(id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public Error eliminar(Empleado nuevo)
        {
            EmpleadoDAO EmpleadoDAO;
            Error er;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                er = EmpleadoDAO.eliminar(nuevo);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }

        public Error activar(Empleado nuevo)
        {
            EmpleadoDAO EmpleadoDAO;
            Error er;
            try
            {
                EmpleadoDAO = new EmpleadoDAO();
                er = EmpleadoDAO.activar(nuevo);


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
