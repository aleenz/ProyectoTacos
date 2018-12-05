using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;

namespace ProyectoTacos.Vistas
{
    public partial class ReporteDetallePedido : Form
    {
        Pedidos pedido = new Pedidos();
        ReportesBeans repBeans = new ReportesBeans();
        List<DetallePedido> lst_detalle = new List<DetallePedido>();
        DataTable dt = new DataTable();
        public ReporteDetallePedido()
        {
            InitializeComponent();
        }

        public ReporteDetallePedido(Pedidos ped) : this()
        {
            this.pedido = ped;
            this.repBeans.Pedido = pedido;
            tabla();
            listar();
        }

        public void listar()
        { 
            
            repBeans.listarDetalle();
            lst_detalle = repBeans.Lst_Detalle;
            foreach (DetallePedido detalle in lst_detalle)
            {
                DetallePedido det = detalle;
                DataRow fila = dt.NewRow();

                fila["Id"] = det.Idmateria;
                fila["Nombre"] = det.Nombre;
                fila["Cantidad"] = det.Cantidad;
                fila["PrecioUnitario"] = det.Preciounit;
                fila["PrecioTotal"] = det.Preciocant;


                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Cantidad"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["PrecioUnitario"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["PrecioTotal"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("PrecioUnitario");
            dt.Columns.Add("PrecioTotal");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
