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
    class ProductoBeans
    {
        private Producto prod = new Producto();
        private List<Producto> lst_Producto = new List<Producto>();

        internal Producto Prod { get => prod; set => prod = value; }
        internal List<Producto> Lst_Producto { get => lst_Producto; set => lst_Producto = value; }

        public void registrar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.registrar(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaract()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Lst_Producto = prodDao.listarActivos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Lst_Producto = prodDao.listar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarid()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Prod = prodDao.buscarid(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarnom()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Lst_Producto = prodDao.buscarnombre(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void modificar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.modificar(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.eliminar(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void activar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.activar(prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
