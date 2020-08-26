using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EGenero { Accion, Romantica, CienciaFiccion }
    public class Novela : Libro
    {
        protected EGenero genero;

        public Novela(string titulo, float precio, Autor autor, EGenero genero) :
            base(precio, titulo, autor)
        {
            this.genero = genero;
        }

        public override bool Equals(object obj)
        {
            if (obj is Novela)
            {
                return (Novela)obj == this && (Libro)obj == this;
            }
            return false;
        }

        public static explicit operator float(Novela n)
        {
            return n.precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)(Libro)this);
            sb.AppendFormat("\nGENERO: {0}", this.genero);

            return sb.ToString();
        }

        public static bool operator ==(Novela a, Novela b)
        {
            return a.genero == b.genero;
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }
    }

}
