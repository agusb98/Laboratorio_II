using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Tempera
    {
        #region Fields

        private ConsoleColor color = new ConsoleColor();
        public string marca;
        public int cantidad;

        #endregion
        #region Methods

        /// <summary>
        /// Inicializa los campos de Tempera
        /// </summary>
        /// <param name="color"></param>
        /// <param name="marca"></param>
        /// <param name="cantidad"></param>
        public Tempera(ConsoleColor color, string marca, int cantidad)
        {
            this.color = color;
            this.marca = marca;
            this.cantidad = cantidad;
        }

        /// <summary>
        /// Retorna en entero la cantidad de tempera
        /// </summary>
        /// <param name="t"></param>
        public static implicit operator int(Tempera t)
        {
            return (int)t.cantidad;
        }

        /// <summary>
        /// Muestra los valores de una Tempera y los retorna en String
        /// </summary>
        /// <param name="t"><Tempera/param>
        /// <returns></returns>
        public static string Mostrar(Tempera t)
        {
            StringBuilder str = new StringBuilder();

            if (!(t is null))
            {
                str.AppendLine(String.Format(t.color + " " + t.marca + " " + t.cantidad));
            }

            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Temperas
        /// </summary>
        /// <param name="t1"><Tempera 1/param>
        /// <param name="t2"><Tempera 2/param>
        /// <returns></returns>
        public static bool operator ==(Tempera t1, Tempera t2)
        {
            if ((t1 is null) && (t2 is null))
            {
                return true;
            }
            else if (!(t1 is null) && !(t2 is null))
            {
                if (t1.marca == t2.marca && t1.color == t2.color)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validad desigualdad entre Temperas 
        /// </summary>
        /// <param name="t1"><Tempera 1/param>
        /// <param name="t2"><Tempera 2/param>
        /// <returns></returns>
        public static bool operator !=(Tempera t1, Tempera t2)
        {
            return !(t1 == t2);
        }

        /// <summary>
        /// Acumula cantidad de tinta en Tempera 1 en el caso de ser iguales
        /// </summary>
        /// <param name="t1"><Tempera 1/param>
        /// <param name="t2"><Tempera 2/param>
        /// <returns></returns>
        public static Tempera operator +(Tempera t1, Tempera t2)
        {
            if (t1 == t2)
            {
                t1.cantidad += t2.cantidad;
            }

            return t1;
        }

        /// <summary>
        /// Acumula cantidad a Tempera 
        /// </summary>
        /// <param name="t"><Tempera/param>
        /// <param name="cantidad">acumulador</param>
        /// <returns></returns>
        public static Tempera operator +(Tempera t, int cantidad)
        {
            if (!(t is null))
            {
                t.cantidad += cantidad;
            }

            return t;
        }


        #endregion
    }
}