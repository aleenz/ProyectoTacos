using ProyectoTacos.Beans;
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
    public partial class Ventas_Catalogo : Form
    {

        public static double precio = 0.0;

        public Ventas_Catalogo()
        {
            InitializeComponent();
            Main.carrito = new List<ProductoVenta>();
        }

        private void Ventas_Catalogo_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;


            ProductoBeans p_beans = new ProductoBeans();
            p_beans.listaract();
            List<Producto> lista = p_beans.Lst_Producto;

            int x = 10;
            int y = 10;

            

            foreach (Producto p in lista)
            {
                

                ItemProducto item = new ItemProducto(this, p.Nombre, "$"+p.Precioun, p.Idproducto, ProyectoTacos.Properties.Resources.tacos1 , new Point(x, y));

                if (x == 730)
                {
                    x = 10;
                    y += 160;
                }
                else { x += 240; }
                
            }

           

        }

        public void abrirAnadir(int tag)
        {
            ProductoBeans p_beans = new ProductoBeans();
            Producto p = new Producto();

            p.Idproducto = tag;

            p_beans.Prod.Idproducto = p.Idproducto;

            p_beans.buscarid();
            p = p_beans.Prod;
            

            
            Agregar_producto ap = new Agregar_producto(p,this);
            ap.ShowDialog();
        }

        public void anadirProducto(ProductoVenta pv)
        {
            Main.carrito.Add(pv);
            double total = (Convert.ToInt32(Main.dinero.Text)) + (pv.Producto.Precioun*pv.Cantidad);
            Main.dinero.Text ="" + total + "";
        }




    }
}
