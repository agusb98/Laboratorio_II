using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Producto
    {
        public string nombre;
        public int stock;

        public Producto() { }

        public Producto(string nombre, int stock)
        {
            this.nombre = nombre;
            this.stock = stock;
        }


    }
}
