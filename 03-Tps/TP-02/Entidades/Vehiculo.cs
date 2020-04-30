using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Campos

        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará el tamaño de Vehiculo
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        #endregion

        #region Métodos

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Transforma un objeto de tipo Vehiculo a String.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></Vehiculo 1>
        /// <param name="v2"></Vehiculo 2>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></Vehiculo 1>
        /// <param name="v2"></Vehiculo 2>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Constructor parametrizado, inicializa los atributos del Objeto.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Tipos de Marcas Disponibles para Vehículo
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        /// <summary>
        /// Tipos de Tamaños Disponibles para Vehículo
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #endregion
    }
}
