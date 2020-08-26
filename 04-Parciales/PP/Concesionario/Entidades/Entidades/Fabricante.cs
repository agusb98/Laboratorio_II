using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        /// <summary>
        /// Instancia Fabricante
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="pais"></param>
        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }

        /// <summary>
        /// retorna cadena string con datos del fabricante
        /// </summary>
        /// <param name="f"></param>
        public static implicit operator string(Fabricante f)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nFABRICANTE: {0} - {1}", f.marca, f.pais);

            return sb.ToString();
        }

        /// <summary>
        /// Valida igualdad de dos fabricantes
        /// </summary>
        /// <param name="a"></Fabricante 1>
        /// <param name="b"></Fabricante 2>
        /// <returns></true si son iguales, false si no>
        public static bool operator ==(Fabricante a, Fabricante b)
        {
            return a.marca == b.marca && a.pais == b.pais;
        }

        /// <summary>
        /// Valida desigualdad de dos fabricantes
        /// </summary>
        /// <param name="a"></Fabricante 1>
        /// <param name="b"></Fabricante 2>
        /// <returns></false si son iguales, true si no>
        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }
    }
}
