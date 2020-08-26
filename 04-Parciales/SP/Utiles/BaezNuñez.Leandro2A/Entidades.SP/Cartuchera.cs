using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public delegate void EventoPrecio(double precio);
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;

        public event EventoPrecio eventoPrecio;

        #region Propiedades
        public List<T> Elementos
        {
            get { return this.elementos; }
        }
        public double PrecioTotal
        {
            get
            {
                double precio = 0;
                foreach (Utiles util in this.Elementos)
                {
                    precio += util.precio;
                }
                return precio;
            }
        }
        #endregion

        #region Constructores
        public Cartuchera()
        {
            this.elementos = new List<T>();
        }
        public Cartuchera(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("TIPO: {0}\n\n", typeof(T).Name);
            sb.AppendFormat("CAPACIDAD: {0}\n", this.capacidad);
            sb.AppendFormat("CANTIDAD TOTAL: {0}\n", this.Elementos.Count);
            sb.AppendFormat("PRECIO TOTAL: {0}\n\n", this.PrecioTotal);

            sb.AppendLine();
            foreach (Utiles util in this.Elementos)
            {
                sb.AppendLine(util.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T util)
        {
            if (cartuchera.Elementos.Count < cartuchera.capacidad)
            {
                cartuchera.Elementos.Add(util);

                if (cartuchera.PrecioTotal > 85)
                {
                    try
                    {
                        //cartuchera.eventoPrecio(cartuchera.PrecioTotal);
                    }
                    catch
                    {
                    }

                }

                return cartuchera;
            }
            else
            {
                throw new CartucheraLlenaException("La cartuchera ya está llena.");
            }
        }
        #endregion
    }
}
