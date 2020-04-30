using System;
using System.Text;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Campos

        private ETipo tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará el tamaño de Auto
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Mediano; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Constructor por defecto, inicializa los atributos del Vehículo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) :
            base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor por defecto, inicializa los atributos del Vehículo y el tipo como "Monovolumen"
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.Monovolumen) { }

        /// <summary>
        /// Devuelve todos los datos del Automovil.
        /// </summary>
        /// <returns>Datos del Automovil en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0} \n", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Tipos Anidados

        public enum ETipo { Monovolumen, Sedan }

        #endregion

    }
}
