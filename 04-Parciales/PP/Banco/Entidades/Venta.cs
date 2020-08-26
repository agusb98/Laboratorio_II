using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Venta
    {
        #region Atributos

        private DateTime fecha;
        private static int porcentajelva;
        private double precioFinal;
        private Banco producto;

        #endregion 

        #region Propiedades

        protected internal DateTime Fecha
        {
            get { return this.fecha; }
        }

        #endregion

        #region Metodos

        static Venta() { porcentajelva = 21; }

        internal Venta(Banco producto, int cantidad)
        {
            this.producto = producto;
            Vender(cantidad);
        }

        private void Vender(int cantidad)
        {
            producto.Stock -= cantidad;
            this.fecha = DateTime.Now;
            this.precioFinal = CalcularPrecioFinal(producto.Precio, cantidad);
        }

        public static double CalcularPrecioFinal(double precio, int cantidad)
        {
            double endPrice = precio * cantidad;
            endPrice = endPrice + endPrice * porcentajelva;

            return endPrice;
        }

        public string MostrarDescripcionBreve()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("{0} - {1} - {###,##}\n", Fecha, producto.ToString(), precioFinal);
            }

            return sb.ToString();
        }

        #endregion 
    }
}
