using System;

namespace Biblioteca
{
    public class Binary
    {
        private double num;

        public Binary(double num)
        {
            this.num = num;
        }

        public double Value
        {
            get
            {
                return this.num;
            }
            set
            {
                if (Validacion.IsBinary(value))
                {
                    this.num = value;
                }
            }
        }

        public static implicit operator double(Binary d)
        {
            return d.Value;
        }

        public static explicit operator Binary(double d)
        {
            if (Validacion.IsBinary(d))
                return (Binary)new Decimal_(d);

            return new Binary(0);
        }

        public static explicit operator Binary(Decimal_ d)
        {
            const int precision = 9;
            int numeroEntero = (int)d.Value;
            double numeroConComa = d.Value - numeroEntero;
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

            if (double.TryParse(retorno, out double aux))
                return new Binary(aux);

            else
                return new Binary(0);
        }
        public static bool operator ==(Binary b1, Binary b2)
        {
            return (b1.Value == b2.Value);
        }

        public static bool operator !=(Binary b1, Binary b2)
        {
            return !(b1.Value == b2.Value);
        }

        public static bool operator ==(Binary b, Decimal_ d)
        {
            return b == (Binary)d;
        }

        public static bool operator !=(Binary b, Decimal_ d)
        {
            return !(b == (Binary)d);
        }

        public static double operator +(Binary b1, Binary b2)
        {
            double result = (Decimal_)b1 + (Decimal_)b2;
            return (Binary)result;
        }

        public static double operator +(Binary b, Decimal_ d)
        {
            return b + (Binary)d;
        }

        public static double operator -(Binary b1, Binary b2)
        {
            double result = (Decimal_)b1 - (Decimal_)b2;
            return (Binary)result;
        }

        public static double operator -(Binary b, Decimal_ d)
        {
            return b - (Binary)d;
        }

        public static double operator *(Binary b1, Binary b2)
        {
            double result = (Decimal_)b1 * (Decimal_)b2;
            return (Binary)result;
        }

        public static double operator *(Binary b, Decimal_ d)
        {
            return b * (Binary)d;
        }

        public static double operator /(Binary b1, Binary b2)
        {
            double result = (Decimal_)b1 / (Decimal_)b2;
            return (Binary)result;
        }

        public static double operator /(Binary b, Decimal_ d)
        {
            return b / (Binary)d;
        }
    }
}