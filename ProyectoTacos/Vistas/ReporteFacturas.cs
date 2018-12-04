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
    public partial class ReporteFacturas : Form
    {
        String fecha;
        String[] solofecha;
        ReportesBeans repBeans = new ReportesBeans();
        ProductoBeans pBeans = new ProductoBeans();
        Producto producto = new Producto();
        List<Pedidos> lst_pedido = new List<Pedidos>();
        DataTable dt = new DataTable();
        public ReporteFacturas()
        {
            InitializeComponent();
        }
        public ReporteFacturas(DateTime fecha1, DateTime fecha2) : this()
        {
            fecha = Convert.ToString(fecha1.Date);
            solofecha = fecha.Split(' ');
            textBox1.Text = solofecha[0];
            fecha = Convert.ToString(fecha2.Date);
            solofecha = fecha.Split(' ');
            textBox2.Text = solofecha[0];
            this.repBeans.Fecha1 = fecha1;
            this.repBeans.Fecha2 = fecha2;
            tabla();
            listar();
        }

        public void listar()
        {
            repBeans.listarPedidos();
            lst_pedido = repBeans.Lst_Pedido;
            foreach (Pedidos pedido in lst_pedido)
            {
                Pedidos pedi = pedido;
                DataRow fila = dt.NewRow();

                fila["Id"] = pedi.Idpedido;
                fila["Fecha"] = pedi.Fecha;
                fila["Idproveedor"] = pedi.Idproveedor;
                fila["Total"] = pedi.Total;
                if (pedi.Status==1)
                {
                    fila["Status"] = "Por pagar";
                }
                else
                {
                    fila["Status"] = "Pagado";
                }
                
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Idproveedor"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Total"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Status"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Idproveedor");
            dt.Columns.Add("Total");
            dt.Columns.Add("Status");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
