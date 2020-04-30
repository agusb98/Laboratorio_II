using System;
using System.Text;

namespace Biblioteca
{
    public class MotoCross : VehiculoDeCarreras
    {
        #region Fields

        private short cilindrada;

        #endregion

        #region Methods

        /// <summary>
        /// /Instancia Nuevo MotoCross
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="escuderia"></param>
        public MotoCross(short numero, string escuderia) : base(numero, escuderia) { }

        /// <summary>
        /// Instancia nuevo MotoCross
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="escuderia"></param>
        /// <param name="cilindrada"></param>
        public MotoCross(short numero, string escuderia, short cilindrada) :
            this(numero, escuderia)
        {
            this.Cilindrada = cilindrada;
        }

        /// <summary>
        /// Muestra los atributos de un Motocross
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Cilindrada: " + Cilindrada);
            str.Append(base.Mostrar());

            return str.ToString();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Obtiene/Modifica Cilindrada de un Motocross
        /// </summary>
        public short Cilindrada
        {
            get
            {
                return this.cilindrada;
            }
            set
            {
                if (value >= 0)
                {
                    this.cilindrada = value;
                }
            }
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Valida igualdad entre dos Motocross
        /// </summary>
        /// <param name="a"><Motocross 1/param>
        /// <param name="b"><Motocross 2/param>
        /// <returns></returns>
        public static bool operator ==(MotoCross a, MotoCross b)
        {
            VehiculoDeCarreras a1 = (VehiculoDeCarreras)a;
            VehiculoDeCarreras b1 = (VehiculoDeCarreras)b;

            return a1 == b1 && a.Cilindrada == b.Cilindrada;
        }
        /// <summary>
        /// Valida desigualdad entre dos Motocross
        /// </summary>
        /// <param name="a"><Motocross 1/param>
        /// <param name="b"><Motocross 2/param>
        /// <returns></returns>
        public static bool operator !=(MotoCross a, MotoCross b)
        {
            return !(a == b);
        }

        #endregion
    }
}
