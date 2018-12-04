using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;

namespace ProyectoTacos.Vistas
{
    public partial class RegistrarProvedor : Form
    {
        provedoor prove = new provedoor();
        ProveedorBeans ProveedorBeans = new ProveedorBeans();
        public RegistrarProvedor()
        {
            InitializeComponent();
        }
        public void clean()
        {
            textNombre.Text = null;
            textRfc.Text = null;
            textCorreo.Text = null;
            textCalle.Text = null;
            textNumero.Text = null;
            textColonia.Text = null;
            textCodigoP.Text = null;
            textTel.Text = null;
            textMateria.Text = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            clean();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex phoneNumpattern = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
            if (textNombre.Text == "" || textMateria.Text == "" || textCalle.Text == ""
               || textCodigoP.Text == "" || textColonia.Text == "" || textCorreo.Text == ""
               || textNumero.Text == "" || textRfc.Text == "" || textTel.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }

            else if (phoneNumpattern.IsMatch(textTel.Text))
            {
                MessageBox.Show("debe introducir numero real");
            }
            else
            {
                carga_reg();
                ProveedorBeans.registrar();
                clean();
            }
        }

        public void carga_reg()
        {
            this.ProveedorBeans.Provedor.Nombre = textNombre.Text;
            this.ProveedorBeans.Provedor.Rfc = textRfc.Text;
            this.ProveedorBeans.Provedor.Correo = textCorreo.Text;
            this.ProveedorBeans.Provedor.Telefono = Convert.ToInt64(textTel.Text);
            this.ProveedorBeans.Provedor.Materiap = textMateria.Text;
            this.ProveedorBeans.Provedor.Calle = textCalle.Text;
            this.ProveedorBeans.Provedor.Colonia = textColonia.Text;
            this.ProveedorBeans.Provedor.Cp = Convert.ToInt32(textCodigoP.Text);
            this.ProveedorBeans.Provedor.Numero = Convert.ToInt32(textNumero.Text);
            this.ProveedorBeans.Provedor.Status = 1;
        }
    }
}
