using ProyectoTacos.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Prefabs
{
    public class FormP : Form
    {
        public Main main;
        public FormP(Main main)
        {
            this.main = main;
        }
    }
}
