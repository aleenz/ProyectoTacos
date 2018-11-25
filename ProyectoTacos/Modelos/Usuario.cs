using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTacos.Modelos
{
    class Usuario
    {

        private Persona persona;
        private string nombre;
        private int rol;
        private static Usuario activo;

        public Persona Persona { get => persona; set => persona = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public int Rol { get => rol; set => rol = value; }

        public static string toMD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static Usuario Activo { get => activo; set => activo = value; }
    }
}
