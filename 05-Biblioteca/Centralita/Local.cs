using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Local : Llamada
    {
        #region Fields

        protected float costo;
        #endregion

        #region Properties

        /// <summary>
        /// Retorna el Costo de Llamada
        /// </summary>
        public override float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        #endregion

        #region Methods

        /// <summary>
        ///  Retorna el valor de la Llamada a partir de la Duración y el Costo de la misma
        /// </summary>
        /// <returns></returns>
        private float CalcularCosto()
        { return this.costo * this.duracion; }

        /// <summary>
        /// Instancia Llamada tipo Local
        /// </summary>
        /// <param name="llamada"></param>
        /// <param name="costo"></param>
        public Local(Llamada llamada, float costo) :
            this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        { }

        /// <summary>
        /// Instancia Llamada de tipo Local
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="duracion"></param>
        /// <param name="destino"></param>
        /// <param name="costo"></param>
        public Local(string origen, float duracion, string destino, float costo) :
            base(duracion, destino, origen)
        { this.costo = costo; }

        /// <summary>
        /// Muestra los atributos de una Llamada Local
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.Mostrar());
            str.AppendLine("Costo: " + CostoLlamada);

            return str.ToString();
        }

        /// <summary>
        /// Valida si el objeto recibido es de tipo Local
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Local);
        }

        /// <summary>
        /// Sobreescribe método Mostrar, reutilizando código en la clase base
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
