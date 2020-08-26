using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        private int capacidad;
        private List<Libro> libros;

        /// <summary>
        /// Only read: return price of all manuales in Library
        /// </summary>
        public double PrecioDeManuales
        {
            get
            {
                double acum = 0;
                foreach (Libro l in this.libros)
                {
                    if (l is Manual)
                    {
                        acum += (float)(Manual)l;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Only read: return price of all novelas in Library
        /// </summary>
        public double PrecioDeNovelas
        {
            get
            {
                double acum = 0;
                foreach (Libro l in this.libros)
                {
                    if (l is Novela)
                    {
                        acum += (float)(Novela)l;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Only read: return price of all books in Library
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return PrecioDeManuales + PrecioDeNovelas;
            }
        }

        /// <summary>
        /// Obitene el precio de libros dentro de Biblioteca que correspondan al tipo por parametro
        /// </summary>
        /// <param name="tipoLibro"></param>
        /// <returns></returns>
        private double ObtenerPrecio(ELibro tipoLibro)
        {
            switch (tipoLibro)
            {
                case ELibro.PrecioDeManuales:
                    {
                        return this.PrecioDeManuales;
                    }
                case ELibro.PrecioDeNovelas:
                    {
                        return this.PrecioDeNovelas;
                    }
                case ELibro.PrecioTotal:
                    {
                        return this.PrecioTotal;
                    }
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Instancia Lista de Libros con Capacidad previamente declarada
        /// </summary>
        Biblioteca()
        {
            this.libros = new List<Libro>(this.capacidad);
        }

        /// <summary>
        /// Instancia Lista de Libros con Capacidad pasada por parametro
        /// </summary>
        Biblioteca(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        /// <summary>
        /// Obtiene datos en string de List libros dentro de la Biblioteca
        /// </summary>
        /// <param name="b"></Biblioteca>
        /// <returns></string con datos de Biblioteca>
        public static string Mostrar(Biblioteca b)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nCapacidad: {0}", b.capacidad);
            sb.AppendFormat("\nTotal por Manuales: {0}", b.ObtenerPrecio(ELibro.PrecioDeManuales));
            sb.AppendFormat("\nTotal por Novelas: {0}", b.ObtenerPrecio(ELibro.PrecioDeNovelas));
            sb.AppendFormat("\nTotal: {0}", b.ObtenerPrecio(ELibro.PrecioTotal));

            sb.AppendFormat("\n\n*********************************************\n");
            sb.AppendFormat("Listado de Libros");
            sb.AppendFormat("\n*********************************************\n\n");

            foreach (Libro l in b.libros)
            {
                sb.AppendFormat("{0}\n", l.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida desigualdad entre Libros dentro de Biblioteca y un libro en particular
        /// </summary>
        /// <param name="b"></Biblioteca>
        /// <param name="l"></Libro>
        /// <returns></returns>
        public static bool operator ==(Biblioteca b, Libro l)
        {
            foreach (Libro libro in b.libros)
            {
                if (l.Equals(libro))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Valida desigualdad entre Libros dentro de Biblioteca y un libro en particular
        /// </summary>
        /// <param name="b"></Biblioteca>
        /// <param name="l"></Libro>
        /// <returns></returns>
        public static bool operator !=(Biblioteca b, Libro l)
        {
            return !(b == l);
        }

        /// <summary>
        /// Agrega un nuevo libro a la biblioteca
        /// </summary>
        /// <param name="b"></Biblioteca>
        /// <param name="l"></Libro>
        /// <returns></Agregue o no, retornará la Biblioteca>
        public static Biblioteca operator +(Biblioteca b, Libro l)
        {
            if (b == l)
            {
                Console.WriteLine("Ya se encuentra en Biblioteca!!!");
            }
            else if (b.libros.Count == b.capacidad)
            {
                Console.WriteLine("Biblioteca lleno!!!");
            }
            else
            {
                b.libros.Add(l);
            }
            return b;
        }

        /// <summary>
        /// Instancia implicitamente una Biblioteca con cierta capacidad pasada por parametro
        /// </summary>
        /// <param name="capacidad"></param>
        public static implicit operator Biblioteca (int capacidad)
        {
            return new Biblioteca(capacidad);
        }
    }
    public enum ELibro { PrecioDeManuales, PrecioDeNovelas, PrecioTotal }
}
