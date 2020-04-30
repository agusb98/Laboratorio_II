using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Provincial : Llamada
    {

        #region Nested Types

        public enum Franja { Franja_1, Franja_2, Franja_3 }
        #endregion

        #region Fields

        protected Franja franjaHoraria;
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
        {
            switch (this.franjaHoraria)
            {
                case Franja.Franja_1:
                    return (float)0.99 * Duracion;

                case Franja.Franja_2:
                    return (float)1.25 * Duracion;

                case Franja.Franja_3:
                    return (float)0.66 * Duracion;
            }
            return 0;
        }

        /// <summary>
        /// Instancia Llamada tipo Provincial
        /// </summary>
        /// <param name="miFranja"></param>
        /// <param name="llamada"></param>
        public Provincial(Franja miFranja, Llamada llamada) :
            this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino)
        { }

        /// <summary>
        /// Instancia Llamada de tipo Provincial
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="miFranja"></param>
        /// <param name="duracion"></param>
        /// <param name="destino"></param>
        public Provincial(string origen, Franja miFranja, float duracion, string destino) :
            base(duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }

        /// <summary>
        /// Muestra los atributos de una Llamada Provincial
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.Mostrar());
            str.AppendLine("Franja Horaria: " + franjaHoraria);
            str.AppendLine("Costo Llamada: " + CostoLlamada);

            return str.ToString();
        }

        /// <summary>
        /// Valida si el objeto recibido es de tipo Provincial
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Provincial);
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
