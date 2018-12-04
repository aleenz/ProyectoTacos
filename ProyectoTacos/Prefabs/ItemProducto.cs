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
    class ItemProducto : Panel
    {
        int id = 0;
        Ventas_Catalogo frm;
        public ItemProducto(Ventas_Catalogo frm, string texto, string st, int tag, Image img, Point p)
        {
            this.frm = frm;
            id = tag;
            this.Size = new Size(230, 150);
            this.Location = p;
            this.BackColor = Color.Orange;
            this.Parent = frm;
            this.Tag = id;

            this.Show();

            Panel cover = new Panel();
            cover.Parent = this;
            cover.Size = new Size(cover.Parent.Size.Width - 4, 50);
            cover.Location = new Point(2, 98);
            cover.BackColor = Color.White;
            cover.Tag = id;
            cover.Click += new EventHandler(clicItem);
            cover.Show();

            Label stitulo = new Label();
            stitulo.Text = st;
            stitulo.Font = new Font("Arial", 8f);
            stitulo.Size = new Size(cover.Width, 20);
            stitulo.ForeColor = Color.Gray;
            stitulo.Parent = cover;
            stitulo.Location = new Point(0, 28);
            stitulo.TextAlign = ContentAlignment.TopCenter;
            stitulo.Tag = id;
            stitulo.Click += new EventHandler(clicItem);
            stitulo.Show();

            Label titulo = new Label();
            titulo.Text = texto;
            titulo.Font = new Font("Arial", 12f, FontStyle.Bold);
            titulo.Size = new Size(cover.Width, 30);
            titulo.ForeColor = Color.Orange;
            titulo.Parent = cover;
            titulo.Tag = id;
            titulo.Location = new Point(0, 2);
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Click += new EventHandler(clicItem);
            titulo.Show();

            PictureBox img_fondo = new PictureBox();
            img_fondo.Parent = this;
            img_fondo.Size = new Size(this.Width - 4, this.Height - 4);
            img_fondo.Location = new Point(2, 2);
            img_fondo.Image = img;
            img_fondo.Tag = id;
            img_fondo.SizeMode = PictureBoxSizeMode.StretchImage;
            img_fondo.Click += new EventHandler(clicItem);
            img_fondo.Show();

           
        }

        private void clicItem(object sender, EventArgs e)
        {
            int i = Convert.ToInt16((sender as Control).Tag);
            frm.abrirAnadir(i);
        }
    }
}
