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
    class ClienteBeans
    {
        private List<Cliente> lst_clientes = new List<Cliente>();
        internal List<Cliente> Lst_clientes { get => lst_clientes; set => lst_clientes = value; }
        public void listar()
        {
            ClienteDAO clienteDAO;
            try
            {
                clienteDAO = new ClienteDAO();
                lst_clientes = clienteDAO.listar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaract()
        {
            ClienteDAO clienteDAO;
            try
            {
                clienteDAO = new ClienteDAO();
                lst_clientes = clienteDAO.listaract();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar(string por, string str)
        {
            ClienteDAO clienteDAO;
            try
            {
                clienteDAO = new ClienteDAO();
                lst_clientes = clienteDAO.buscar(por, str);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Cliente buscarId(int id)
        {
            ClienteDAO clienteDAO;
            try
            {
                clienteDAO = new ClienteDAO();
                return clienteDAO.buscarId(id);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public Error eliminar(Cliente nuevo)
        {
            ClienteDAO clienteDAO;
            Error er;
            try
            {
                clienteDAO = new ClienteDAO();
                er = clienteDAO.eliminar(nuevo);


            }
            catch (SqlException ex)
            {

                er = new Error(ex.ToString());

                throw;
            }

            return er;
        }

        public Error activar(Cliente nuevo)
        {
            ClienteDAO clienteDAO;
            Error er;
            try
            {
                clienteDAO = new ClienteDAO();
                er = clienteDAO.activar(nuevo);


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
