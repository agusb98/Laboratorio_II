using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Biblioteca
{
    public class Euro
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        static Euro()
        {
            cotizRespectoDolar = 1.16;
        }

        public Euro(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public Euro(double cantidad, double cotizacion) : this(cantidad)
        {
            Euro.cotizRespectoDolar = cotizacion;
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
                return Euro.cotizRespectoDolar;
            }
        }

        public static implicit operator double(Euro e)
        {
            return (double)e.Value;
        }

        public static implicit operator Euro(double d)
        {
            return new Euro(d);
        }

        public static explicit operator Euro(Dolar p)
        {
            return new Euro(p.Value * Euro.Cotizacion);
        }

        public static explicit operator Euro(Peso p)
        {
            return new Euro(p.Value * Peso.Cotizacion * Euro.Cotizacion);
        }

        public static bool operator ==(Euro e1, Euro e2)
        {
            return (e1.Value == e2.Value);
        }

        public static bool operator ==(Euro e, Peso p)
        {
            return (e == (Euro)p);
        }

        public static bool operator ==(Euro e, Dolar d)
        {
            return (e == (Euro)d);
        }

        public static bool operator !=(Euro e1, Euro e2)
        {
            return !(e1 == e2);
        }

        public static bool operator !=(Euro e, Peso p)
        {
            return !(e == p);
        }

        public static bool operator !=(Euro e, Dolar d)
        {
            return !(e == d);
        }

        public static Euro operator +(Euro e1, Euro e2)
        {
            return e1.Value + e2.Value;
        }

        public static Euro operator -(Euro e1, Euro e2)
        {
            return e1.Value - e2.Value;
        }

        public static Euro operator +(Euro e, Peso p)
        {
            return e + (Euro)p;
        }

        public static Euro operator -(Euro e, Peso p)
        {
            return e - (Euro)p;
        }

        public static Euro operator +(Euro e, Dolar d)
        {
            return e + (Euro)d;
        }
        public static Euro operator -(Euro e, Dolar d)
        {
            return e - (Euro)d;
        }

    }
}