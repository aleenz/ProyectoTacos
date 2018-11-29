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
    public partial class ModificarProducto : Form
    {
        Producto producto = new Producto();
        ProductoBeans producto_bean = new ProductoBeans();
        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.producto_bean.Prod.Idproducto = 5;
            producto_bean.buscarid();
            producto = producto_bean.Prod;
            txtNombre.Text = producto.Nombre;
            txtPrecio.Text = Convert.ToString(producto.Precioun);
            txtDescripcion.Text = producto.Descripcion;
            pictureBox2.Image = producto.Foto.Image;
            
        }

        public void carga_reg()
        {
            this.producto_bean.Prod.Idproducto = 2;
            this.producto_bean.Prod.Nombre = txtNombre.Text;
            this.producto_bean.Prod.Descripcion = txtDescripcion.Text;
            this.producto_bean.Prod.Precioun = Convert.ToDouble(txtPrecio.Text);
            this.producto_bean.Prod.Foto = pictureBox2;
            this.producto_bean.Prod.Status = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
