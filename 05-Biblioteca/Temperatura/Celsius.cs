using System;

namespace Biblioteca
{
    public class Celsius
    {
        private double value;

        public Celsius(double value)
        {
            this.value = value;
        }

        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public static implicit operator double(Celsius f)
        {
            return (double)f.Value;
        }

        public static implicit operator Celsius(double d)
        {
            return new Celsius(d);
        }

        public static implicit operator Celsius(Fahrenheit f)
        {
            return new Celsius((f.Value - 32) * (5 / 9));
        }

        public static bool operator ==(Celsius d1, Celsius d2)
        {
            return (d1.Value == d2.Value);
        }

        public static bool operator ==(Celsius d, Fahrenheit p)
        {
            return (d == (Celsius)p);
        }

        public static bool operator ==(Celsius d, Kelvin e)
        {
            return (d == (Fahrenheit)e);
        }

        public static bool operator !=(Celsius d1, Celsius d2)
        {
            return !(d1 == d2);
        }
        public static bool operator !=(Celsius d, Fahrenheit p)
        {
            return !(d == (Celsius)p);
        }
        public static bool operator !=(Celsius d, Kelvin e)
        {
            return !(d == (Fahrenheit)e);
        }

        public static Celsius operator +(Celsius d1, Celsius d2)
        {
            return d1.Value + d2.Value;
        }

        public static Celsius operator +(Celsius c, Fahrenheit f)
        {
            return c + (Celsius)f.Value;
        }

        public static Celsius operator +(Celsius d, Kelvin e)
        {
            return d + (Fahrenheit)e.Value;
        }

        public static Celsius operator -(Celsius d1, Celsius d2)
        {
            return d1.Value - d2.Value;
        }

        public static Celsius operator -(Celsius d, Fahrenheit p)
        {
            return d - (Celsius)p;
        }

        public static Celsius operator -(Celsius d, Kelvin e)
        {
            return d - (Fahrenheit)e;
        }

        public static Celsius operator ++(Celsius f)
        {
            return f.Value++;
        }

        public static Celsius operator --(Celsius f)
        {
            return f.Value--;
        }
    }
}
