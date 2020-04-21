using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Estante
    {
        #region Fields

        private Producto[] productos;
        private int ubicacionEstante;

        #endregion

        #region Methods

        private Estante(int capacidad)
        {
            this.productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        /// <summary>
        /// Obtiene el array de los productos
        /// </summary>
        public Producto[] Productos
        {
            get
            {
                return this.productos;
            }
        }

        /// <summary>
        /// Muestra los productos dentro del Estante
        /// </summary>
        /// <param name="e"><Estante/param>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder str = new StringBuilder();

            if (!(e is null))
            {
                str.AppendLine(String.Format("Estante ubicacion {0}", e.ubicacionEstante));
                str.AppendLine(String.Format("Productos del Estante: "));
                str.AppendLine();

                for (int i = 0; i < e.productos.Length; i++)
                    str.AppendLine(Producto.MostrarProducto(e.productos[i]));
            }

            return str.ToString();
        }

        /// <summary>
        /// Obtiene la posicion del primer lugar libre dentro de Estante
        /// </summary>
        /// <returns></returns>
        private int ObtenerLugarLibre()
        {
            for (int i = 0; i < this.productos.Length; i++)
            {
                if (this.productos[i] == null)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Valida igualdad entre Estante y Producto
        /// </summary>
        /// <param name="e"><Estante/param>
        /// <param name="p"><Producto/param>
        /// <returns></returns>
        public static bool operator ==(Estante e, Producto p)
        {
            if (!(e is null) && !(p is null))
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (e.productos[i] == p)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Valida desigualdad entre Estante y Producto
        /// </summary>
        /// <param name="e"><Estante/param>
        /// <param name="p"><Producto/param>
        /// <returns></returns>
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        /// <summary>
        /// Agrega un Producto dentro de un estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator +(Estante e, Producto p)
        {
            int index = e.ObtenerLugarLibre();

            if (index > -1)
            {
                e.productos[index] = p;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Elimina un Producto dentro de un Estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// </returns></returns>
        public static bool operator -(Estante e, Producto p)
        {
            Producto[] aux = e.productos;

            for (int i = 0; i < e.productos.Length; i++)
            {
                if (aux[i] == p)
                {
                    aux[i] = null;
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
