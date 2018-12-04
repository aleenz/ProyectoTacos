using ProyectoTacos.Prefabs;
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
    public partial class Subtotal : Form
    {
        DataTable dt;
        double precio = 0;
        public Subtotal()
        {
            InitializeComponent();
            tabla();
        }

        private void Subtotal_Load(object sender, EventArgs e)
        {
            foreach (ProductoVenta pv in Main.carrito)
            {
                DataRow dr = dt.NewRow();
                dr["Producto"] = pv.Producto.Nombre;
                dr["Precio"] = pv.Producto.Precioun;

                dr["Cantidad"] = pv.Cantidad;
                dr["Monto"] = pv.Producto.Precioun * pv.Cantidad;
                dt.Rows.Add(dr);

                precio += pv.Producto.Precioun * pv.Cantidad;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            LBLTotal.Text = precio+"";
        }

       
        private void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Producto");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Monto");
        }

        private void BTNPagar_Click(object sender, EventArgs e)
        {

        }
    }
}
