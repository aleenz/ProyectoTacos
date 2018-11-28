using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    public class MateriaPrima
    {
        private int idmateria;
        private string nombre;
        private string unidadmed;
        private int inventario;
        private Double costomed;
        private int status;

        public int Idmateria { get => idmateria; set => idmateria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Unidadmed { get => unidadmed; set => unidadmed = value; }
        public int Inventario { get => inventario; set => inventario = value; }
        public Double Costomed { get => costomed; set => costomed = value; }
        public int Status { get => status; set => status = value; }
    }
}
