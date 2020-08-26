using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        protected string apellido;
        protected string nombre;

        /// <summary>
        /// Instancia nombre y apellido de Autor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public Autor(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        /// <summary>
        /// obtiene implicitamente nombre y apellido a string 
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator string (Autor a)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}, {1}", a.nombre, a.apellido);

            return sb.ToString();
        }

        /// <summary>
        /// Valida igualdad entre dos autores
        /// </summary>
        /// <param name="a"></Autor 1>
        /// <param name="b"></Autor 2>
        /// <returns></True if name and surname son iguales, else false>
        public static bool operator ==(Autor a, Autor b)
        {
            return a.nombre == b.nombre && a.apellido == b.apellido;
        }

        /// <summary>
        /// Valida desigualdad entre dos autores
        /// </summary>
        /// <param name="a"></Autor 1>
        /// <param name="b"></Autor 2>
        /// <returns></False if name and surname son iguales, else true>
        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }
    }
}
