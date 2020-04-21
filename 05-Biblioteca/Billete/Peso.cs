using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Biblioteca
{
    public class Peso
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        static Peso()
        {
            cotizRespectoDolar = (1 / 38.33);
        }

        public Peso(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public Peso(double cantidad, double cotizacion) : this(cantidad)
        {
            Peso.cotizRespectoDolar = cotizacion;
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

        public static double Cotizacion
        {
            get
            {
                return Peso.cotizRespectoDolar;
            }
        }

        public static implicit operator Peso(double d)
        {
            return new Peso(d);
        }

        public static explicit operator Peso(Dolar p)
        {
            return new Peso(p.Value * Peso.Cotizacion);
        }

        public static explicit operator Peso(Euro p)
        {
            return new Peso(p.Value * Euro.Cotizacion / Peso.Cotizacion);
        }

        public static bool operator ==(Peso p1, Peso p2)
        {
            return (p1.Value == p2.Value);
        }
        public static bool operator ==(Peso p, Dolar d)
        {
            return (p.Value == d.Value);
        }
        public static bool operator ==(Peso p, Euro e)
        {
            return (p.Value == e.Value);
        }

        public static bool operator !=(Peso p1, Peso p2)
        {
            return !(p1 == p2);
        }
        public static bool operator !=(Peso p, Dolar d)
        {
            return !(p == d);
        }
        public static bool operator !=(Peso p, Euro e)
        {
            return !(p == e);
        }

        public static Peso operator +(Peso p1, Peso p2)
        {
            return p1.Value + p2.Value;
        }

        public static Peso operator +(Peso p, Dolar d)
        {
            return p + (Peso)d;
        }
        public static Peso operator +(Peso p, Euro e)
        {
            return p + (Peso)e;
        }

        public static Peso operator -(Peso p1, Peso p2)
        {
            return p1.Value - p2.Value;
        }
        public static Peso operator -(Peso p, Dolar d)
        {
            return p - (Peso)d;
        }
        public static Peso operator -(Peso p, Euro e)
        {
            return p - (Peso)e;
        }
    }
}
