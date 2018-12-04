using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    public  class provedoor
    {

        private int status;
        private int idproveedor;
        private string rfc;
        private string nombre;
        private string correo;
        private string telefono;
        private string materiap;
        private string domicilio;
        private string colonia;
        private string calle;
        private string numero;
        private int cp;



        public int Idproveedo { get => idproveedor; set => idproveedor = value; }
        public int Status { get => status; set => status = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Correo { get => correo; set => correo = value; }
        public String Telefono { get => telefono; set => telefono = value; }
        public  String Materiap{ get => materiap; set => materiap = value; }
        public String Domicilio { get => domicilio; set => domicilio = value; }
        public String Colonia { get => colonia; set => colonia = value; }
        public String Calle { get => calle; set => calle = value; }
        public String Numero { get => numero; set => numero = value; }

        public int Cp { get => cp; set => cp = value; }
    }
}
