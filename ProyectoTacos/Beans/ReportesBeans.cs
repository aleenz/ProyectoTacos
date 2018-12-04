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
        private Pedidos pedido = new Pedidos();
        private List<Pedidos> lst_Pedido = new List<Pedidos>();
        private List<DetallePedido> lst_Detalle = new List<DetallePedido>();
        private Venta vent = new Venta();
        private List<Venta> lst_venta = new List<Venta>();
        private List<Partida> lst_Partida = new List<Partida>();
        private List<MateriaPrima> lst_Materiap = new List<MateriaPrima>();
        private List<Producto> lst_Producto = new List<Producto>();
        private DateTime fecha1;
        private DateTime fecha2;


        public Pedidos Pedido { get => pedido; set => pedido = value; }
        internal List<Pedidos> Lst_Pedido { get => lst_Pedido; set => lst_Pedido = value; }
        internal List<DetallePedido> Lst_Detalle { get => lst_Detalle; set => lst_Detalle = value; }
        public Venta Vent { get => vent; set => vent = value; }
        internal List<Venta> Lst_venta { get => lst_venta; set => lst_venta = value; }
        internal List<Partida> Lst_Partida { get => lst_Partida; set => lst_Partida = value; }
        internal List<MateriaPrima> Lst_Materiap { get => lst_Materiap; set => lst_Materiap = value; }
        internal List<Producto> Lst_Producto { get => lst_Producto; set => lst_Producto = value; }
        public DateTime Fecha1 { get => fecha1; set => fecha1 = value; }
        public DateTime Fecha2 { get => fecha2; set => fecha2 = value; }

        //Listar Pedidos sin pagar
        public void listarVentas()
        {
            ReportesDAO repDAO;
            try
            {
                repDAO = new ReportesDAO();
                Lst_venta = repDAO.listarVentas(fecha1, fecha2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listarPartida()
        {
            ReportesDAO repDAO;
            try
            {
                repDAO = new ReportesDAO();
                Lst_Partida = repDAO.listarPartida(vent);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Listar Pedidos sin pagar
        public void listarPedidos()
        {
            ReportesDAO repDAO;
            try
            {
                repDAO = new ReportesDAO();
                Lst_Pedido = repDAO.listarPedidos(fecha1, fecha2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listarDetalle()
        {
            ReportesDAO repDAO;
            try
            {
                repDAO = new ReportesDAO();
                lst_Detalle = repDAO.listarDetalle(pedido);
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
