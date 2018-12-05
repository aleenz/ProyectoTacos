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
    class MateriapBeans
    {
        private MateriaPrima materiap = new MateriaPrima();
        private List<MateriaPrima> lst_Materiap = new List<MateriaPrima>();

        internal MateriaPrima Materiap { get => materiap; set => materiap = value; }
        internal List<MateriaPrima> Lst_Materiap { get => lst_Materiap; set => lst_Materiap = value; }

        public void registrar()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                matepDao.registrar(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaract()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                Lst_Materiap = matepDao.listarActivos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listar()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                Lst_Materiap = matepDao.listar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarid()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                Materiap = matepDao.buscarid(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarnom()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                Lst_Materiap = matepDao.buscarnombre(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void modificar()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                matepDao.modificar(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                matepDao.eliminar(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void activar()
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                matepDao.activar(materiap);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void quitarInventario(List<Usomateria> lista)
        {
            MateriapDAO matepDao;
            try
            {
                matepDao = new MateriapDAO();
                matepDao.quitarMateria(lista);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
