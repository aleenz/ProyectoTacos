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
using System.Data.SqlClient;
using ProyectoTacos.DAO;
using ProyectoTacos.Beans;

namespace ProyectoTacos.Vistas
{
    public partial class ConsultaProveedor : Form
    {
        List<provedoor> lst_prov = new List<provedoor>();
        ProveedorBeans ProvedorBeans = new ProveedorBeans();
        DataTable dt = new DataTable();
        public Main main;
        public ConsultaProveedor(Main main)
        {
            this.main = main;
            InitializeComponent();
            tabla();
            listarAct();
        }

        public void listar()
        {
            ProvedorBeans.listar();
            lst_prov = ProvedorBeans.Lst_Prov;
            foreach (provedoor pv in lst_prov)
            {
                provedoor prov = pv;
                DataRow fila = dt.NewRow();

                fila["idProv"] = prov.Idproveedo;
                fila["RFC"] = prov.Rfc;
                fila["Nombre"] = prov.Nombre;
                fila["Correo"] = prov.Correo;
                fila["Telefono"] = prov.Telefono;
                fila["Materia"] = prov.Materiap;
                fila["Calle"] = prov.Calle;
                fila["Colonia"] = prov.Colonia;
                fila["Numero"] = prov.Numero;
                fila["CP"] = prov.Cp;
                fila["Status"] = prov.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["idProv"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["RFC"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Correo"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Telefono"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Materia"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Calle"].ToString();
                dataGridView1.Rows[num].Cells[7].Value = fila["Colonia"].ToString();
                dataGridView1.Rows[num].Cells[8].Value = fila["Numero"].ToString();
                dataGridView1.Rows[num].Cells[9].Value = fila["Cp"].ToString();
                dataGridView1.Rows[num].Cells[10].Value = fila["Status"].ToString();

            }
        }

        public void listarAct()
        {
            ProvedorBeans.listaract();
            lst_prov = ProvedorBeans.Lst_Prov;
            foreach (provedoor pv in lst_prov)
            {
                provedoor prov = pv;
                DataRow fila = dt.NewRow();

                fila["idProv"] = prov.Idproveedo;
                fila["RFC"] = prov.Rfc;
                fila["Nombre"] = prov.Nombre;
                fila["Correo"] = prov.Correo;
                fila["Telefono"] = prov.Telefono;
                fila["Materia"] = prov.Materiap;
                fila["Calle"] = prov.Calle;
                fila["Colonia"] = prov.Colonia;
                fila["Numero"] = prov.Numero;
                fila["CP"] = prov.Cp;
                fila["Status"] = prov.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["idProv"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["RFC"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Correo"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Telefono"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Materia"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Calle"].ToString();
                dataGridView1.Rows[num].Cells[7].Value = fila["Colonia"].ToString();
                dataGridView1.Rows[num].Cells[8].Value = fila["Numero"].ToString();
                dataGridView1.Rows[num].Cells[9].Value = fila["Cp"].ToString();
                dataGridView1.Rows[num].Cells[10].Value = fila["Status"].ToString();
            }
        }

        public void listarNombre()
        {
            ProvedorBeans.buscarnom();
            lst_prov = ProvedorBeans.Lst_Prov;
            foreach (provedoor pv in lst_prov)
            {
                provedoor prov = pv;
                DataRow fila = dt.NewRow();

                fila["idProv"] = prov.Idproveedo;
                fila["RFC"] = prov.Rfc;
                fila["Nombre"] = prov.Nombre;
                fila["Correo"] = prov.Correo;
                fila["Telefono"] = prov.Telefono;
                fila["Materia"] = prov.Materiap;
                fila["Calle"] = prov.Calle;
                fila["Colonia"] = prov.Colonia;
                fila["Numero"] = prov.Numero;
                fila["CP"] = prov.Cp;
                fila["Status"] = prov.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["idProv"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["RFC"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Correo"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Telefono"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Materia"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Calle"].ToString();
                dataGridView1.Rows[num].Cells[7].Value = fila["Colonia"].ToString();
                dataGridView1.Rows[num].Cells[8].Value = fila["Numero"].ToString();
                dataGridView1.Rows[num].Cells[9].Value = fila["Cp"].ToString();
                dataGridView1.Rows[num].Cells[10].Value = fila["Status"].ToString();


            }
        }
        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("idProv");
            dt.Columns.Add("RFC");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Correo");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Materia");
            dt.Columns.Add("Calle");
            dt.Columns.Add("Colonia");
            dt.Columns.Add("Numero");
            dt.Columns.Add("CP");
            dt.Columns.Add("Status");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                if (textBox1.Text == "" || textBox1.Text == " ")
                {
                    MessageBox.Show("Debe llenar el campo de busqueda");
                }
                else
                {
                    if (param == "Name")
                    {
                        provedoor prove = new provedoor();
                        this.ProvedorBeans.Provedor.Nombre = textBox1.Text;
                        ProvedorBeans.buscarnom();
                        prove = ProvedorBeans.Provedor;
                        tabla();
                        listarNombre();
                    }
                    else if (param == "Id")
                    {

                        provedoor prove = new provedoor();
                        prove.Idproveedo = Convert.ToInt32(textBox1.Text);
                        this.ProvedorBeans.Provedor.Idproveedo = prove.Idproveedo;

                        ProvedorBeans.buscarid();
                        prove = ProvedorBeans.Provedor;
                        tabla();
                        listarNombre();
                        if (prove == null)
                        {
                            MessageBox.Show("No se encontraron registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        }
                        else
                        {

                            //ModificarProveedor modp = new ModificarProveedor (prove);
                            // modp.ShowDialog();
                        }
                    }
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Show all")
            {
                tabla();
                listar();
                button4.Text = "Active";
            }
            else if (button4.Text == "Active")
            {
                tabla();
                listarAct();
                button4.Text = "Show all";
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            provedoor prove = new provedoor();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["idProv"].Value);
            prove.Idproveedo = Convert.ToInt32(a);
            ModificarProveedor modp = new ModificarProveedor(prove,this);
            main.abrirForm(modp);
            this.Hide();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            provedoor prove = new provedoor();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["idProv"].Value);
            prove.Idproveedo = Convert.ToInt32(a);
            this.ProvedorBeans.Provedor.Idproveedo = prove.Idproveedo;
            if (button3.Text == "erase")
            {
                ProvedorBeans.buscarid();
                prove = ProvedorBeans.Provedor;

                ProvedorBeans.eliminar();
                tabla();
                listarAct();
                button4.Text = "Show all";
            }



            else
            {
                ProvedorBeans.activar();
                tabla();
                listarAct();
                button4.Text = "Show all";
                button3.Text = "erase";
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            provedoor prove = new provedoor();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["idProv"].Value);
            prove.Idproveedo = Convert.ToInt32(a);
            this.ProvedorBeans.Provedor.Idproveedo = prove.Idproveedo;
            ProvedorBeans.buscarid();
            prove = ProvedorBeans.Provedor;
            if (prove.Status == 0)
            {
                button3.Text = "Activate";
            }
            else
            {
                button3.Text = "erase";
            }
        }


        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))

            {
                e.Handled = true;

                return;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            provedoor prove = new provedoor();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["idProv"].Value);
            prove.Idproveedo = Convert.ToInt32(a);
            this.ProvedorBeans.Provedor.Idproveedo = prove.Idproveedo;
            if (button5.Text == "Activar")
            {
                ProvedorBeans.buscarid();
                prove = ProvedorBeans.Provedor;

                ProvedorBeans.activar();
                tabla();
                listarAct();
                button4.Text = "Show all";
            }



            else
            {
                //ProvedorBeans.activar();
                //tabla();
                //listarAct();
                //button4.Text = "Show all";
                //button3.Text = "erase";
            }
        }

        private void dataGridView1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                provedoor prove = new provedoor();
                int indice = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[indice];
                string a = Convert.ToString(selectedRow.Cells["idProv"].Value);
                prove.Idproveedo = Convert.ToInt32(a);
                this.ProvedorBeans.Provedor.Idproveedo = prove.Idproveedo;
                ProvedorBeans.buscarid();
                prove = ProvedorBeans.Provedor;
                if (prove.Status == 0)
                {
                    button3.Text = "Activate";
                }
                else
                {
                    button3.Text = "erase";
                }
            }
        }

        private void ConsultaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            RegistrarProvedor form = new RegistrarProvedor(this);
            main.abrirForm(form);
            this.Hide();
        }

        public void actualizar()
        {
            tabla();
            listarAct();
        }
    }
}
