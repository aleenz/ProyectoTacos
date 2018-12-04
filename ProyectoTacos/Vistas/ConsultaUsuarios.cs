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
    public partial class ConsultaUsuarios : Form
    {
        UsuarioBeans usuario_beans = new UsuarioBeans();
        List<Usuario> lst_usuarios = new List<Usuario>();
        DataTable dt = new DataTable();
        string[] roles = { "Cliente", "Empleado", "Administrador" };
        string[] buscarPor = { "idusuario", "idpersona", "usuario", "rol", "nombre" };
        public Main main;
        public ConsultaUsuarios(Main main)
        {
            this.main = main;
            InitializeComponent();
            tabla();
            listaract();
            dataGridView1.ClearSelection();
        }

        private void ConsultaUsuarios_Load(object sender, EventArgs e)
        {
            CBXBuscarPor.SelectedIndex = 0;
            dataGridView1.ClearSelection();
            BTNEliminar.Enabled = false;
            BTNModificar.Enabled = false;

        }

        private void mostrar(List<Usuario> list)
        {
            tabla();
            foreach (Usuario u in lst_usuarios)
            {

                DataRow fila = dt.NewRow();
                fila["IdUsuario"] = u.IdUsuario;
                fila["IdPersona"] = u.Persona.IdPersona;
                fila["NombreUsuario"] = u.Nombre;
                fila["Rol"] = roles[u.Rol];
                fila["Nombre"] = u.Persona.Nombre + " " + u.Persona.Apaterno;
                fila["Status"] = u.Persona.Status;
                dt.Rows.Add(fila);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdUsuario"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["IdPersona"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["NombreUsuario"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Rol"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["Nombre"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["Status"].ToString();
            }
        }

        public void listar()
        {
            usuario_beans.listar();
            lst_usuarios = usuario_beans.Lst_Usuarios;
            mostrar(lst_usuarios);
            
        }

        public void listaract()
        {
            usuario_beans.listaract();
            lst_usuarios = usuario_beans.Lst_Usuarios;
            mostrar(lst_usuarios);

        }

        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("IdPersona");
            dt.Columns.Add("NombreUsuario");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Status");
        }


        public void buscar(string por, string str)
        {
            usuario_beans.buscar(por,str);
            lst_usuarios = usuario_beans.Lst_Usuarios;
            mostrar(lst_usuarios);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar(buscarPor[CBXBuscarPor.SelectedIndex], txtBusqueda.Text);
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["IdUsuario"].Value);
            int id = Convert.ToInt32(a);

            Usuario u = usuario_beans.buscarId(id);
            ModificarUsuarios mod = new ModificarUsuarios(u, this);

            main.abrirForm(mod);
            this.Hide();

            
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            Usuario u;
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["IdUsuario"].Value);
            u = usuario_beans.buscarId(Convert.ToInt32(a));



            
            if (BTNEliminar.Text == "Eliminar")
            {
                
                
                    var resultado = MessageBox.Show("Seguro de eliminar este registro", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        usuario_beans.eliminar(u);
                        tabla();
                        listaract();
                        BTNEliminar.Text = "Activar";
                        BTNTodos.Text = "Todos";
                    }
                
                
            }
            else
            {
                usuario_beans.activar(u);
                tabla();
                listaract();
                BTNTodos.Text = "Todos";
                BTNEliminar.Text = "Eliminar";
            }
        }

     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (BTNEliminar.Enabled == false) BTNEliminar.Enabled = true;
            if (BTNModificar.Enabled == false) BTNModificar.Enabled = true;
            Console.WriteLine("WHAT");
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

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            ModificarUsuario form = new ModificarUsuario(this,1);
            main.abrirForm(form);
            this.Hide();
        }

        public void actualizar()
        {
            tabla();
            listaract();
        }
    }
}
