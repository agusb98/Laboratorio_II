using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;

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
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad set.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Getter, retorna el valor del atributo numero.
        /// </summary>
        /// <returns>Valor del atributo número.</returns>
        public double GetNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Valida que la cadena ingresada por parámetro sea un número.
        /// </summary>
        /// <param name="strNumero">Cadena a ser validada.</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            if (double.TryParse(strNumero, out double result) == true)
                retorno = result;

            return retorno;
        }

        /// <summary>
        /// Convierte un número binario a decimal.
        /// </summary>
        /// <param name="binario">El número a convertir debe ser ingresado con , y no con .</param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string strAuxiliar = binario;

            if (double.TryParse(binario, out double numero) == true && System.Text.RegularExpressions.Regex.IsMatch(binario, "[0-1]"))
            {
                // Corro las comas.
                int cantidadDeComas;
                cantidadDeComas = NewMethod(ref strAuxiliar, ref numero);

                int length = strAuxiliar.Length;
                int digito;
                numero = 0;

                for (int i = 1; i <= length; i++)
                {
                    // El parámetro del Convert me asegura que se convierta desde el bit menos significativo
                    // al bit más significativo.
                    // 49 es el ascii de 1, 48 es el ascii de 0.
                    digito = Convert.ToInt32(strAuxiliar[length - i]) - 48;
                    numero += digito * Convert.ToDouble((Math.Pow(2, (i - 1) - cantidadDeComas)));
                }
                return numero.ToString();
            }
            else
                return "Valor inválido";
        }

        private static int NewMethod(ref string strAuxiliar, ref double numero)
        {
            int cantidadDeComas;
            for (cantidadDeComas = 0; long.TryParse(strAuxiliar, out _) == false; cantidadDeComas++)
            {
                numero *= 10;
                strAuxiliar = numero.ToString();
            }

            return cantidadDeComas;
        }

        /// <summary>
        /// Convierte un número decimal a binario.
        /// </summary>
        /// <param name="numero">El número en formato cadena se transforma a dato numérico.</param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string retorno;

            if (double.TryParse(numero, out double auxiliar) == true)
                retorno = DecimalBinario(auxiliar);
            else
                retorno = "Valor inválido";
            return retorno;
        }
        /// <summary>
        /// Convierte un número decimal a binario.
        /// </summary>
        /// <param name="numero">Toma el número en formato decimal y lo convierte.</param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            const int precision = 9;
            int numeroEntero = (int)numero;
            double numeroConComa = numero - numeroEntero;
            string parteDecimal = "";
            string parteEntera = "";
            string retorno = "";

            // Procedimiento para convertir la parte entera
            int i;
            for (i = 0; numeroEntero > 1; i++)
            {
                parteEntera += (numeroEntero % 2).ToString();
                numeroEntero /= 2;
            }
            parteEntera += numeroEntero.ToString();

            for (int j = i; j >= 0; j--)
            {
                retorno += parteEntera[j];
            }

            // Procedimiento para convertir la parte decimal.
            if (numeroConComa != 0)
            {
                for (int k = 0; k < precision && numeroConComa != 0; k++)
                {
                    numeroConComa *= 2;
                    parteDecimal += ((int)numeroConComa).ToString();
                    numeroConComa -= (int)numeroConComa;
                }
                retorno += "," + parteDecimal.TrimEnd('0');
            }

            return retorno;
        }

        // Operadores
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;

            return n1.numero / n2.numero;

        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
