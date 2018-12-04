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
    public partial class ReporteProducto : Form
    {
        String fecha;
        String[] solofecha;
        ReportesBeans repBeans = new ReportesBeans();
        ProductoBeans pBeans = new ProductoBeans();
        Producto producto = new Producto();
        List<Producto> lst_producto = new List<Producto>();
        DataTable dt = new DataTable();
        public ReporteProducto()
        {
            InitializeComponent();
        }
        public ReporteProducto(DateTime fecha1, DateTime fecha2) : this()
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
            Producto promas = new Producto();
            promas = lst_producto[0];
            for (int i = 0; i < lst_producto.Count(); i++)
            {                
                    if (promas.Cantidad<lst_producto[i].Cantidad)
                    {
                        promas = lst_producto[i];
                    }
            }
            textBox3.Text = promas.Nombre;
            textBox4.Text = Convert.ToString(promas.Cantidad);

        }

        public void listar()
        {
            repBeans.listarProducto();
            lst_producto = repBeans.Lst_Producto;
            List<Producto> lst_producto2 = new List<Producto>();
            foreach (Producto proc in lst_producto)
            {
               // Producto producto2 = new Producto();
                this.pBeans.Prod.Idproducto = proc.Idproducto;
               // MessageBox.Show("Se añadio el ingrediente :)"+ proc.Idproducto);
                pBeans.buscarid();
                Producto producto2 = pBeans.Prod;
                producto2.Cantidad = proc.Cantidad;
                producto2.Idproducto = proc.Idproducto;
                MessageBox.Show("Se añadio el ingrediente :)" + producto2.Idproducto);
                lst_producto2.Add(producto2);
            }
            lst_producto = lst_producto2;
            foreach (Producto pro in lst_producto2)
            {
                Producto prod = pro;
                DataRow fila = dt.NewRow();
                
                fila["Nombre"] = prod.Nombre;
                fila["Cantidad"] = prod.Cantidad;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Cantidad"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
