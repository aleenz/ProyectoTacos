using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Modelos
{
   public class Producto
    {
        private int idproducto;
        private string nombre;
        private string descripcion;
        private Double precioun;
        private PictureBox foto;
        private int status;

        public int Idproducto { get => idproducto; set => idproducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Double Precioun { get => precioun; set => precioun = value; }
        public PictureBox Foto { get => foto; set => foto = value; }
        public int Status { get => status; set => status = value; }
    }
}
