using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Vistas
{
    public partial class ReportePartidaVenta : Form
    {
        Venta venta = new Venta();
        ReportesBeans repBeans = new ReportesBeans();
        List<Partida> lst_partida = new List<Partida>();
        DataTable dt = new DataTable();
        public ReportePartidaVenta()
        {
            InitializeComponent();
        }

        public ReportePartidaVenta(Venta vent) : this()
        {
            this.venta = vent;
            this.repBeans.Vent = venta;
            tabla();
            listar();
        }
        public void listar()
        {

            repBeans.listarPartida();
            lst_partida = repBeans.Lst_Partida;
            foreach (Partida partida in lst_partida)
            {
                Partida par = partida;
                DataRow fila = dt.NewRow();

                fila["Id"] = par.Idproducto;
                fila["Nombre"] = par.Nombre;
                fila["Cantidad"] = par.Cantidad;
                fila["PrecioTotal"] = par.Costo;


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
                dataGridView1.Rows[num].Cells[3].Value = fila["PrecioTotal"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("PrecioTotal");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
