using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manual : Libro
    {
        protected ETipo tipo;

        public Manual(string titulo, string apellido, string nombre, float precio, ETipo tipo) :
            base(precio, titulo, nombre, apellido)
        {
            this.tipo = tipo;
        }

        public override bool Equals(object obj)
        {
            if (obj is Manual)
            {
                return (Manual)obj == this && (Libro)obj == this;
            }
            return false;
        }

        public static explicit operator float(Manual m)
        {
            return m.precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)(Libro)this);
            sb.AppendFormat("\nTIPO: {0}", this.tipo);

            return sb.ToString();
        }

        public static bool operator ==(Manual a, Manual b)
        {
            return a.tipo == b.tipo;
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }
    }

    public enum ETipo { Tecnico, Escolar, Finanzas }
}
