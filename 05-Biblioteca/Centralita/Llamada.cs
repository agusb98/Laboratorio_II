using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public abstract class Llamada
    {
        #region Nested types

        public enum TipoLlamada { Local, Provincial, Todas }
        #endregion

        #region Fields

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        #endregion

        #region Properties

        /// <summary>
        /// Metodo abstracto, obtiene Costo de LLamada
        /// </summary>
        /// <returns></returns>
        public abstract float CostoLlamada { get; }

        /// <summary>
        /// Obtiene duracion de Llamada
        /// </summary>
        public float Duracion
        {
            get { return this.duracion; }
        }

        /// <summary>
        /// Obtiene Numero Destino de Llamada
        /// </summary>
        public string NroDestino
        {
            get { return this.nroDestino; }
        }

        /// <summary>
        /// Obtiene Numero Origen de Llamada
        /// </summary>
        public string NroOrigen
        {
            get { return this.nroOrigen; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Instancia nueva Llamadas a partir de los atributos por parametros
        /// </summary>
        /// <param name="duracion"></param>
        /// <param name="nroDestino"></param>
        /// <param name="nroOrigen"></param>
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        /// <summary>
        /// Muestra los atributos de una Llamada
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Duracion: " + Duracion);
            str.AppendLine("Numero Destino: " + NroDestino);
            str.AppendLine("Numero Origen: " + NroOrigen);

            return str.ToString();
        }

        /// <summary>
        /// Ordena una lista de llamadas de forma ascendente.
        /// </summary>
        /// <param name="llamada1"></param>
        /// <param name="llamada2"></param>
        /// <returns></returns>
        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if (llamada1.Duracion < llamada2.Duracion)
            {
                return -1;
            }
            else if (llamada1.Duracion == llamada2.Duracion)
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// Valida igualdad entre dos Llamadas
        /// </summary>
        /// <param name="llamada1"></param>
        /// <param name="llamada2"></param>
        /// <returns></returns>
        public static bool operator ==(Llamada llamada1, Llamada llamada2)
        {
            bool flag1 = llamada1.Equals(llamada2);
            bool flag2 = llamada1.NroOrigen == llamada2.NroOrigen;
            bool flag3 = llamada1.NroDestino == llamada2.NroDestino;

            return (flag1 && flag2);
        }

        /// <summary>
        /// Valida igualdad entre dos Llamadas
        /// </summary>
        /// <param name="llamada1"></param>
        /// <param name="llamada2"></param>
        /// <returns></returns>
        public static bool operator !=(Llamada llamada1, Llamada llamada2)
        {
            return !(llamada1 == llamada2);
        }
        #endregion
    }
}
