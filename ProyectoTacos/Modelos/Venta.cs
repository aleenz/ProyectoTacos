using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    public class Venta
    {
        private int idventa;
        private int status;
        private DateTime fecha;
        private Double total;
        private int idcliente;
        private int idempleado;
        private int metodo;

        public int Idventa { get => idventa; set => idventa = value; }
        public int Status { get => status; set => status = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Total { get => total; set => total = value; }
        public int Idcliente { get => idcliente; set => idcliente = value; }
        public int Idempleado { get => idempleado; set => idempleado = value; }
        public int Metodo { get => metodo; set => metodo = value; }
    }
}
