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
    public partial class Agregar_producto : Form
    {
        Producto prod;
        Ventas_Catalogo frm;
        public Agregar_producto(Producto p,Ventas_Catalogo frm)
        {
            this.frm = frm;
            prod = p;
            InitializeComponent();

        }

        private void Agregar_producto_Load(object sender, EventArgs e)
        {

            ProductoBeans pbeans = new ProductoBeans();
            int disp = pbeans.verificarDisponibilidad(prod);
            if(disp > 0)
            {
                for (int i = 1; i <= disp; i++)
                {
                    CBXCantidad.Items.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Lo sentimos, este producto no se encuentra disponible");
                this.Close();
                return;
            }
            
            CBXCantidad.SelectedIndex = 0;

            pictureBox1.Image = ProyectoTacos.Properties.Resources.tacos1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LBLPrecio.Text = prod.Precioun+"";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ProductoVenta prod_v = new ProductoVenta();
            prod_v.Cantidad = Convert.ToInt32(CBXCantidad.Text);
            prod_v.Producto = prod;

            frm.anadirProducto(prod_v);
        }
    }
}
