namespace Entidades
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
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            string operadorValidado;

            operadorValidado = ValidarOperador(operador);

            switch (operadorValidado)
            {
                case "+":
                    {
                        retorno = numero1.GetNumero() + numero2.GetNumero();
                        break;
                    }
                case "-":
                    {
                        retorno = numero1.GetNumero() - numero2.GetNumero();
                        break;
                    }
                case "*":
                    {
                        retorno = numero1.GetNumero() * numero2.GetNumero();
                        break;
                    }
                case "/":
                    {
                        if (numero2.GetNumero() == 0)
                            return 0;

                        retorno = numero1.GetNumero() / numero2.GetNumero();
                        break;
                    }
            }

            return retorno;
        }
        /// <summary>
        /// Valida que un string sea un operador matemático sea +, -, *, /
        /// </summary>
        /// <param name="operador">Cadena a validar</param>
        /// <returns>Operador validado, en caso de error, retorna el operador "+".</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;

            return "+";
        }
    }
}
