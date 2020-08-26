using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        public float ValorEstanteTotal { get { return GetValorEstante(); } }

        Estante() { this._productos = new List<Producto>(this._capacidad); }

        public Estante(sbyte capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public List<Producto> GetProductos() { return this._productos; }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float acum = 0;

            foreach (Producto p in this.GetProductos())
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        {
                            if (p is Galletita)
                                acum += p.Precio;
                            break;
                        }
                    case Producto.ETipoProducto.Gaseosa:
                        {
                            if (p is Gaseosa)
                                acum += p.Precio;
                            break;
                        }
                    case Producto.ETipoProducto.Jugo:
                        {
                            if (p is Jugo)
                                acum += p.Precio;
                            break;
                        }
                    case Producto.ETipoProducto.Harina:
                        {
                            if (p is Harina)
                                acum += p.Precio;
                            break;
                        }
                    case Producto.ETipoProducto.Todos:
                        {
                            acum += p.Precio;
                            break;
                        }
                }
            }
            return acum;
        }

        public float GetValorEstante()
        {
            return GetValorEstante(Producto.ETipoProducto.Todos);
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nCapacidad: {0}", e.GetProductos().Count);
            sb.AppendFormat("\nValor Total Estante: {0}", e.GetValorEstante());
            sb.AppendFormat("\nValor Estante Solo Galletitas: {0}", e.GetValorEstante(Producto.ETipoProducto.Galletita));

            sb.AppendFormat("\n\nContenido Estante\n");

            foreach (Producto p in e.GetProductos())
            {
                sb.AppendFormat("{0}\n", p.ToString());
            }

            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            foreach (Producto prod in e.GetProductos())
            {
                if (prod == p)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        public static bool operator +(Estante e, Producto p)
        {
            if (e != p && e.GetProductos().Count < e._capacidad)
            {
                e.GetProductos().Add(p);
                return true;
            }
            return false;
        }

        public static Estante operator -(Estante e, Producto p)
        {
            if (e == p)
            {
                e.GetProductos().Remove(p);
            }
            return e;
        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            foreach (Producto p in e.GetProductos())
            {
                if (p is Jugo && tipo == Producto.ETipoProducto.Jugo)
                {
                    e.GetProductos().Remove(p);
                    break;
                }
                else if (p is Harina && tipo == Producto.ETipoProducto.Harina)
                {
                    e.GetProductos().Remove(p);
                }
                else if (p is Galletita && tipo == Producto.ETipoProducto.Galletita)
                {
                    e.GetProductos().Remove(p);
                    break;
                }
                else if (p is Gaseosa && tipo == Producto.ETipoProducto.Gaseosa)
                {
                    e.GetProductos().Remove(p);
                    break;
                }
                else if (tipo == Producto.ETipoProducto.Todos)
                {
                    e.GetProductos().Remove(p);
                    break;
                }
            }
            return e;
        }
    }
}
