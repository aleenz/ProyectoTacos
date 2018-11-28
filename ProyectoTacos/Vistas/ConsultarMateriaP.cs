using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;
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
    public partial class ConsultarMateriaP : Form
    {
        List<MateriaPrima> lst_MateriaP = new List<MateriaPrima>();
        MateriapBeans materiaP_bean = new MateriapBeans();
        DataTable dt = new DataTable();
        public ConsultarMateriaP()
        {
            InitializeComponent();
            tabla();
            listarAct();
        }

        public void listar()
        {
            materiaP_bean.listar();
            lst_MateriaP = materiaP_bean.Lst_Materiap;
            foreach (MateriaPrima mp in lst_MateriaP)
            {
                MateriaPrima mat = mp;
                DataRow fila = dt.NewRow();

                fila["Id"] = mat.Idmateria;
                fila["Nombre"] = mat.Nombre;
                fila["UnidadMed"] = mat.Unidadmed;
                fila["Inventario"] = mat.Inventario;
                fila["CostoMed"] = mat.Costomed;
                fila["Status"] = mat.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Inventario"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["UnidadMed"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["CostoMed"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Status"].ToString();
            }
        }
        public void listarAct()
        {
            materiaP_bean.listaract();
            lst_MateriaP = materiaP_bean.Lst_Materiap;
            foreach (MateriaPrima mp in lst_MateriaP)
            {
                MateriaPrima mat = mp;
                DataRow fila = dt.NewRow();

                fila["Id"] = mat.Idmateria;
                fila["Nombre"] = mat.Nombre;
                fila["UnidadMed"] = mat.Unidadmed;
                fila["Inventario"] = mat.Inventario;
                fila["CostoMed"] = mat.Costomed;
                fila["Status"] = mat.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Inventario"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["UnidadMed"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["CostoMed"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Status"].ToString();
            }
        }

        public void listarNombre()
        {
            materiaP_bean.buscarnom();
            lst_MateriaP = materiaP_bean.Lst_Materiap;
            foreach (MateriaPrima mp in lst_MateriaP)
            {
                MateriaPrima mat = mp;
                DataRow fila = dt.NewRow();

                fila["Id"] = mat.Idmateria;
                fila["Nombre"] = mat.Nombre;
                fila["UnidadMed"] = mat.Unidadmed;
                fila["Inventario"] = mat.Inventario;
                fila["CostoMed"] = mat.Costomed;
                fila["Status"] = mat.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Inventario"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["UnidadMed"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["CostoMed"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Status"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Inventario");
            dt.Columns.Add("UnidadMed");
            dt.Columns.Add("CostoMed");
            dt.Columns.Add("Status");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Todos")
            {
                tabla();
                listar();
                button4.Text = "Activos";
            }
            else if (button4.Text == "Activos")
            {
                tabla();
                listarAct();
                button4.Text = "Todos";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (param == "")
            {
                var resultado = MessageBox.Show("Selecciona el parametro de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (txtBusqueda.Text == "" || txtBusqueda.Text == " ")
                {
                    MessageBox.Show("Debe llenar el campo de busqueda");
                }
                else
                {
                    if (param == "Nombre")
                    {
                        this.materiaP_bean.Materiap.Nombre = txtBusqueda.Text;
                        tabla();
                        listarNombre();
                    }
                    else if (param == "Id")
                    {
                        MateriaPrima materiap = new MateriaPrima();
                        materiap.Idmateria = Convert.ToInt32(txtBusqueda.Text);
                        this.materiaP_bean.Materiap.Idmateria = materiap.Idmateria;
                        materiaP_bean.buscarid();
                        materiap = materiaP_bean.Materiap;
                        if (materiap == null)
                        {
                            MessageBox.Show("No se encontraron registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        }
                        else
                        {
                            ModificarMateriaP mod = new ModificarMateriaP(materiap);
                            mod.ShowDialog();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MateriaPrima materiap = new MateriaPrima();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            materiap.Idmateria = Convert.ToInt32(a);
            ModificarMateriaP mod = new ModificarMateriaP(materiap);
            mod.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MateriaPrima materiap = new MateriaPrima();
            materiap.Idmateria = Convert.ToInt32(txtBusqueda.Text);
            this.materiaP_bean.Materiap.Idmateria = materiap.Idmateria;
            materiaP_bean.eliminar();
        }
    }
}
