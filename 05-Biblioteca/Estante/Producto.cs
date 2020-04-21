using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        #region Fields

        private string codigoDeBarra;
        private string marca;
        private float precio;

        #endregion
        #region Methods

        /// <summary>
        /// Inicializa un Producto
        /// </summary>
        /// <param name="codigoDeBarra"><Codigo de Barra del Producto/param>
        /// <param name="marca"><Marca del Producto/param>
        /// <param name="precio"><Precio del Producto/param>
        public Producto(string codigoDeBarra, string marca, float precio)
        {
            this.codigoDeBarra = codigoDeBarra;
            this.marca = marca;
            this.precio = precio;
        }

        public Producto(string codigoDeBarra)
            : this(codigoDeBarra, string.Empty, 0)
        {

        }

        /// <summary>
        /// Obtiene el Precio del Producto
        /// </summary>
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }

        /// <summary>
        /// Obtiene Marca del Producto
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }
        }

        /// <summary>
        /// Convierte un Producto en su Codigo de Barras
        /// </summary>
        /// <param name="p"><Producto/param>
        /// <returns></returns>
        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }

        /// <summary>
        /// Retorna un Producto convertido a String
        /// </summary>
        /// <param name="p"><Producto/param>
        /// <returns></returns>
        public static string MostrarProducto(Producto p)
        {
            StringBuilder str = new StringBuilder();

            if (!(p is null))
            {
                str.AppendLine(String.Format(p.codigoDeBarra + " " + p.Marca + " " + p.Precio));
            }
            return str.ToString();
        }

        /// <summary>
        /// Valida igualdad entre Productos
        /// </summary>
        /// <param name="p1"><Producto 1/param>
        /// <param name="p2"><Producto 2/param>
        /// <returns></returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            if ((object)p1 == null && (object)p2 == null)
                return true;

            else if ((object)p1 != null && (object)p2 != null)
            {
                if ((p1.codigoDeBarra == p2.codigoDeBarra) && (p1.Marca == p1.Marca))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Valida desigualdad entre Productos
        /// </summary>
        /// <param name="p1"><Producto 1/param>
        /// <param name="p2"><Producto 2/param>
        /// <returns></returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }
}
