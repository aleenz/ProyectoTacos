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
    public partial class RegistrarProducto : Form
    {
        Producto producto = new Producto();
        ProductoBeans producto_bean = new ProductoBeans();
        public RegistrarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    pictureBox2.Load(this.openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == ""
                || pictureBox2.Image == null)
            {
                MessageBox.Show("Debe llenar todos los campos y seleccionar una imagen");
            }
            else if (txtPrecio.Text == "0" || txtPrecio.Text == "0.0")
            {
                MessageBox.Show("Debe colocar un costo real");
            }
            else
            {
                carga_reg();
                producto_bean.registrar();
                limpiar();
            }
        }

        public void carga_reg()
        {
            this.producto_bean.Prod.Nombre = txtNombre.Text;
            this.producto_bean.Prod.Descripcion = txtDescripcion.Text;
            this.producto_bean.Prod.Precioun = Convert.ToDouble(txtPrecio.Text);
            this.producto_bean.Prod.Foto = pictureBox2;
            this.producto_bean.Prod.Status = 1;
        }

        public void limpiar()
        {
            txtDescripcion.Text = null;
            txtPrecio.Text = null;
            txtNombre.Text = null;
            pictureBox2.Image = null;
        }
    }

}
