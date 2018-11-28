using ProyectoTacos.Vistas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Prefabs
{
    class ItemMenu : Panel
    {
        Panel panelBorde;
        Main frm;
        public ItemMenu(Main frm, string texto, int tag, Bitmap img, int y)
        {
            this.frm = frm;
            this.Size = new Size(frm.anchoBandaDerecha - 40, 65);
            this.Location = new Point(20, y);
            this.Parent = frm.p;
            this.MouseEnter += new EventHandler(MouseSobre);
            this.MouseLeave += new EventHandler(MouseSale);
            this.Tag = tag;
            this.Click += new EventHandler(OnClick);
            this.Show();


            PictureBox pb = new PictureBox();
            pb.Image = img;
            pb.Size = new Size(45, 45);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.MouseEnter += new EventHandler(MouseSobre);
            pb.MouseLeave += new EventHandler(MouseSale);
            pb.Click += new EventHandler(OnClick);
            pb.Tag = tag;
            pb.Parent = this;
            pb.Show();

            Label l = new Label();
            l.Text = texto;
            l.Font = new Font("Arial", 12f);
            l.Size = new Size(frm.anchoBandaDerecha - 115, 50);
            l.ForeColor = Color.Black;
            l.MouseEnter += new EventHandler(MouseSobre);
            l.MouseLeave += new EventHandler(MouseSale);
            l.Click += new EventHandler(OnClick);
            l.Parent = this;
            l.Tag = tag;
            l.Location = new Point(75, 22);
            l.Show();
        }



        public void MouseSobre(object sender, EventArgs e)
        {

            Panel p = sender as Panel;

            panelBorde = new Panel();
            panelBorde.BackColor = Color.LightGray;
            panelBorde.Size = new Size(this.Width + 2, this.Height + 2);
            panelBorde.Location = new Point(this.Location.X - 1,this.Location.Y - 1);
            panelBorde.Parent = this.Parent;

            panelBorde.Show();


        }

        public void MouseSale(object sender, EventArgs e)
        {

            panelBorde.Dispose();

        }

        public void OnClick(object sender, EventArgs e)
        {
            int i = Convert.ToInt16((sender as Control).Tag);

            Form f = frm.formsMenu[i];
            
            frm.abrirForm(f);

        }
    }
}