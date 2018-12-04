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
    public partial class ReporteFacturas : Form
    {
        public ReporteFacturas()
        {
            InitializeComponent();
        }
        public ReporteFacturas(DateTime fecha1, DateTime fecha2) : this()
        {
            textBox1.Text = Convert.ToString(fecha1);
            textBox2.Text = Convert.ToString(fecha2);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
