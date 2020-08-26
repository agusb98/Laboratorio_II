using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Entidades.SP
{
    [XmlInclude(typeof(DepositoHeredado))]

    public class Deposito
    {
        public Producto[] productos;

        public Deposito() : this(3) { }

        public Deposito(int cantidad)
        {
            this.productos = new Producto[cantidad];
        }

        protected static int ObtenerIndice(Producto[] array, Producto item)
        {
            int indice = -1;
            int i = 0;

            foreach (Producto prod in array)
            {
                if (prod != null)
                {
                    if (prod.nombre == item.nombre)
                    {
                        indice = i;
                        break;
                    }
                    i++;
                }
            }
            return indice;
        }

        public static Producto[] operator +(Deposito d1, Deposito d2)
        {
            int cont = 0;
            int indice = 0;
            Producto[] producto = new Producto[1];

            foreach (Producto i in d1.productos)
            {
                if (producto.Length <= cont)
                    Array.Resize(ref producto, cont + 1);

                if (ObtenerIndice(producto, i) != -1)
                {
                    producto[ObtenerIndice(producto, i)].stock += i.stock;
                    cont--;
                }
                else
                {
                    producto[cont] = i;
                }

                if (indice == d1.productos.Length - 2)
                    cont--;

                cont++;
                indice++;
            }
            indice = 0;
            foreach (Producto i in d2.productos)
            {
                if (producto.Length <= cont)
                    Array.Resize(ref producto, cont + 1);

                if (ObtenerIndice(producto, i) != -1)
                {
                    producto[ObtenerIndice(producto, i)].stock += i.stock;
                    cont--;

                }
                else
                {
                    producto[cont] = i;
                }
                if (indice == d2.productos.Length - 2)
                    cont--;

                cont++;
                indice++;
            }

            return producto;
        }
    } 
}
