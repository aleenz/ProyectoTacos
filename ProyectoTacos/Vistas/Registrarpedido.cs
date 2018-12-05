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
    public partial class Registrarpedido : Form
    {
        DateTime datatimeVariable = DateTime.Now;
        DataTable dt = new DataTable();
        ConsultarPedido frm;
        List<Pedidos> lst_Pedido = new List<Pedidos>();
        Pedidos pedido = new Pedidos();
        PedidoBeans pedidoBeans = new PedidoBeans();

        public Registrarpedido(ConsultarPedido frm)
        {
            tabla();
            this.frm = frm;


            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Text = Convert.ToString(1);
            numericUpDown1.Enabled = false;
            label13.Visible = false;
            label5.Visible = false;
            comboBox2.Visible = false;
            label15.Visible = false;

           // label8.Text = datatimeVariable.ToString();
            label1.Visible = false;
            label10.Visible = false;

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int day = dt.Day;
            int mon = dt.Month;
            int year = dt.Year;
            label8.Text = System.Convert.ToString(day + "/" + mon + "/" + year);



            // label8.Text=DateTime.Now.ToString("yyyy/mm/dd");

            combobox1();


        }
      

            
        
        
        public void tabla()
        {
            dt = new DataTable();
            dt.Columns.Add("IdPedido");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("FechaRec");
            dt.Columns.Add("Status");
            dt.Columns.Add("IdProveedor");
            dt.Columns.Add("IdEmpleado");
            dt.Columns.Add("Total");
        }
        public void user()
        {
          


            //    textBox1.Text = pedidoBeans.userlog(Usuario.pedido);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;
            string firstColumn = label10.Text;
            string secondColumn = comboBox2.Text;
            string thirdColumn = numericUpDown1.Text;
            string fourthColumn = textBox2.Text;
            string fithColumn = label13.Text;
            string sixthColumn = label13.Text;

            string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn, fithColumn, sixthColumn };
            dataGridView1.Rows.Add(row);


        }

        public void carga_reg()
        {
            pedidoBeans.RegIdpedido();
            Pedidos pedios = new Pedidos();
            pedios.Idpedido = pedidoBeans.Pedido.Idpedido;
            this.pedidoBeans.Pedido.Idpedido = pedios.Idpedido;
            this.pedidoBeans.Pedido.Cantidad = Convert.ToDouble(numericUpDown1.Value);
            this.pedidoBeans.Pedido.Preciounit = Convert.ToDouble(textBox2.Text);
            this.pedidoBeans.Pedido.Preciocant = Convert.ToDouble(label13.Text);
            this.pedidoBeans.Pedido.Idmateria = Convert.ToInt32(label10.Text);


            this.pedidoBeans.Pedido.Fecha = Convert.ToDateTime(label8.Text);
            this.pedidoBeans.Pedido.Fecharec = Convert.ToDateTime(label8.Text);
            this.pedidoBeans.Pedido.Status = "1";
            this.pedidoBeans.Pedido.Idproveedor = Convert.ToInt32(label15.Text);
            this.pedidoBeans.Pedido.Idempleado = Convert.ToInt32(textBox1.Text);
            this.pedidoBeans.Pedido.Total = Convert.ToDouble(textBox4.Text);

        }
        public void combobox1()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from proveedor";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["nombre"]);

            }



            con.Close();
        }
        public void combobox2()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select materiap from proveedor where nombre like '%" + comboBox1.SelectedItem + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox2.Items.Add(dr["materiap"]);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Elige un proveedor");
            }
            else
            {
                comboBox2.ResetText();
                label13.Text = null;
                comboBox2.Items.Clear();
                label5.Visible = true;
                comboBox2.Visible = true;
                label1.Visible = true;
                combobox2();
                rfc();
                proveedorId();
            }
        }


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = null;
            label1.Text = null;
            label10.Text = null;
            textBox2.Text = null;
        }


        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.SelectedItem = null;
        }
        public void rfc()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select rfc from proveedor where nombre like '%" + comboBox1.SelectedItem + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                label1.Text = Convert.ToString(dr["rfc"]);

            }
            con.Close();
        }
        public void proveedorId()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select idproveedor from proveedor where nombre like '%" + comboBox1.SelectedItem + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                label15.Text = Convert.ToString(dr["idproveedor"]);

            }
            con.Close();
        }
        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)


        { }
        public void calculartotal()
        {
            double totalmed;
            double totalcant;
            double total;
            totalmed = Convert.ToDouble(textBox2.Text);
            totalcant = Convert.ToDouble(numericUpDown1.Value);
            total = totalmed * totalcant / 1000;
            label13.Text = total.ToString();

        }
        private void label10_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select costomed from materiaprima where idmateria like '%" + label10.Text + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                label10.Visible = true;

                textBox2.Text = Convert.ToString(dr["costomed"]);

            }
            con.Close();
        }




        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculartotal();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection("Server=DESKTOP-TG2K6G9;" +
                "persist security info = True; Integrated Security = true;" +
                "Database = tacos;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select idmateria from materiaprima where nombre like '%" + comboBox2.Text + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                label10.Visible = true;

                label10.Text = Convert.ToString(dr["idmateria"]);
                calculartotal();
                label13.Visible = true;

            }
            con.Close();
        }
      
       





private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        

        }


        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

    
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          

            
        }
    
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if(dataGridView1.SelectedRows == null){
                    MessageBox.Show("no tienes registros selecionados");
                }
                if (oneCell.Selected)
                {
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            }if(dataGridView1.Rows == null)
                {
                    MessageBox.Show("Elige un registro para eliminar");
                }

        }
    }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {


           
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
           

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double total = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDouble(t.Cells[5].Value));
            textBox4.Text = total.ToString();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

           

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            carga_reg();
            pedidoBeans.registrarpedido();
            pedidoBeans.registrardetallepedido();

            this.Close();
            frm.actualizar();
            frm.main.Show(frm);
            
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frm.main.abrirForm(frm);
        }
    }
}


