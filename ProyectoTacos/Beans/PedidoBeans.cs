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

    class PedidoBeans
    {
        private MateriaPrima mat = new MateriaPrima();
        private Pedidos pedido = new Pedidos();
        private List<Pedidos> lst_pedidos = new List<Pedidos>();

        internal MateriaPrima Mat { get => mat; set => mat = value; }
        internal Pedidos Pedido { get => pedido; set => pedido = value; }
        internal List<Pedidos> Lst_pedidos { get => lst_pedidos; set => lst_pedidos = value; }


        public void RegIdpedido()
        {
            PedidiosDao pedidodao;
            try
            {
                pedidodao = new PedidiosDao();
                pedido = pedidodao.Regidpedido();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void registrarpedido()
        {
            PedidiosDao pedido;
            try
            {
                pedido = new PedidiosDao();
                pedido.registrarpedido(Pedido);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void registrardetallepedido()
        {
            PedidiosDao pedido;
            try
            {
                pedido = new PedidiosDao();
                pedido.registrardetallepedido(Pedido);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error!!!" + ex.Number + "Ha ocurrido: " + ex.Message,
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listarabiertos()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                lst_pedidos = pedDao.listarabiertos();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listartodos()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                lst_pedidos = pedDao.listartodos();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listarid()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                lst_pedidos = pedDao.listarid(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void eliminar()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                pedDao.eliminar(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarid()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                pedDao.buscarid(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fecharec()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                pedDao.fecharec(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void actualizarinv()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                
                pedDao.actualizarinv(pedido);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscardetalle()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                Pedido = pedDao.buscardetalle(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listar()
        {
            PedidiosDao pedDao;
            try
            {
                pedDao = new PedidiosDao();
                lst_pedidos = pedDao.listarid(pedido);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " Ha ocurrido" + ex.Message,
                                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 
}

