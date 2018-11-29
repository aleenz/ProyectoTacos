using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
using System.Windows.Forms;

namespace ProyectoTacos.Beans
{
    class ProveedorBeans
    {

        private provedoor provedor = new provedoor();
        private List<provedoor> lst_Prov = new List<provedoor>();

        internal provedoor Provedor { get => provedor; set => provedor = value; }
        internal List<provedoor> Lst_Prov { get => lst_Prov; set => lst_Prov = value; }

        public void registrar()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                provDao.registrar(provedor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listaract()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                lst_Prov = provDao.listarActivos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listar()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                lst_Prov = provDao.listartodos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarid()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                Provedor = provDao.buscarid(provedor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarnom()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                lst_Prov = provDao.buscarnombre(provedor);
              
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void modificar()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                provDao.modificar(provedor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                provDao.eliminar(provedor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void activar()
        {
            ProveedorDAO provDao;
            try
            {
                provDao = new ProveedorDAO();
                provDao.activar(provedor);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}