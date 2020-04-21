using System;

namespace Biblioteca
{
    public class Dolar
    {
        private double cantidad;

        public Dolar(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public double Value
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }

        public static implicit operator Dolar(double d)
        {
            return new Dolar(d);
        }

        public static explicit operator Dolar(Peso p)
        {
            return new Dolar(p.Value * Peso.Cotizacion);
        }

        public static explicit operator Dolar(Euro p)
        {
            return new Dolar(p.Value * Euro.Cotizacion);
        }

        public static bool operator ==(Dolar d1, Dolar d2)
        {
            return (d1.Value == d2.Value);
        }

        public static bool operator ==(Dolar d, Peso p)
        {
            return (d.Value == (Peso)p.Value);
        }

        public static bool operator ==(Dolar d, Euro e)
        {
            return (d.Value == (Dolar)e.Value);
        }

        public static bool operator !=(Dolar d1, Dolar d2)
        {
            return !(d1 == d2);
        }
        public static bool operator !=(Dolar d, Peso p)
        {
            return !(d == p);
        }
        public static bool operator !=(Dolar d, Euro e)
        {
            return !(d == e);
        }

        public static Dolar operator +(Dolar d1, Dolar d2)
        {
            return d1.Value + d2.Value;
        }
        public static Dolar operator +(Dolar d, Peso p)
        {
            return d + (Dolar)p;
        }
        public static Dolar operator +(Dolar d, Euro e)
        {
            return d + (Dolar)e;
        }

        public static Dolar operator -(Dolar d1, Dolar d2)
        {
            return d1.Value - d2.Value;
        }
        public static Dolar operator -(Dolar d, Peso p)
        {
            return d - (Dolar)p;
        }
        public static Dolar operator -(Dolar d, Euro e)
        {
            return d - (Dolar)e;
        }
    }
}