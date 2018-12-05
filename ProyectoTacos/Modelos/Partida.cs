using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Partida
    {
        private int cantidad;
        private string nombre;
        private Double costo;
        private int idventa;
        private int idproducto;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Costo { get => costo; set => costo = value; }
        public int Idventa { get => idventa; set => idventa = value; }
        public int Idproducto { get => idproducto; set => idproducto = value; }
    }
}
