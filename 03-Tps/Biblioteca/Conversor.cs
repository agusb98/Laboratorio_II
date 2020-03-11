using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Conversor
    {
        public static string DecimalBinario(Numero num)
        {
            string retorno = "";
            bool flag = false;
            double aux = num.getNumero();

            while (aux > 0)
            {
                flag = true;
                if (aux % 2 == 0)
                    retorno = "0" + retorno;
                else
                    retorno = "1" + retorno;

                aux = (int)aux / 2;
            }

            if (flag == false)
                retorno = "0";

            return retorno;
        }

        public static double BinarioDecimal(string binario)
        {
            double retorno = 0;
            double num;
            for (int i = binario.Length - 1, j = 0; i >= 0; i--, j++)
            {
                double.TryParse(binario[i].ToString(), out num);
                retorno = retorno + num * Math.Pow(2, j);
            }

            return retorno;
        }


    }
}
