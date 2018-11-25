using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Persona { 



        private int idpersona;
        private string nombre;
        private string apaterno;
        private string amaterno;
        private DateTime fechanac;
        private string genero;
        private Domicilio domicilio;
        private string telefono;

        public int IdPersona { get => idpersona; set => idpersona = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apaterno { get => apaterno; set => apaterno = value; }
        public string Amaterno { get => amaterno; set => amaterno = value; }
        public DateTime FechaNac { get => fechanac; set => fechanac = value; }
        public string Genero { get => genero; set => genero = value; }
        public Domicilio Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }



    }
}
