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
        public Form[] formsMenu = { new RegistrarCliente(new Form()), new RegistrarMateriaP()};
        Form actual = null;
        public Panel p;
        public int anchoBandaDerecha = 300;
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

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
            titulo.Font = new Font("Arial", 12f);
            titulo.Parent = barraArriba;
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Show();
            p = new Panel();
            p.Size = new Size(anchoBandaDerecha, this.Size.Height);
            p.Location = new Point(0, 0);
            p.BackColor = Color.White;
            p.Parent = this;
            p.Show();

            ItemMenu registroClientes = new ItemMenu(this, "Registro nuevo Cliente", 0, new Bitmap(ProyectoTacos.Properties.Resources.logo), 60);
            ItemMenu registroMateria = new ItemMenu(this, "Registro nuevo materia", 1, new Bitmap(ProyectoTacos.Properties.Resources.logo1), 140);



        }



        

        public void abrirForm(Form frm)
        {
            if(actual!= null)
            {
                actual.Hide();
                actual = null;
            }
            

            actual = frm;
            actual.MdiParent = this;
            //actual.FormBorderStyle = FormBorderStyle.None;
            int posx = (((this.Width - anchoBandaDerecha) / 2) - (actual.Width / 2)) + anchoBandaDerecha;
            int posy = (this.Height / 2) - (actual.Height / 2);
            actual.Location = new Point(posx, posy);
            actual.Show();
        }



    }
}
