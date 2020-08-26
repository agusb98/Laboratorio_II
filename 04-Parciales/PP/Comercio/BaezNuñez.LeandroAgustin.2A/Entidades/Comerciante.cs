using System;
using System.Text;

namespace Entidades
{
    public class Comerciante
    {
        #region Atributos

        private string apellido;
        private string nombre;

        #endregion

        #region Constructores
        public Comerciante(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion

        #region Metodos

        public static implicit operator string(Comerciante a)
        {
            StringBuilder sb = new StringBuilder();

            if (!(a is null))
            {
                sb.AppendFormat("{0}, {1}", a.nombre, a.apellido);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida desigualdad entre dos comerciantes
        /// </summary>
        /// <param name="a"></Comerciante 1>
        /// <param name="b"></Comerciante 2>
        /// <returns></returns>
        public static bool operator !=(Comerciante a, Comerciante b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Valida igualdad entre dos comerciantes
        /// </summary>
        /// <param name="a"></Comerciante 1>
        /// <param name="b"></Comerciante 2>
        /// <returns></returns>
        public static bool operator ==(Comerciante a, Comerciante b)
        {
            return a.nombre == b.nombre && a.apellido == b.apellido;
        }

        #endregion
    }
}
