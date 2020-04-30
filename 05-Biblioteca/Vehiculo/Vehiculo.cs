using System;
using System.Text;

namespace Biblioteca
{
    public abstract class Vehiculo
    {
        #region Nested types

        /// <summary>
        /// Cantidad de Colores (5)
        /// </summary>
        public enum EColores { Rojo, Blanco, Azul, Gris, Negro }
        #endregion

        #region Fields

        protected string patente;
        protected byte cantRuedas;
        protected EColores color;

        #endregion

        #region Properties

        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                this.patente = value;
            }
        }

        public byte CantRuedas
        {
            get
            {
                return this.cantRuedas;
            }
            set
            {
                if (value > 0)
                    this.cantRuedas = value;
            }
        }

        public EColores Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Instancia Vehiculo con atributos vacios
        /// </summary>
        public Vehiculo() : this(string.Empty, 0, 0) { }

        /// <summary>
        /// Instancia Vehiculo
        /// </summary>
        /// <param name="v"></param>
        public Vehiculo(string patente, byte cantRuedas, EColores color)
        {
            this.Patente = patente;
            this.CantRuedas = cantRuedas;
            this.Color = color;
        }

        /// <summary>
        /// Muestra por pantalla los atributos de un Vehiculo
        /// </summary>
        /// <returns></returns> string de lo mostrado por pantalla
        protected virtual string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Patente: " + Patente);
                str.AppendLine("Cantidad de Ruedas: " + CantRuedas);
                str.AppendLine("Color: " + Color);
            }

            return str.ToString();
        }

        /// <summary>
        /// Valida igualdad dentre dos Vehiculos
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.Patente == v2.Patente;
        }

        /// <summary>
        /// Valida desigualdad dentre dos Vehiculos
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Verifica igualdad 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vehiculo)
            {
                return this == (Vehiculo)obj;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
