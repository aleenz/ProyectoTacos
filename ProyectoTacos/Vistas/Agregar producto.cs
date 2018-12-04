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
    public partial class Agregar_producto : Form
    {
        Producto prod;
        public Agregar_producto(Producto p)
        {
            prod = p;
            InitializeComponent();

        }

        private void Agregar_producto_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 51; i++)
            {
                CBXCantidad.Items.Add(i);
            }

            pictureBox1.Image = ProyectoTacos.Properties.Resources.tacos1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LBLPrecio.Text = prod.Precioun+"";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
