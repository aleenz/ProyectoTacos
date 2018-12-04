using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;
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
    public partial class ConsultaCliente : Form
    {
        ClienteBeans cliente_Beans = new ClienteBeans();
        List<Cliente> lst_clientes = new List<Cliente>();
        DataTable dt = new DataTable();
        string[] buscarPor = { "c.idcliente", "p.nombre", "c.email"};
        public Main main;
        public ConsultaCliente(Main main)
        {
            this.main = main;
            InitializeComponent();
            tabla();
            listaract();
        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            CBXBuscarPor.SelectedIndex = 0;
            dataGridView1.ClearSelection();
            BTNEliminar.Enabled = false;
        }

        private void mostrar(List<Cliente> list)
        {
            tabla();
            foreach (Cliente u in list)
            {

                DataRow fila = dt.NewRow();
                fila["IdCliente"] = u.IdCliente;
                fila["Nombre"] = u.Nombre;
                fila["Apellidos"] = u.Apaterno + " " + u.Amaterno;

                fila["Genero"] = u.Genero;
                fila["Telefono"] = u.Telefono;
                fila["Email"] = u.Email;
                fila["Status"] = u.Status;
                dt.Rows.Add(fila);
            }
            
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            
          
        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("IdCliente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Genero");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");

        }

        public void buscar(string por, string str)
        {
            cliente_Beans.buscar(por, str);
            lst_clientes = cliente_Beans.Lst_clientes;
            mostrar(lst_clientes);
        }

        public void listar()
        {
            cliente_Beans.listar();
            lst_clientes = cliente_Beans.Lst_clientes;
            mostrar(lst_clientes);

        }

        public void listaract()
        {
            cliente_Beans.listaract();
            lst_clientes = cliente_Beans.Lst_clientes;
            mostrar(lst_clientes);

        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {
             buscar(buscarPor[CBXBuscarPor.SelectedIndex], txtBusqueda.Text);
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {

        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            Cliente u;
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["IdCliente"].Value);
            u = cliente_Beans.buscarId(Convert.ToInt32(a));



            
            if (BTNEliminar.Text == "Eliminar")
            {
                
                
                    var resultado = MessageBox.Show("Seguro de eliminar este registro", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        cliente_Beans.eliminar(u);
                        tabla();
                        listaract();
                        BTNEliminar.Text = "Activar";
                        BTNTodos.Text = "Todos";
                    }
                
                
            }
            else
            {
                cliente_Beans.activar(u);
                tabla();
                listaract();
                BTNTodos.Text = "Todos";
                BTNEliminar.Text = "Eliminar";
            }

        }

        private void BTNTodos_Click(object sender, EventArgs e)
        {
            if (BTNTodos.Text == "Todos")
            {
                tabla();
                listar();
                BTNTodos.Text = "Activos";
            }
            else if (BTNTodos.Text == "Activos")
            {
                tabla();
                listaract();
                BTNTodos.Text = "Todos";
            }

            dataGridView1.ClearSelection();
            BTNEliminar.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (BTNEliminar.Enabled == false) BTNEliminar.Enabled = true;
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["Status"].Value);
            int status = Convert.ToInt32(a);

            if (status == 0)
            {
                BTNEliminar.Text = "Activar";
            }
            else
            {
                BTNEliminar.Text = "Eliminar";
            }
        }

        public void actualizar()
        {
            tabla();
            listaract();
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            main.abrirForm(new ModificarUsuario(this, 0));
            this.Hide();
        }
    }
}
