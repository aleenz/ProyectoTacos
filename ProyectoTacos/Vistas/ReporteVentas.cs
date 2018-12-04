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
    public partial class ReporteVentas : Form
    {
        Producto producto = new Producto();
        ProductoBeans producto_bean = new ProductoBeans();
        MateriaPrima materiap = new MateriaPrima();
        MateriapBeans materiap_bean = new MateriapBeans();
        List<MateriaPrima> lst_MateriaP = new List<MateriaPrima>();
        List<Usomateria> lst_uso = new List<Usomateria>();
        List<Usomateria> lst_uso2 = new List<Usomateria>();
        DataTable dt = new DataTable();
        public ReporteVentas()
        {
            InitializeComponent();
        }
        public ReporteVentas(DateTime fecha1,DateTime fecha2) : this()
        {
            this.producto_bean.Prod.Idproducto = producto.Idproducto;
            producto_bean.listaring();
            lst_uso = producto_bean.Lst_Uso;
            foreach (Usomateria uso in lst_uso)
            {
                Usomateria usomat = uso;
                this.materiap_bean.Materiap.Idmateria = usomat.Idmatep;
                materiap_bean.buscarid();
                materiap = materiap_bean.Materiap;
                usomat.Nombre = materiap.Nombre;
                lst_uso2.Add(usomat);
            }
            lst_uso = lst_uso2;
            tabla();
            listar();

        }

        public void listar()
        {
            List<Usomateria> lst_usotabl = new List<Usomateria>();

            lst_usotabl = lst_uso;
            foreach (Usomateria mp in lst_usotabl)
            {
                Usomateria mat = mp;
                DataRow fila = dt.NewRow();

                fila["Ingrediente"] = mat.Nombre;
                fila["Cantidad"] = mat.Cantidad;
                fila["UnidadMed"] = mat.Unidadmed;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Ingrediente"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Cantidad"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["UnidadMed"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Ingrediente");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("UnidadMed");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
