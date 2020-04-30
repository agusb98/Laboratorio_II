using System;
using System.Text;

namespace Biblioteca
{
    public class AutoF1 : VehiculoDeCarreras
    {
        #region Fields

        private short caballosDeFuerza;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene/Modifica Caballos de Fuerza de un AutoF1
        /// </summary>
        public short CaballosDeFuerza
        {
            get
            {
                return this.caballosDeFuerza;
            }
            set
            {
                if (value >= 0)
                {
                    this.caballosDeFuerza = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// /Instancia Nuevo Auto de F1
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="escuderia"></param>
        public AutoF1(short numero, string escuderia) : base(numero, escuderia) { }

        /// <summary>
        /// Instancia nuevo Auto de F1
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="escuderia"></param>
        /// <param name="caballosDeFuerza"></param>
        public AutoF1(short numero, string escuderia, short caballosDeFuerza) :
            this(numero, escuderia)
        {
            this.CaballosDeFuerza = caballosDeFuerza;
        }

        /// <summary>
        /// Muestra los atributos de un Auto de F1
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Caballos de Fuerza: " + CaballosDeFuerza);
            str.Append(base.Mostrar());

            return str.ToString();
        }

        /// <summary>
        /// Valida igualdad entre dos Autos F1
        /// </summary>
        /// <param name="a"><Auto 1/param>
        /// <param name="b"><Auto 2/param>
        /// <returns></returns>
        public static bool operator ==(AutoF1 a, AutoF1 b)
        {
            VehiculoDeCarreras a1 = (VehiculoDeCarreras)a;
            VehiculoDeCarreras b1 = (VehiculoDeCarreras)b;

            return a1 == b1 && a.CaballosDeFuerza == b.CaballosDeFuerza;
        }
        /// <summary>
        /// Valida desigualdad entre dos Autos F1
        /// </summary>
        /// <param name="a"><Auto 1/param>
        /// <param name="b"><Auto 2/param>
        /// <returns></returns>
        public static bool operator !=(AutoF1 a, AutoF1 b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Verifica igualdad 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is AutoF1 && this == (AutoF1)obj;
        }
        #endregion
    }
}
