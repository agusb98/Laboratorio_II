using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Calculadora
{
    public class Numero
    {
        double value;

        /// <summary>
        /// Nueva instancia de un objeto Numero. Inicializa en 0.
        /// </summary>
        public Numero()
        {

        }
        /// <summary>
        /// Nueva instancia de un objeto Numero. Toma el número ingresado como valor.
        /// </summary>
        /// <param name="numero">El dato ingresado será el valor.</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }
        /// <summary>
        /// Nueva instancia de un objeto Numero. Toma una cadena y la transforma en dato numérico.
        /// </summary>
        /// <param name="strNumero">El dato se transforma en número. Si falla, el valor que toma es 0.</param>
        public Numero(string strNumero)
        {
            strNumero = strNumero.Replace('.', ',');
            this.Value = strNumero;
        }


        /// <summary>
        /// Propiedad set.
        /// </summary>
        private string Value
        {
            set
            {
                if (double.TryParse(value, out double result))
                {
                    this.value = result;
                }
            }
            get
            {
                return this.value.ToString();
            }
        }

        public static implicit operator Numero(string num)
        {
            return new Numero(num);
        }

        public static implicit operator Numero(double d)
        {
            return new Numero(d);
        }

        public static implicit operator string(Numero num)
        {
            return num.Value;
        }

        public static implicit operator double(Numero num)
        {
            double.TryParse(num, out double result);
            return result;
        }

        // Operadores
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.value - n2.value;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.value * n2.value;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.value / n2.value;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.value + n2.value;
        }
        public static bool operator ==(Numero n1, Numero n2)
        {
            return n1.value == n2.value;
        }
        public static bool operator !=(Numero n1, Numero n2)
        {
            return !(n1 == n2);
        }
    }
}


