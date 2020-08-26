using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Exportador : Comercio
    {
        #region Atributos

        public ETipoProducto tipo;

        #endregion

        #region Constructores

        public Exportador(string nombreComercio, float precioAlquiler, string nombre, string apellido, ETipoProducto tipo) :
            base(precioAlquiler, nombreComercio, nombre, apellido)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Metodos

        public static implicit operator double(Exportador d)
        {
            return d._precioAlquiler;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat((string)this);
            sb.AppendFormat("\nTIPO: {0}", this.tipo);

            return sb.ToString();
        }

        /// <summary>
        /// Valida desigualdad entre dos exportadores
        /// </summary>
        /// <param name="a"></Exportador 1>
        /// <param name="b"></Exportador 2>
        /// <returns></returns>
        public static bool operator !=(Exportador a, Exportador b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Valida igualdad entre dos exportadores
        /// </summary>
        /// <param name="a"></Exportador 1>
        /// <param name="b"></Exportador 2>
        /// <returns></returns>
        public static bool operator ==(Exportador a, Exportador b)
        {
            if (a.tipo == b.tipo && (Comercio)a == b)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}