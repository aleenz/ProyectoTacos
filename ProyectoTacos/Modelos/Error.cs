using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Error
    {

        private string desc;
        public string Descripcion { get => desc; set => desc = value; }


        public Error(string error)
        {
            this.desc = error;
        }
    }
}
