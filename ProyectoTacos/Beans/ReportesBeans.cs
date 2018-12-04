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
    class ReportesBeans
    {
        private MateriaPrima materiap = new MateriaPrima();
        private List<MateriaPrima> lst_Materiap = new List<MateriaPrima>();
        private List<Producto> lst_Producto = new List<Producto>();
        private DateTime fecha1;
        private DateTime fecha2;


        internal MateriaPrima Materiap { get => materiap; set => materiap = value; }
        internal List<MateriaPrima> Lst_Materiap { get => lst_Materiap; set => lst_Materiap = value; }
        internal List<Producto> Lst_Producto { get => lst_Producto; set => lst_Producto = value; }
        public DateTime Fecha1 { get => fecha1; set => fecha1 = value; }
        public DateTime Fecha2 { get => fecha2; set => fecha2 = value; }

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

        //Listar Producto que más aparece
        public void listarProducto()
        {
            ReportesDAO repDAO;
            try
            {
                repDAO = new ReportesDAO();
                Lst_Producto = repDAO.listarProducto(fecha1,fecha2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
