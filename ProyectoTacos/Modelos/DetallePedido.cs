using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class DetallePedido
    {
        private string nombre;
        private int cantidad;
        private Double preciounit;
        private Double preciocant;
        private int idpedido;
        private int idmateria;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Preciounit { get => preciounit; set => preciounit = value; }
        public double Preciocant { get => preciocant; set => preciocant = value; }
        public int Idpedido { get => idpedido; set => idpedido = value; }
        public int Idmateria { get => idmateria; set => idmateria = value; }

    }
}
