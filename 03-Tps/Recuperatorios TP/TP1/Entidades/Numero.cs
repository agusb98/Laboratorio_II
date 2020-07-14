using System;

namespace Entidades
{
    /// <summary>
    /// Representa un número. Incluye sobrecarga de instancias de Numero
    /// para operaciones básicas y conversiones entre números decimales y binarios.
    /// </summary>

    public class Numero
    {
        #region Campos

        private double numero;

        #endregion

        #region Contructores

        /// <summary>
        /// Inicializa el valor del Número en 0.
        /// </summary>

        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Inicializa el valor del Número.
        /// </summary>
        /// <param name="numero">Número a asignar.</param>

        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Inicializa el valor del Número.
        /// </summary>
        /// <param name="strNumero">Número a asignar.</param>

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Asigna valor al Número, previa validación.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Convierte un número decimal a binario. Solo convierte el valor entero y absoluto.
        /// </summary>
        /// <param name="numero">Cadena de caracteres que representa el número a convertir.</param>
        /// <returns>Cadena de caracteres que representa el número en sistema binario, o "Valor inválido" si no se pudo convertir.</returns>

        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double aux) && aux >= 0)
            {
                return DecimalBinario(aux);
            }

            return "Valor inválido";
        }
        /// <summary>
        /// Convierte un número decimal a binario. Solo convierte el valor entero y absoluto.
        /// </summary>
        /// <param name="numero">Número a convertir.</param>
        /// <returns>Cadena de caracteres que representa el número en sistema binario, o "Valor inválido" si no se pudo convertir.</returns>

        public static string DecimalBinario(double numero)
        {
            numero = Math.Abs((long)numero);
            return Convert.ToString((long)numero, 2);
        }

        /// <summary>
        /// Convierte un número binario a decimal.
        /// </summary>
        /// <param name="binario">Cadena de caracteres que representa el número en sistema binario.</param>
        /// <returns>El número decimal como cadena de caracteres, o "Valor inválido" si no se pudo convertir.</returns>
        /// 
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor inválido";
        }

        /// <summary>
        /// Verifica si el numero pasado por parametro es binario
        /// </summary>
        /// <param name="binario">.</param>
        /// <returns></returns>

        private static bool EsBinario(string binario)
        {
            binario = binario.Replace('.', ',');

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica si el numero pasado por parametro es binario
        /// </summary>
        /// <param name="binario">.</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double result))
            {
                return result;
            }
            return 0;

        }

        /// <summary>
        /// Resta dos Números.
        /// </summary>
        /// <param name="n1">Número a restar.</param>
        /// <param name="n2">Número a restar.</param>
        /// <returns>Resultado de la resta.</returns>

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos Números.
        /// </summary>
        /// <param name="n1">Número a Multiplicar.</param>
        /// <param name="n2">Número a Multiplicar.</param>
        /// <returns>Resultado de la Multiplicacion.</returns>

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos Números.
        /// </summary>
        /// <param name="n1">Número a Dividir.</param>
        /// <param name="n2">Número a Dividir.</param>
        /// <returns>Resultado de la Divicion.</returns>

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Suma dos Números.
        /// </summary>
        /// <param name="n1">Número a Sumar.</param>
        /// <param name="n2">Número a Sumar.</param>
        /// <returns>Resultado de la Suma.</returns>

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}