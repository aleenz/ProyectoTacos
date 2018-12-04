using ProyectoTacos.Modelos;
using ProyectoTacos.Prefabs;
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


    public partial class Main : Form
    {
        public Form[] formsMenu;
        Form actual = null;
        public Panel p;
        public Form main;
        public int anchoBandaDerecha = 300;
        PictureBox gal;
        public static Label dinero;
        Image[] tacos = { ProyectoTacos.Properties.Resources.tacos1, ProyectoTacos.Properties.Resources.tacos2, ProyectoTacos.Properties.Resources.tacos3, ProyectoTacos.Properties.Resources.tacos4 };
        int img_actual = 0;
        public Main()
        {
            InitializeComponent();
            formsMenu = new Form[9];
            formsMenu[0] = new Ventas_Catalogo();
            formsMenu[1] = new ConsultarProducto();
            formsMenu[2] = new Form();
            formsMenu[3] = new Form();
            formsMenu[4] = new ConsultaUsuarios(this);
            formsMenu[5] = new Form();
            formsMenu[6] = new ConsultaProveedor();
            formsMenu[7] = new ConsultarMateriaP();
            formsMenu[8] = new Form();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            main = this;
            cargar();
            
            
        }

        public void cargar()
        {
            if (Usuario.Activo == null)
            {
                Console.WriteLine("No usuario");
                FRMAcceso frm = new FRMAcceso(this);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                dibujar();
               
                Console.WriteLine("Usuario");
            }
        }


        public void dibujar()
        {
            Panel barraArriba = new Panel();
            barraArriba.Size = new Size(this.Size.Width, 50);
            barraArriba.Location = new Point(0, 0);
            barraArriba.BackColor = Color.Orange;
            barraArriba.Parent = this;
            barraArriba.Show();


            Label titulo = new Label();
            titulo.Size = new Size(this.Size.Width / 3,45);
            titulo.Location = new Point((this.Size.Width / 2) - ((this.Size.Width / 3) / 2));
            titulo.Text = "Bienvenido a la taqueria el chancho contento";
            titulo.ForeColor = Color.White;
            titulo.Font = new Font("Arial", 14f);
            titulo.Parent = barraArriba;
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Show();

            p = new Panel();
            p.Size = new Size(anchoBandaDerecha, this.Size.Height);
            p.Location = new Point(0, 0);
            p.BackColor = Color.White;
            p.Parent = this;
            p.Show();




            if (Usuario.Activo.Rol == 0)
            {
                ItemMenu realizarPedido = new ItemMenu(this, "Realizar Pedido", 0, new Bitmap(ProyectoTacos.Properties.Resources.logo), 60);
            }
            else
            {
                ItemMenu BTNproductos = new ItemMenu(this, "Productos", 1, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 60);
                ItemMenu BTNClientes = new ItemMenu(this, "Clientes", 2, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 140);
                ItemMenu BTNPedidos = new ItemMenu(this, "Pedidos", 3, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 220);
            }

            if(Usuario.Activo.Rol >= 2)
            {
                ItemMenu BTNUsuarios = new ItemMenu(this, "Usuarios", 4, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 300);
                ItemMenu BTNEmpleados = new ItemMenu(this, "Empleados", 5, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 380);
                ItemMenu BTNProveedores = new ItemMenu(this, "Proveedor", 6, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 460);
                ItemMenu BTNMateriaPrima = new ItemMenu(this, "Materia Prima", 7, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 540);
                ItemMenu BTNReportes = new ItemMenu(this, "Reportes", 8, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 620);
            }


            gal = new PictureBox();
            gal.Image = ProyectoTacos.Properties.Resources.tacos1;
            gal.Size = new Size(this.Size.Width-300, this.Size.Height-50);
            gal.Location = new Point(300, 50);
            gal.SizeMode = PictureBoxSizeMode.StretchImage;
            gal.Parent = this;
            

            gal.Show();
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(cambiarImagen);
            timer.Start();

            if (Usuario.Activo.Rol == 0)
            {
                dinero = new Label();
                dinero.Text = "$ 0";
                dinero.Font = new Font("Arial", 12f, FontStyle.Bold);
                dinero.Size = new Size(70, 30);
                dinero.ForeColor = Color.White;
                dinero.BackColor = Color.Orange;
                dinero.Parent = barraArriba;
                dinero.Location = new Point(this.Width - 180, 10);
                dinero.TextAlign = ContentAlignment.MiddleCenter;
                dinero.BringToFront();
                dinero.Show();

                Button btn = new Button();
                btn.Text = "Pagar";
                btn.BackColor = Color.White;
                btn.Size = new Size(65, 30);
                btn.Location = new Point(this.Width - 80, 10);
                btn.Parent = barraArriba;
                
                btn.Show();
            }
        }

        private void cambiarImagen(object sender, EventArgs e)
        {
            if(img_actual == tacos.Length - 1)
            {
                img_actual = 0;
            }
            else
            {
                img_actual++;
            }

            gal.Image = tacos[img_actual];
        }

        public void abrirForm(Form frm)
        {
            gal.Visible = false;
            if(actual!= null)
            {
                actual.Hide();
                actual = null;
            }
            actual = frm;
            actual.MdiParent = this;
            actual.FormBorderStyle = FormBorderStyle.None;
            actual.StartPosition = FormStartPosition.Manual;
            int posx = (((this.Width - anchoBandaDerecha) / 2) - (actual.Width / 2)) + anchoBandaDerecha;
            int posy = (this.Height / 2) - (actual.Height / 2);
            actual.Location = new Point(posx, posy);
           
            actual.Show();
        }



    }
}
