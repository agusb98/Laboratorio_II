using System;

namespace Entidades
{
    public class Calculadora
    {
        #region Métodos

        /// <summary>
        /// Valida que el operador sea: + - * /
        /// </summary>
        /// <param name="operador"></param>
        /// <operaor></retorna operador +>
        private static string ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }

            return "+";
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double result = 0;

            if (!(num1 is null) && !(num2 is null))
            {
                char auxOperador = operador[0];

                switch (ValidarOperador(auxOperador))
                {
                    case "+":
                        {
                            result = num1 + num2;
                            break;
                        }
                    case "-":
                        {
                            result = num1 - num2;
                            break;
                        }
                    case "*":
                        {
                            result = num1 * num2;
                            break;
                        }
                    case "/":
                        {
                            result = num1 / num2;
                            break;
                        }
                }
            }
            return result;
        }
        #endregion
    }
}
