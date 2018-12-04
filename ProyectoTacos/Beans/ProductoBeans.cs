using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
using System.Windows.Forms;
using ProyectoTacos.Prefabs;

namespace ProyectoTacos.Beans
{
    class ProductoBeans
    {
        private Producto prod = new Producto();
        private List<Producto> lst_Producto = new List<Producto>();
        private Usomateria usom = new Usomateria();
        private List<Usomateria> lst_Uso = new List<Usomateria>();
        private ProductoVenta prodve = new ProductoVenta();

        internal ProductoVenta Prodve { get => prodve; set => prodve = value; }
        internal List<Producto> Lst_Producto { get => lst_Producto; set => lst_Producto = value; }
        internal Usomateria Usom { get => usom; set => usom = value; }
        internal List<Usomateria> Lst_Uso { get => lst_Uso; set => lst_Uso = value; }
        public Producto Prod { get => prod; set => prod = value; }

        public void registrar()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.registrar(Prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void partida()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.partida(Prodve);

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
                Prod = prodDao.buscarid(Prod);
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
                Lst_Producto = prodDao.buscarnombre(Prod);
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
                prodDao.modificar(Prod);
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
                prodDao.eliminar(Prod);
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
                prodDao.activar(Prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Uso de Materia Prima

        public void registraruso()
        {
            ProductoDAO prodDao;
            try
            {
                foreach (Usomateria uso in Lst_Uso) {
                    prodDao = new ProductoDAO();
                    prodDao.registraruso(uso);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void registraruson()
        {
            ProductoDAO prodDao;
            try
            {
                    prodDao = new ProductoDAO();
                    prodDao.registraruso(usom);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ultimo()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Prod = prodDao.ultimoprod();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listaring()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Lst_Uso = prodDao.listaingred(Prod);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarm()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                Usom = prodDao.buscarm(Usom);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void modificaruso()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.modificaruso(usom);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminaruso()
        {
            ProductoDAO prodDao;
            try
            {
                prodDao = new ProductoDAO();
                prodDao.eliminaruso(usom);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int verificarDisponibilidad(Producto pv)
        {
            ProductoDAO prodDao;
            int disp = 0;
            try
            {
                prodDao = new ProductoDAO();
                disp = prodDao.verificarDisponibilidad(pv);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return disp;
        }
    }
}
