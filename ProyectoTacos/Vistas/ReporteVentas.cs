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
    public partial class ReporteVentas : Form
    {
        String fecha;
        String[] solofecha;
        ReportesBeans repBeans = new ReportesBeans();
        List<Venta> lst_venta = new List<Venta>();
        DataTable dt = new DataTable();
        public ReporteVentas()
        {
            InitializeComponent();
        }
        public ReporteVentas(DateTime fecha1,DateTime fecha2) : this()
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
            repBeans.listarVentas();
            lst_venta = repBeans.Lst_venta;
            foreach (Venta venta in lst_venta)
            {
                Venta vent = venta;
                DataRow fila = dt.NewRow();

                fila["Id"] = vent.Idventa;
                fecha = Convert.ToString(vent.Fecha);
                solofecha = fecha.Split(' ');
                fila["Fecha"] = solofecha[0];
                fila["Total"] = vent.Total;
                fila["Status"] = vent.Status;

                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Total"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Total");
            dt.Columns.Add("Status");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            venta.Idventa = Convert.ToInt32(a);
            ReportePartidaVenta rp = new ReportePartidaVenta(venta);
            rp.Show();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
