namespace Calculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza sumas, restas, multiplicaciones y divisiones a partir de dos objetos tipo Numero y el operador en cuestión (string).
        /// </summary>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operación</returns>
        public static double CalculateToDouble(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;

            if (!ValidarOperador(operador))
            {
                retorno = numero1;
            }
            else
            {
                switch (operador)
                {
                    case "+":
                        {
                            retorno = numero1 + numero2;
                            break;
                        }
                    case "-":
                        {
                            retorno = numero1 - numero2;
                            break;
                        }
                    case "*":
                        {
                            retorno = numero1 * numero2;
                            break;
                        }
                    case "/":
                        {
                            if (numero2 == (Numero)0)
                            {
                                retorno = 0;
                            }
                            else
                            {
                                retorno = numero1 / numero2;
                            }
                            break;
                        }
                }
            }

            return retorno;
        }

        public static string CalculateToString(Numero numero1, Numero numero2, string operador)
        {
            return CalculateToDouble(numero1, numero2, operador).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static bool ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return true;

            return false;
        }
    }
}

