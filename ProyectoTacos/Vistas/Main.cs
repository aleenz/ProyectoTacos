﻿using ProyectoTacos.Modelos;
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
        public static List<ProductoVenta> carrito;

        Image[] tacos = { ProyectoTacos.Properties.Resources.tacos1, ProyectoTacos.Properties.Resources.tacos2, ProyectoTacos.Properties.Resources.tacos3, ProyectoTacos.Properties.Resources.tacos4 };
        int img_actual = 0;
        public Main()
        {
            InitializeComponent();
            formsMenu = new Form[9];
            formsMenu[0] = new Ventas_Catalogo();
            formsMenu[1] = new ConsultarProducto(this);
            formsMenu[2] = new ConsultaCliente(this);
            formsMenu[3] = new ConsultarPedido(this);
            formsMenu[4] = new ConsultaUsuarios(this);
            formsMenu[5] = new ConsultaEmpleado(this);
            formsMenu[6] = new ConsultaProveedor(this);
            formsMenu[7] = new ConsultarMateriaP(this);
            formsMenu[8] = new RealizarReportes();
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

            Label cerrarSesion = new Label();
            cerrarSesion.Size = new Size(100, 15);
            cerrarSesion.Location = new Point(10,15);
            cerrarSesion.Text = "Cerrar Sesión";
            cerrarSesion.ForeColor = Color.White;
            cerrarSesion.Font = new Font("Arial", 9f);
            cerrarSesion.Click += new EventHandler(cerrarSesionM);
            cerrarSesion.Parent = barraArriba;
            cerrarSesion.TextAlign = ContentAlignment.MiddleCenter;
            cerrarSesion.Show();

            Label titulo = new Label();
            titulo.Size = new Size(this.Size.Width / 3,45);
            titulo.Location = new Point((this.Size.Width / 2) - ((this.Size.Width / 3) / 2));
            titulo.Text = "Bienvenido a la taquería \"Los Chanchos a domicilio\"";
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
                ItemMenu realizarPedido = new ItemMenu(this, "Realizar Pedido", 0, ProyectoTacos.Properties.Resources.pedido, 60);
            }
            else
            {
                ItemMenu BTNproductos = new ItemMenu(this, "Productos", 1, ProyectoTacos.Properties.Resources.productos, 60);
                ItemMenu BTNClientes = new ItemMenu(this, "Clientes", 2, ProyectoTacos.Properties.Resources.clientes, 140);
                ItemMenu BTNPedidos = new ItemMenu(this, "Pedidos", 3, ProyectoTacos.Properties.Resources.pedidosmp, 220);
            }

            if(Usuario.Activo.Rol >= 2)
            {
                ItemMenu BTNUsuarios = new ItemMenu(this, "Usuarios", 4, ProyectoTacos.Properties.Resources.usuarios, 300);
                ItemMenu BTNEmpleados = new ItemMenu(this, "Empleados", 5, ProyectoTacos.Properties.Resources.empleado, 380);
                ItemMenu BTNProveedores = new ItemMenu(this, "Proveedor", 6, ProyectoTacos.Properties.Resources.proveedor, 460);
                ItemMenu BTNMateriaPrima = new ItemMenu(this, "Materia Prima", 7, ProyectoTacos.Properties.Resources.materiap, 540);
                ItemMenu BTNReportes = new ItemMenu(this, "Reportes", 8, ProyectoTacos.Properties.Resources.reportes, 620);
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
                Label sim = new Label();
                sim.Text = "$";
                sim.Font = new Font("Arial", 12f, FontStyle.Bold);
                sim.Size = new Size(10, 30);
                sim.ForeColor = Color.White;
                sim.BackColor = Color.Orange;
                sim.Parent = barraArriba;
                sim.Location = new Point(this.Width - 195, 10);
                sim.TextAlign = ContentAlignment.MiddleCenter;
                sim.BringToFront();
                sim.Show();

                dinero = new Label();
                dinero.Text = "0";
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
                btn.Click += new EventHandler(pagar);
                btn.Show();
            }
        }

        private void pagar(object sender, EventArgs e)
        {
            if (Main.dinero.Text != "0")
                abrirForm(new Subtotal());
            else
                MessageBox.Show("Debe agregar un producto primero");
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
            gal.Dispose();
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


        public void cerrarSesionM(object sender, EventArgs e)
        {
            Usuario.Activo = null;
            Application.Restart();
        }



    }
}
