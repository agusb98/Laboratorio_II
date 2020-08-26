using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public abstract float CalcularCostoDeProduccion();

        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }

        public float Precio
        {
            get
            {
                return this._precio;
            }
        }

        public virtual string Consumir()
        {
            return "Parte de una mezcla.";
        }

        public override bool Equals(object obj)
        {
            if (obj is Producto)
            {
                return (Producto)obj == this;
            }
            return false;
        }

        public static explicit operator int (Producto p)
        {
            return p._codigoBarra;
        }

        public static explicit operator string(Producto p)
        {
            return MostrarProducto(p);
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nMARCA: {0}", p.Marca);
            sb.AppendFormat("\nCÓDIGO DE BARRAS: {0}", (int)p);
            sb.AppendFormat("\nPRECIO: {0}", p.Precio);

            return sb.ToString();
        }

        public static bool operator ==(Producto prod1, Producto prod2)
        {
            return (int)prod1 == (int)prod2 && prod1 == prod2.Marca;
        }

        public static bool operator !=(Producto prod1, Producto prod2)
        {
            return !(prod1 == prod2);
        }

        public static bool operator ==(Producto prod1, EMarcaProducto marca)
        {
            return prod1.Marca == marca;
        }

        public static bool operator !=(Producto prod1, EMarcaProducto marca)
        {
            return !(prod1 == marca);
        }

        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }

        public enum EMarcaProducto { Manaos, Pitusas, Naranjú, Diversión, Swift, Favorita }

        public enum ETipoProducto { Galletita, Gaseosa, Jugo, Harina, Todos }
    }
}
