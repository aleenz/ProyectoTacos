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
    public partial class RegistrarMateriaP : Form
    {
        MateriaPrima materiap = new MateriaPrima();
        MateriapBeans materiap_bean = new MateriapBeans();
        public RegistrarMateriaP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCosto.Text == "" || txtInventario.Text == ""
                || txtUnidad.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (txtCosto.Text == "0" || txtCosto.Text == "0.0")
            {
                MessageBox.Show("Debe colocar un costo real");
            }
            else
            {
                carga_reg();
                materiap_bean.registrar();
                limpiar();
            }
        }
        public void carga_reg()
        {
            this.materiap_bean.Materiap.Nombre = txtNombre.Text;
            this.materiap_bean.Materiap.Inventario = Convert.ToInt32(txtInventario.Text);
            this.materiap_bean.Materiap.Costomed = Convert.ToDouble(txtCosto.Text);
            this.materiap_bean.Materiap.Unidadmed = txtUnidad.Text;
            this.materiap_bean.Materiap.Status = 1;
        }
        public void limpiar()
        {
            txtCosto.Text = null;
            txtInventario.Text = null;
            txtNombre.Text = null;
            txtUnidad.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

            {
                e.Handled = true;

                return;

            }
        }

        private void txtUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

            {
                e.Handled = true;

                return;

            }
        }

        private void txtInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

            {
                e.Handled = true;

                return;

            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

            {
                e.Handled = true;

                return;

            }
            /*
              if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            */
        }
    }
}
