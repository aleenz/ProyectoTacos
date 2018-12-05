using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    public class Domicilio
    {
        private string calle;
        private string ciudad;
        private string estado;
        private string colonia;
        private string cp;
        private string numero;


        public string Calle { get => calle; set => calle = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string CP { get => cp; set => cp = value; }
        public string Numero { get => numero; set => numero = value; }

    }
}
