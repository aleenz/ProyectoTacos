using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Cliente : Persona
    {
        private int idCliente;
        private DateTime fechaIng;
        private string email;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public DateTime FechaIng { get => fechaIng; set => fechaIng = value; }

        public string Email { get => email; set => email = value; }
    }
}
