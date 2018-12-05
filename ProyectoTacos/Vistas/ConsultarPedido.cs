using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Modelos;
using ProyectoTacos.Beans;


namespace ProyectoTacos.Vistas
{
    public partial class ConsultarPedido : Form
    {
        List<Pedidos> lst_pedido = new List<Pedidos>();
        PedidoBeans pedidoBeans = new PedidoBeans();
        DataTable dt = new DataTable();
        public Main main;
        public ConsultarPedido(Main main)
        {
            this.main = main;
            InitializeComponent();
            tabla();
            listarAbiertos();
        }
        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("IdPedido");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("FechaRec");
            dt.Columns.Add("Status");
            dt.Columns.Add("IdProveedor");
            dt.Columns.Add("idEmpleado");
            dt.Columns.Add("Total");

        }
        public void listarAbiertos()
        {
            pedidoBeans.listarabiertos();
            lst_pedido = pedidoBeans.Lst_pedidos;
            foreach (Pedidos ped in lst_pedido)
            {
                Pedidos pedi = ped;
                DataRow fila = dt.NewRow();
                fila["IdPedido"] = ped.Idpedido;
                fila["Fecha"] = ped.Fecha;
                fila["FechaRec"] = ped.Fecharec;
                fila["Status"] = ped.Status;
                fila["IdProveedor"] = ped.Idproveedor;
                fila["IdEmpleado"] = ped.Idempleado;
                fila["Total"] = ped.Total;
                dt.Rows.Add(fila);

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdPedido"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["FechaRec"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["IdProveedor"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["IdEmpleado"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Total"].ToString();

            }
        }
        public void listar()
        {
            pedidoBeans.listarabiertos();
            lst_pedido = pedidoBeans.Lst_pedidos;
            foreach (Pedidos ped in lst_pedido)
            {
                Pedidos pedi = ped;
                DataRow fila = dt.NewRow();
                fila["IdPedido"] = ped.Idpedido;
                fila["Fecha"] = ped.Fecha;
                fila["FechaRec"] = ped.Fecharec;
                fila["Status"] = ped.Status;
                fila["IdProveedor"] = ped.Idproveedor;
                fila["IdEmpleado"] = ped.Idempleado;
                fila["Total"] = ped.Total;
                dt.Rows.Add(fila);

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdPedido"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["FechaRec"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["IdProveedor"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["IdEmpleado"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Total"].ToString();

            }
        }

        public void listartodos()
        {
            pedidoBeans.listartodos();
            lst_pedido = pedidoBeans.Lst_pedidos;
            foreach (Pedidos ped in lst_pedido)
            {
                Pedidos pedi = ped;
                DataRow fila = dt.NewRow();
                fila["IdPedido"] = ped.Idpedido;
                fila["Fecha"] = ped.Fecha;
                fila["FechaRec"] = ped.Fecharec;
                fila["Status"] = ped.Status;
                fila["IdProveedor"] = ped.Idproveedor;
                fila["IdEmpleado"] = ped.Idempleado;
                fila["Total"] = ped.Total;
                dt.Rows.Add(fila);

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdPedido"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["FechaRec"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["IdProveedor"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["IdEmpleado"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Total"].ToString();

            }
        }


        public void listarAct()
        {
            pedidoBeans.listarabiertos();
            lst_pedido = pedidoBeans.Lst_pedidos;
            foreach (Pedidos ped in lst_pedido)
            {
                Pedidos pedi = ped;
                DataRow fila = dt.NewRow();
                fila["IdPedido"] = ped.Idpedido;
                fila["Fecha"] = ped.Fecha;
                fila["FechaRec"] = ped.Fecharec;
                fila["Status"] = ped.Status;
                fila["IdProveedor"] = ped.Idproveedor;
                fila["IdEmpleado"] = ped.Idempleado;
                fila["Total"] = ped.Total;
                dt.Rows.Add(fila);

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdPedido"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["FechaRec"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["IdProveedor"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["IdEmpleado"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Total"].ToString();

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Todos")
            {
                tabla();
                listartodos();
                
                button3.Text = "Activos";
            }
            else if (button3.Text == "Activos")
            {
                tabla();
                listar();
                button3.Text = "Todos";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedidos pedido = new Pedidos();
            int indice = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indice];
            string a = Convert.ToString(selectedRow.Cells["IdPedido"].Value);
            pedido.Idpedido = Convert.ToInt32(a);
            this.pedidoBeans.Pedido.Idpedido = pedido.Idpedido;
            pedidoBeans.buscarid();
            pedido = pedidoBeans.Pedido;
            this.pedidoBeans.Pedido.Idpedido = pedido.Idpedido;
            pedidoBeans.buscardetalle();
            pedido.Idmateria = pedidoBeans.Pedido.Idmateria;
            pedido.Cantidad = pedidoBeans.Pedido.Cantidad;
            this.pedidoBeans.Pedido.Idpedido = pedido.Idpedido;
            if (button1.Text == "Cerrar")
            {
                var resultado = MessageBox.Show("Ya se entrego esta materia?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    pedidoBeans.eliminar();
                    pedidoBeans.fecharec();

                 ///   MessageBox.Show(Convert.ToString(pedido.Cantidad) + "-" + Convert.ToString(pedido.Idmateria));
                    pedidoBeans.actualizarinv();
                    tabla();
                    listarAct();
                    button3.Text = "Todos";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pedidoBeans.Pedido.Idpedido = Convert.ToInt32( textBox1.Text);
            tabla();
            listarID();
        }
        public void listarID()
        {
            pedidoBeans.listarid();
            lst_pedido = pedidoBeans.Lst_pedidos;
            foreach (Pedidos ped in lst_pedido)
            {
                Pedidos pedi = ped;
                DataRow fila = dt.NewRow();
                fila["IdPedido"] = ped.Idpedido;
                fila["Fecha"] = ped.Fecha;
                fila["FechaRec"] = ped.Fecharec;
                fila["Status"] = ped.Status;
                fila["IdProveedor"] = ped.Idproveedor;
                fila["IdEmpleado"] = ped.Idempleado;
                fila["Total"] = ped.Total;
                dt.Rows.Add(fila);

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (DataRow fila in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = fila["IdPedido"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = fila["Fecha"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = fila["FechaRec"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = fila["Status"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = fila["IdProveedor"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = fila["IdEmpleado"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = fila["Total"].ToString();

            }
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            Registrarpedido rp = new Registrarpedido(this);
            main.abrirForm(rp);
            this.Hide();
        }

        public void actualizar()
        {
            tabla();
            listarAbiertos();
        }
    }
}

