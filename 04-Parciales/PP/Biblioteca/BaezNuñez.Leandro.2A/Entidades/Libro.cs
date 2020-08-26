using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        protected Autor autor;
        protected int cantidadDePaginas;
        protected static Random generadorDePaginas;
        protected float precio;
        protected string titulo;

        public int CantidadDePaginas
        {
            get
            {
                if (cantidadDePaginas == 0)
                {
                    this.cantidadDePaginas = Libro.generadorDePaginas.Next(10, 571);
                }
                return this.cantidadDePaginas;
            }
        }

        static Libro()
        {
            Libro.generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, Autor autor)
        {
            this.precio = precio;
            this.titulo = titulo;
            this.autor = autor;
            this.cantidadDePaginas = this.CantidadDePaginas;
        }

        public Libro(float precio, string titulo, string nombre, string apellido) :
            this(precio, titulo, new Autor(nombre, apellido))
        { }

        private static string Mostrar(Libro l)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nAUTOR: {0}", (string)l.autor);
            sb.AppendFormat("\nTITULO: {0}", l.titulo);
            sb.AppendFormat("\nCANTIDAD DE PAGINAS: {0}", l.CantidadDePaginas);
            sb.AppendFormat("\nPRECIO: {0}", l.precio);

            return sb.ToString();
        }

        public static explicit operator string(Libro l)
        {
            return Mostrar(l);
        }

        public static bool operator ==(Libro a, Libro b)
        {
            return a.autor == b.autor && a.titulo == b.titulo;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}
