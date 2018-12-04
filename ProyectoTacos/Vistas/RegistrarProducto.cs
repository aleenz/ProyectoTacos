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
        public ConsultarProducto frm;
        public RegistrarProducto(ConsultarProducto form)
        {
            InitializeComponent();
            this.frm = form;
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
                IngredientesProd igp = new IngredientesProd(producto,this);
                this.Hide();
                
                frm.main.abrirForm(igp);
            }
        }

        public void carga_reg()
        {
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precioun = Convert.ToDouble(txtPrecio.Text);
            producto.Foto = new PictureBox();
            producto.Foto.Image = pictureBox2.Image;
            producto.Status = 1;
        }

        public void limpiar()
        {
            txtDescripcion.Text = null;
            txtPrecio.Text = null;
            txtNombre.Text = null;
            pictureBox2.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

            {
                e.Handled = true;

                return;

            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

            {
                e.Handled = true;

                return;

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

            {
                e.Handled = true;

                return;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            frm.actualizar();
            frm.main.abrirForm(frm);
        }
    }

}
