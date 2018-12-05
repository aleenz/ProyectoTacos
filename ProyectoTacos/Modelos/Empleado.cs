using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Empleado : Persona
    {
        private int idempleado;

        private DateTime fechaIng;

        public DateTime FechaIng {get => fechaIng; set => fechaIng = value;}

        public int IdEmpleado { get => idempleado; set => idempleado = value; }
    }
}
