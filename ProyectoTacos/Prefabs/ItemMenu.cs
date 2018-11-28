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

        public ItemMenu(Main frm, string texto, int tag, Bitmap img, int y)
        {
            
            this.Size = new Size(frm.anchoBandaDerecha - 40, 65);
            this.Location = new Point(2, y);
            this.Parent = frm.p;
            this.MouseEnter += new EventHandler(frm.MouseSobre);
            this.MouseLeave += new EventHandler(frm.MouseSale);
            this.Tag = tag;
            this.Click += new EventHandler(frm.OnClick);
            this.Show();


            PictureBox pb = new PictureBox();
            pb.Image = img;
            pb.Size = new Size(45, 45);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            pb.Parent = this;
            pb.Show();

            Label l = new Label();
            l.Text = texto;
            l.Font = new Font("Arial", 12f);
            l.Size = new Size(frm.anchoBandaDerecha - 115, 50);
            l.ForeColor = Color.Black;
            l.Parent = this;
            l.Location = new Point(75, 22);
            l.Show();
        }

    }
}
