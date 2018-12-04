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
        private Double costo;
        private int idventa;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public Double Costo { get => costo; set => costo = value; }
        public int Idventa { get => idventa; set => idventa = value; }
    }
}
