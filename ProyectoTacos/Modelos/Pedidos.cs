using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
  public  class Pedidos


    {
        private int idpedido;
        private DateTime fecha;
        private DateTime fecharec;
        private int status;
        private int idproveedor;
        private int idempleado;
        private Double total;
        private Double cantidad;
        private Double preciounit;
        private Double preciocant;
        private int idmateria;
        private string materia;



        public int Idpedido { get => idpedido; set => idpedido = value; }
        public int Status { get => status; set => status = value; }
        public int Idproveedor { get => idproveedor; set => idproveedor = value; }
        public int Idempleado { get => idempleado; set => idempleado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Fecharec { get => fecharec; set => fecharec = value; }
        public Double Total { get => total; set => total = value; }
        public Double Preciounit { get => preciounit; set => preciounit = value; }
        public Double Preciocant { get => preciocant; set => preciocant = value; }
        public Double Cantidad { get => cantidad; set => cantidad = value; }
        public int Idmateria { get => idmateria; set => idmateria = value; }
        public string Materia { get => materia; set => materia = value; }




    }
}
