using ComprobantesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComprobantesLogic.Factura;

namespace ComiqueriaLogic
{
    public class Comiqueria
    {
        private List<Producto> productos;
        private List<Venta> ventas;
        private static Stack<Comprobante> comprobantes;

        /// <summary>
        /// Constructor estático. Instancia el campo comprobantes. 
        /// </summary>
        static Comiqueria()
        {
            Comiqueria.comprobantes = new Stack<Comprobante>();
        }

        /// <summary>
        /// Constructor, instancia los campos de tipo lista. 
        /// </summary>
        public Comiqueria()
        {
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
        }

        public List<Comprobante> this[Producto producto, bool ordenar]
        {
            get
            {
                List<Comprobante> comprobantes = new List<Comprobante>();

                foreach (Comprobante comprobante in Comiqueria.comprobantes)
                {
                    Producto productoVenta = ((Producto)comprobante.Venta);
                    if ((Guid)productoVenta == (Guid)producto) {
                        comprobantes.Add(comprobante);
                    }
                }

                if (ordenar)
                {
                    comprobantes.OrderBy(c => c.Venta.Fecha);
                }

                return comprobantes;
            }
        }

        /// <summary>
        /// Indexador. 
        /// </summary>
        /// <param name="codigo">Código Guid de un producto.</param>
        /// <returns>Devuelve el producto correspondiente al código. Si no encuentra coincidencia devuelve null.</returns>
        public Producto this[Guid codigo] {
            get
            {
                foreach (Producto producto in this.productos)
                {
                    if((Guid)producto == codigo)
                    {
                        return producto;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Verifica si un producto se encuentra en la lista de productos.
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator ==(Comiqueria comiqueria, Producto producto)
        {
            foreach (Producto prod in comiqueria.productos)
            {
                if(prod.Descripcion == producto.Descripcion)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un producto NO se encuentra en la lista de productos. 
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator !=(Comiqueria comiqueria, Producto producto)
        {
            return !(comiqueria == producto);
        }

        public static bool operator ==(Comiqueria comiqueria, Comprobante comprobante)
        {
            foreach (Comprobante compr in Comiqueria.comprobantes)
            {
                if (compr.Equals(comprobante))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Comiqueria comiqueria, Comprobante comprobante)
        {
            return !(comiqueria == comprobante);
        }

        /// <summary>
        /// Agrega un producto a la lista de productos, siempre que el mismo ya no exista en la lista. 
        /// </summary>
        /// <param name="comiqueria"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Comiqueria operator +(Comiqueria comiqueria, Producto producto)
        {
            if (comiqueria != producto)
            {
                comiqueria.productos.Add(producto);
            }

            return comiqueria;
        }

        public bool AgregarComprobante(Comprobante comprobante)
        {
            if (this != comprobante)
            {
                Comiqueria.comprobantes.Push(comprobante);
                return true;
            }

            return false;
        }

        private bool AgregarComprobante(Venta venta)
        {
            return this.AgregarComprobante(new Factura(venta, TipoFactura.B));
        }

        /// <summary>
        /// Devuelve un string conteniendo la descripción breve de cada venta en la lista de ventas. 
        /// </summary>
        /// <returns></returns>
        public string ListarVentas()
        {
            List<Venta> ventasOrdenadas = this.ventas.OrderByDescending(x => x.Fecha).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (Venta venta in ventasOrdenadas)
            {
                sb.AppendLine(venta.ObtenerDescripcionBreve());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un Dictionary. 
        /// Cada elemento del diccionario corresponderá con cada producto en la lista de productos. 
        /// La key será el código del producto y el valor la descripción del producto. 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, string> ListarProductos()
        {
            Dictionary<Guid, string> respuesta = new Dictionary<Guid, string>();

            foreach (Producto producto in this.productos)
            {
                respuesta.Add((Guid)producto, producto.Descripcion);
            }

            return respuesta;
        }

        /// <summary>
        /// Agrega una nueva venta a la lista de ventas. 
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        public void Vender(Producto producto, int cantidad)
        {
            this.ventas.Add(new Venta(producto, cantidad));
        }

        /// <summary>
        /// Agrega una nueva venta a la lista de ventas.
        /// La cantidad por defecto es 1. 
        /// </summary>
        /// <param name="producto"></param>
        public void Vender(Producto producto)
        {
            this.Vender(producto, 1);
        }
    }
}
