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
        private int idproducto;
        private int idmatep;
        private string nombre;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Unidadmed { get => unidadmed; set => unidadmed = value; }
        public int Idproducto { get => idproducto; set => idproducto = value; }
        public int Idmatep { get => idmatep; set => idmatep = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
