using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EVehiculo { PrecioDeAutos, PrecioDeMotos, PrecioTotal}
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        /// <summary>
        /// Only read: return price of all cars in concesionary
        /// </summary>
        public double PrecioDeAutos
        {
            get
            {
                double acum = 0;
                foreach (Vehiculo l in this.vehiculos)
                {
                    if (l is Auto)
                    {
                        acum += (float)(Auto)l;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Only read: return price of all Motos in concesionary
        /// </summary>
        public double PrecioDeMotos
        {
            get
            {
                double acum = 0;
                foreach (Vehiculo l in this.vehiculos)
                {
                    if (l is Moto)
                    {
                        acum += (float)(Moto)l;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Only read: return price of all vehiculos in concesionary
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return PrecioDeAutos + PrecioDeMotos;
            }
        }

        /// <summary>
        /// Obitene el precio de vehiculos dentro de Concesionario que correspondan al tipo por parametro
        /// </summary>
        /// <param name="tipoVehiculo"></param>
        /// <returns></returns>
        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            switch (tipoVehiculo)
            {
                case EVehiculo.PrecioDeAutos:
                    {
                        return this.PrecioDeAutos;
                    }
                case EVehiculo.PrecioDeMotos:
                    {
                        return this.PrecioDeMotos;
                    }
                case EVehiculo.PrecioTotal:
                    {
                        return this.PrecioTotal;
                    }
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Instancia Lista de Vehiculos con Capacidad previamente declarada
        /// </summary>
        Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>(this.capacidad);
        }

        /// <summary>
        /// Instancia Lista de vehiculos con Capacidad pasada por parametro
        /// </summary>
        Concesionaria(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        /// <summary>
        /// Obtiene datos en string de List vehiculos dentro de la Concesionaria
        /// </summary>
        /// <param name="c"></Concesionaria>
        /// <returns></string con datos de Biblioteca>
        public static string Mostrar(Concesionaria c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nCapacidad: {0}", c.capacidad);
            sb.AppendFormat("\nTotal por Autos: {0}", c.ObtenerPrecio(EVehiculo.PrecioDeAutos));
            sb.AppendFormat("\nTotal por Motos: {0}", c.ObtenerPrecio(EVehiculo.PrecioDeMotos));
            sb.AppendFormat("\nTotal: {0}", c.ObtenerPrecio(EVehiculo.PrecioTotal));

            sb.AppendFormat("\n\n*********************************************\n");
            sb.AppendFormat("Listado de Vehiculos");
            sb.AppendFormat("\n*********************************************\n\n");

            foreach (Vehiculo l in c.vehiculos)
            {
                sb.AppendFormat("{0}\n", l.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida desigualdad entre Libros dentro de Concesionaria y un libro en particular
        /// </summary>
        /// <param name="c"></Concesionaria>
        /// <param name="v"></Vehiculo>
        /// <returns></returns>
        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            foreach (Vehiculo veh in c.vehiculos)
            {
                if (v.Equals(veh))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Valida desigualdad entre Vehiculos dentro de Concesionaria y un Vehiculo en particular
        /// </summary>
        /// <param name="c"></Concesionaria>
        /// <param name="v"></Vehiculo>
        /// <returns></returns>
        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }

        /// <summary>
        /// Agrega un nuevo vehiculo a la Concesionaria
        /// </summary>
        /// <param name="c"></Concesionaria>
        /// <param name="v"></vehiculo>
        /// <returns></Agregue o no, retornará la Biblioteca>
        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if (c == v)
            {
                Console.WriteLine("Ya se encuentra en Concesionaria!!!");
            }
            else if (c.vehiculos.Count == c.capacidad)
            {
                Console.WriteLine("Concesionaria lleno!!!");
            }
            else
            {
                c.vehiculos.Add(v);
            }
            return c;
        }

        /// <summary>
        /// Instancia implicitamente una Concesionaria con cierta capacidad pasada por parametro
        /// </summary>
        /// <param name="capacidad"></param>
        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }
    }
}
