using ProyectoTacos.Beans;
using ProyectoTacos.DAO;
using ProyectoTacos.Modelos;
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
            int metodo = 0;

            if (RDBCredito.Checked) metodo = 4;
            else if (RDBDebito.Checked) metodo = 28;
            else metodo = 1;

            PersonaDAO u_beans = new PersonaDAO();
           Cliente c = u_beans.buscarCliente(Usuario.Activo.Persona.IdPersona);

            Venta v = new Venta();
            v.Fecha = DateTime.Now;
            v.Idcliente = c.IdCliente;
            Console.WriteLine(c.IdCliente);
            v.Total = precio;
            v.Metodo = metodo;
            
            VentaBeans v_beans = new VentaBeans();
            Error er = v_beans.registrar(v);
            if (er != null) MessageBox.Show(er.Descripcion);
            quitarInventario();
            Main.carrito = new List<ProductoVenta>();
            Main.dinero.Text = "0";

            this.Close();
            
            
        }

        private void quitarInventario()
        {
            foreach (ProductoVenta pv in Main.carrito)
            {
                Producto p = pv.Producto;
                ProductoBeans p_b = new ProductoBeans();
                p_b.Prod = p;
                p_b.listaring();
                List<Usomateria> lista = p_b.Lst_Uso;
                List<Usomateria> nueva = new List<Usomateria>();
                
               foreach(Usomateria uso in lista)
                {
                    Usomateria nuevo = uso;
                    nuevo.Cantidad = nuevo.Cantidad * pv.Cantidad;
                    nueva.Add(nuevo);
                }
                MateriapBeans m_beans = new MateriapBeans();
                m_beans.quitarInventario(nueva);
            }

        }
    }
}
