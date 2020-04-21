using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Biblioteca
{
    public class Fahrenheit
    {
        private double value;

        public Fahrenheit(double value)
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

        public static implicit operator double(Fahrenheit f)
        {
            return (double)f.Value;
        }

        public static implicit operator Fahrenheit(double d)
        {
            return new Fahrenheit(d);
        }

        public static implicit operator Fahrenheit(Kelvin k)
        {
            return new Fahrenheit(k.Value * 9 / 5 - 459.67);
        }

        public static implicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit(c.Value * 9 / 5 + 32);
        }

        public static bool operator ==(Fahrenheit d1, Fahrenheit d2)
        {
            return (d1.Value == d2.Value);
        }

        public static bool operator ==(Fahrenheit d, Celsius p)
        {
            return (d.value == (Fahrenheit)p);
        }

        public static bool operator ==(Fahrenheit d, Kelvin e)
        {
            return (d.Value == (Fahrenheit)e);
        }

        public static bool operator !=(Fahrenheit d1, Fahrenheit d2)
        {
            return !(d1 == d2);
        }
        public static bool operator !=(Fahrenheit d, Celsius p)
        {
            return !(d == (Fahrenheit)p);
        }
        public static bool operator !=(Fahrenheit d, Kelvin e)
        {
            return !(d == (Fahrenheit)e);
        }

        public static Fahrenheit operator +(Fahrenheit d1, Fahrenheit d2)
        {
            return d1.Value + d2.Value;
        }
        public static Fahrenheit operator +(Fahrenheit d, Celsius c)
        {
            return d + (Fahrenheit)c.Value;
        }
        public static Fahrenheit operator +(Fahrenheit d, Kelvin e)
        {
            return d + (Fahrenheit)e.Value;
        }

        public static Fahrenheit operator -(Fahrenheit d1, Fahrenheit d2)
        {
            return d1.Value - d2.Value;
        }
        public static Fahrenheit operator -(Fahrenheit d, Celsius p)
        {
            return d - (Fahrenheit)p;
        }

        public static Fahrenheit operator -(Fahrenheit d, Kelvin e)
        {
            return d - (Fahrenheit)e;
        }

        public static Fahrenheit operator ++(Fahrenheit f)
        {
            return f.Value++;
        }

        public static Fahrenheit operator --(Fahrenheit f)
        {
            return f.Value--;
        }
    }
}
