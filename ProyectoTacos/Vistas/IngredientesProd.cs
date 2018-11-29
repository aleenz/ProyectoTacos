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
    public partial class IngredientesProd : Form
    {
        Producto producto = new Producto();
        ProductoBeans producto_bean = new ProductoBeans();
        MateriaPrima materiap = new MateriaPrima();
        MateriapBeans materiap_bean = new MateriapBeans();
        List<MateriaPrima> lst_MateriaP = new List<MateriaPrima>();
        List<Usomateria> lst_uso = new List<Usomateria>();
        int idprod;
        public IngredientesProd()
        {
            InitializeComponent();
        }

        public IngredientesProd(Producto pro) : this()
        {
            this.producto = pro;
            pictureBox2.Image = producto.Foto.Image;
            label5.Text = producto.Nombre;
        
        }
        private void IngredientesProd_Load(object sender, EventArgs e)
        {
            materiap_bean.listaract();
            lst_MateriaP = materiap_bean.Lst_Materiap;

            comboBox1.DataSource = lst_MateriaP;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idmateria";
            comboBox1.Text = "Ingredientes a usar";
            txtUnidad.Text = null;

            producto_bean.ultimo();
            idprod = producto_bean.Prod.Idproducto + 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ir = Convert.ToString(comboBox1.SelectedValue);
            int n;
            bool isNumeric = int.TryParse(ir, out n);
            if (isNumeric == true)
            {
                materiap.Idmateria = (int)comboBox1.SelectedValue;
                this.materiap_bean.Materiap.Idmateria = materiap.Idmateria;
                materiap_bean.buscarid();
                materiap = materiap_bean.Materiap;
                txtUnidad.Text = materiap.Unidadmed;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usomateria um = new Usomateria();
            um.Idmatep = materiap.Idmateria;
            um.Unidadmed = materiap.Unidadmed;
            um.Cantidad = Convert.ToInt32(txtCantidad.Text);
            um.Idproducto = idprod;
            lst_uso.Add(um);
            MessageBox.Show("Se añadio el ingrediente :)");
        }

        public void carga_reg()
        {
            this.producto_bean.Prod.Nombre = producto.Nombre;
            this.producto_bean.Prod.Descripcion = producto.Descripcion;
            this.producto_bean.Prod.Precioun = producto.Precioun;
            this.producto_bean.Prod.Foto = producto.Foto;
            this.producto_bean.Prod.Status = 1;
            this.producto_bean.Lst_Uso = lst_uso;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lst_uso == null)
            {
                MessageBox.Show("Debe seleccionar por lo menos un ingrediente");
            }
            else
            {
                carga_reg();
                producto_bean.registrar();
                producto_bean.registraruso();
            }
        }
    }
}
