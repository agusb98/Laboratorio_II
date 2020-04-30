using System.Text;
using System;

namespace Biblioteca
{
    public class Kelvin
    {
        private double value;

        public Kelvin(double value)
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

        public static implicit operator double(Kelvin e)
        {
            return (double)e.Value;
        }

        public static implicit operator Kelvin(double d)
        {
            return new Kelvin(d);
        }

        public static explicit operator Kelvin(Celsius c)
        {
            return new Kelvin(new Fahrenheit(c));
        }

        public static explicit operator Kelvin(Fahrenheit f)
        {
            return new Kelvin((f.Value + 459.67) * (5 / 9));
        }

        public static bool operator ==(Kelvin d1, Kelvin d2)
        {
            return (d1.Value == d2.Value);
        }

        public static bool operator ==(Kelvin d, Celsius p)
        {
            return (d.value == (Kelvin)p.Value);
        }

        public static bool operator ==(Kelvin d, Fahrenheit e)
        {
            return (d.Value == (Kelvin)e.Value);
        }

        public static bool operator !=(Kelvin d1, Kelvin d2)
        {
            return !(d1 == d2);
        }
        public static bool operator !=(Kelvin d, Celsius p)
        {
            return !(d == (Kelvin)p);
        }
        public static bool operator !=(Kelvin d, Fahrenheit e)
        {
            return !(d == (Kelvin)e);
        }

        public static Kelvin operator +(Kelvin d1, Kelvin d2)
        {
            return d1.Value + d2.Value;
        }
        public static Kelvin operator +(Kelvin d, Celsius p)
        {
            return d + (Kelvin)p.Value;
        }
        public static Kelvin operator +(Kelvin d, Fahrenheit e)
        {
            return d + (Kelvin)e.Value;
        }

        public static Kelvin operator -(Kelvin d1, Kelvin d2)
        {
            return d1.Value - d2.Value;
        }
        public static Kelvin operator -(Kelvin d, Celsius p)
        {
            return d - (Kelvin)p;
        }
        public static Kelvin operator -(Kelvin d, Fahrenheit e)
        {
            return d - (Kelvin)e;
        }

        public static Kelvin operator ++(Kelvin f)
        {
            return f.Value++;
        }

        public static Kelvin operator --(Kelvin f)
        {
            return f.Value--;
        }
    }
}
