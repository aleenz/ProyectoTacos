using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Usomateria
    {
        private int cantidad;
        private string unidadmed;
        private Producto producto;
        private MateriaPrima matep;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Unidadmed { get => unidadmed; set => unidadmed = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public MateriaPrima Matep { get => matep; set => matep = value; }
    }
}
