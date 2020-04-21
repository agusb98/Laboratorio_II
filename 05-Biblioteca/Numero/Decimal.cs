using System;

namespace Biblioteca
{
    public class Decimal_
    {
        private double num;

        public Decimal_(double num)
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
                this.num = value;
            }
        }

        public static implicit operator double(Decimal_ d)
        {
            return d.Value;
        }

        public static implicit operator Decimal_(double d)
        {
            return new Decimal_(d);
        }

        public static explicit operator Decimal_(Binary b)
        {
            string strAuxiliar = b.Value.ToString();

            if (double.TryParse(strAuxiliar, out double numero) && Validacion.IsBinary(strAuxiliar))
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

                return new Decimal_(numero);
            }

            return new Decimal_(0);
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

        public static bool operator ==(Decimal_ b1, Decimal_ b2)
        {
            return (b1.Value == b2.Value);
        }

        public static bool operator ==(Decimal_ d, Binary b)
        {
            return d == (Decimal_)b;
        }

        public static bool operator !=(Decimal_ b1, Decimal_ b2)
        {
            return !(b1.Value == b2.Value);
        }

        public static bool operator !=(Decimal_ d, Binary b)
        {
            return !(d == (Decimal_)b);
        }

        public static double operator +(Decimal_ d1, Decimal_ d2)
        {
            return d1.Value + d2.Value;
        }

        public static double operator +(Decimal_ d, Binary b)
        {
            return d + (Decimal_)b;
        }

        public static double operator -(Decimal_ d1, Decimal_ d2)
        {
            return d1.Value - d2.Value;
        }

        public static double operator -(Decimal_ d, Binary b)
        {
            return d - (Decimal_)b;
        }

        public static double operator *(Decimal_ d1, Decimal_ d2)
        {
            return d1.Value * d2.Value;
        }

        public static double operator *(Decimal_ d, Binary b)
        {
            return d * (Decimal_)b;
        }

        public static double operator /(Decimal_ d1, Decimal_ d2)
        {
            return d1.Value / d2.Value;
        }

        public static double operator /(Decimal_ d, Binary b)
        {
            return d / (Decimal_)b;
        }
    }
}