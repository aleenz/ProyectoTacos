using ProyectoTacos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Prefabs
{
    public class ProductoVenta
    {
        private int cantidad;
        private Producto producto;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Producto Producto { get => producto; set => producto = value; }

    }
}
