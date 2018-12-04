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
    public partial class ConsultarProducto : Form
    {
        List<Producto> lst_producto = new List<Producto>();
        ProductoBeans producto_bean = new ProductoBeans();
        DataTable dt = new DataTable();
        public Main main;
        public ConsultarProducto(Main main)
        {
            this.main = main;
            InitializeComponent();
            tabla();
            listarAct();
        }

        public void listar()
        {
            producto_bean.listar();
            lst_producto = producto_bean.Lst_Producto;
            foreach (Producto pro in lst_producto)
            {
                Producto prod = pro;
                DataRow fila = dt.NewRow();

                fila["Id"] = prod.Idproducto;
                fila["Nombre"] = prod.Nombre;
                fila["Precio"] = prod.Precioun;
                fila["Descripcion"] = prod.Descripcion;
                fila["Status"] = prod.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Precio"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Descripcion"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Status"].ToString();
            }
        }
        public void listarAct()
        {
            producto_bean.listaract();
            lst_producto = producto_bean.Lst_Producto;
            foreach (Producto pro in lst_producto)
            {
                Producto prod = pro;
                DataRow fila = dt.NewRow();

                fila["Id"] = prod.Idproducto;
                fila["Nombre"] = prod.Nombre;
                fila["Precio"] = prod.Precioun;
                fila["Descripcion"] = prod.Descripcion;
                fila["Status"] = prod.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Precio"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Descripcion"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Status"].ToString();
            }
        }

        public void listarNombre()
        {
            producto_bean.buscarnom();
            lst_producto = producto_bean.Lst_Producto;
            foreach (Producto pro in lst_producto)
            {
                Producto prod = pro;
                DataRow fila = dt.NewRow();

                fila["Id"] = prod.Idproducto;
                fila["Nombre"] = prod.Nombre;
                fila["Precio"] = prod.Precioun;
                fila["Descripcion"] = prod.Descripcion;
                fila["Status"] = prod.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Precio"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Descripcion"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Status"].ToString();
            }
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Descripcion");
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
                MessageBox.Show("Selecciona el parametro de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                        this.producto_bean.Prod.Nombre = txtBusqueda.Text;
                        tabla();
                        listarNombre();
                    }
                    else if (param == "Id")
                    {
                        Producto producto = new Producto();
                        producto.Idproducto = Convert.ToInt32(txtBusqueda.Text);
                        this.producto_bean.Prod.Idproducto = producto.Idproducto;
                        producto_bean.buscarid();
                        producto = producto_bean.Prod;
                        if (producto == null)
                        {
                            MessageBox.Show("No se encontraron registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        }
                        else
                        {
                            ModificarProducto mod = new ModificarProducto(producto,this);
                            mod.ShowDialog();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            producto.Idproducto = Convert.ToInt32(a);
            ModificarProducto mod = new ModificarProducto(producto,this);
            mod.ShowDialog();
            tabla();
            listarAct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            producto.Idproducto = Convert.ToInt32(a);
            this.producto_bean.Prod.Idproducto = producto.Idproducto;
            if (button3.Text == "Eliminar")
            {
                    var resultado = MessageBox.Show("Seguro de eliminar este registro", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                    producto_bean.eliminar();
                        tabla();
                        listarAct();
                        button4.Text = "Todos";
                    }
                
            }
            else
            {
                producto_bean.activar();
                tabla();
                listarAct();
                button4.Text = "Todos";
                button3.Text = "Eliminar";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto producto = new Producto();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            producto.Idproducto = Convert.ToInt32(a);
            this.producto_bean.Prod.Idproducto = producto.Idproducto;
            producto_bean.buscarid();
            producto = producto_bean.Prod;
            if (producto.Status == 0)
            {
                button3.Text = "Activar";
            }
            else
            {
                button3.Text = "Eliminar";
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Producto producto = new Producto();
                int indice = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[indice];
                string a = Convert.ToString(selectedRow.Cells["Id"].Value);
                producto.Idproducto = Convert.ToInt32(a);
                this.producto_bean.Prod.Idproducto = producto.Idproducto;
                producto_bean.buscarid();
                producto = producto_bean.Prod;
                if (producto.Status == 0)
                {
                    button3.Text = "Activar";
                }
                else
                {
                    button3.Text = "Eliminar";
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            string param = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (param == "Nombre")
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

                {
                    e.Handled = true;

                    return;

                }
            }
            else
            {
                if (param == "Id")
                {
                    if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

                    {
                        e.Handled = true;

                        return;

                    }
                }
                else
                {
                    e.Handled = true;

                    return;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusqueda.Text = null;
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            RegistrarProducto rp = new RegistrarProducto(this);
            main.abrirForm(rp);
        }

        public void actualizar()
        {
            tabla();
            listarAct();
        }

        private void ConsultarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
