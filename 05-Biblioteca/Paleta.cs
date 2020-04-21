using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Paleta
    {
        #region Fields

        private Tempera[] temperas;
        public int cantidadMaxColores;

        #endregion

        #region Methods

        public Paleta()
        {
            this.cantidadMaxColores = 5;
            this.temperas = new Tempera[this.cantidadMaxColores];
        }

        /// <summary>
        /// Retorna la cantidad maxima de colores en int
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator int(Paleta p)
        {
            return p.cantidadMaxColores;
        }

        /// <summary>
        /// Muestra las Temperas dentro de la Paleta y retorna en tipo String
        /// </summary>
        /// <param name="p"><Paleta/param>
        public static string Mostrar(Paleta p)
        {
            return (string)p;
        }

        /// <summary>
        /// Retorna Paleta en string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Paleta p)
        {
            StringBuilder str = new StringBuilder();

            if (!(p is null))
            {
                str.AppendLine(String.Format("Paleta de {0} colores:", (int)p));
                str.AppendLine(String.Format("Colores dentro de la Paleta: "));
                str.AppendLine();

                for (int i = 0; i < p.cantidadMaxColores; i++)
                    str.AppendLine(Tempera.Mostrar(p.temperas[i]));
            }

            return str.ToString();
        }

        /// <summary>
        /// Valida igualdad entre paleta y tempera
        /// </summary>
        /// <param name="p"><Paleta/param>
        /// <param name="t"><Tempera/param>
        /// <returns></returns>
        public static bool operator ==(Paleta p, Tempera t)
        {
            if (!(p is null) && !(t is null))
            {
                for (int i = 0; i < p.temperas.Length; i++)
                {
                    if (p.temperas[i] == t)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Valida desigualdad entre paleta y tempera
        /// </summary>
        /// <param name="p"><Paleta/param>
        /// <param name="t"><Tempera/param>
        /// <returns></returns>
        public static bool operator !=(Paleta p, Tempera t)
        {
            return !(p == t);
        }

        /// <summary>
        /// Obtiene la posicion del primer lugar libre dentro de Temperas
        /// </summary>
        /// <returns></returns>
        private int ObtenerLugarLibre()
        {
            for (int i = 0; i < this.temperas.Length; i++)
            {
                if (this.temperas[i] == null)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Obtiene la posicion de la tempera dentro de la paleta
        /// </summary>
        /// <param name="t"><Tempera/param>
        /// <returns></returns>
        private int ObtenerIndice(Tempera t)
        {
            for (int i = 0; i < this.temperas.Length; i++)
            {
                if (this.temperas[i] == null)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// incrementa cantidad en tempera, si no, agrega la tempera en el primer lugar disponible
        /// </summary>
        /// <param name="p"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Paleta operator +(Paleta p, Tempera t)
        {
            int index = p.ObtenerIndice(t);

            if (index > -1)
            {
                t.cantidad += p.temperas[index];
            }
            else
            {
                index = p.ObtenerLugarLibre();
                t.cantidad += p.temperas[index];
            }

            return p;
        }

        /// <summary>
        /// decrementa cantidad de Tempera en Paleta, en caso de catidad <= 0, se elimina Tempera
        /// </summary>
        /// <param name="p"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Paleta operator -(Paleta p, Tempera t)
        {
            int index = p.ObtenerIndice(t);

            if (t.cantidad <= 0)
            {
                t = null;
            }
            else if (index > -1)
            {
                t.cantidad -= p.temperas[index];
            }

            return p;
        }

        /// <summary>
        /// Crea una nueva Paleta a partir de los valores de Paleta 1 y Paleta 2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Paleta operator +(Paleta p1, Paleta p2)
        {
            Paleta p3 = new Paleta();

            if (!(p1 is null) && !(p2 is null))
            {
                for (int i = 0; i < p2.temperas.Length; i++)
                {
                    p3 = p1 + p2.temperas[i];
                }
            }

            return p3;
        }

        #endregion
    }
}
