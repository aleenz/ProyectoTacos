using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;

namespace ProyectoTacos.Vistas
{
    public partial class ModificarMateriaP : Form
    {
        MateriaPrima matp;
        MateriapBeans materiaP_bean = new MateriapBeans();
        public ModificarMateriaP()
        {
            InitializeComponent();
        }
        public ModificarMateriaP(MateriaPrima mp) : this()
        {
            this.matp = mp;
            //txtId.Text = Convert.ToString(matp.Idmateria);
            this.materiaP_bean.Materiap.Idmateria = matp.Idmateria;
            materiaP_bean.buscarid();
            matp = materiaP_bean.Materiap;

            txtId.Text = Convert.ToString(matp.Idmateria);
            txtNombre.Text = matp.Nombre;
            txtUnidad.Text = matp.Unidadmed;
            txtCosto.Text = Convert.ToString(matp.Costomed);
            txtInventario.Text = Convert.ToString(matp.Inventario);

        }
        public void carga_reg()
        {
            this.materiaP_bean.Materiap.Nombre = txtNombre.Text;
            this.materiaP_bean.Materiap.Inventario = Convert.ToInt32(txtInventario.Text);
            this.materiaP_bean.Materiap.Costomed = Convert.ToDouble(txtCosto.Text);
            this.materiaP_bean.Materiap.Unidadmed = txtUnidad.Text;
            this.materiaP_bean.Materiap.Status = 1;
        }


    }
}
