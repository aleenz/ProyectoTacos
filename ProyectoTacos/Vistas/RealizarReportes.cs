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
    public partial class RealizarReportes : Form
    {
        String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        public RealizarReportes()
        {
            InitializeComponent();
        }

        private void RealizarReportes_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 31; i++)
            {
                this.CBXDia.Items.Add(i);
                this.CBXdia2.Items.Add(i);
            }
            foreach (String mes in meses)
            {
                this.CBXMes.Items.Add(mes);
                this.CBXmes2.Items.Add(mes);
            }
            for (int i = 2019; i >= 2012; i--)
            {
                this.CBXAno.Items.Add(i);
                this.CBXaño2.Items.Add(i);
            }

            CBXDia.SelectedIndex = 0;
            CBXMes.SelectedIndex = 0;
            CBXAno.SelectedIndex = 0;
            CBXdia2.SelectedIndex = 0;
            CBXmes2.SelectedIndex = 0;
            CBXaño2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
