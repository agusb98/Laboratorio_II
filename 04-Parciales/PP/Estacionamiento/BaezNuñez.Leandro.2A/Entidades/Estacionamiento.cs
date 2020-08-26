using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        protected int espacioDisponible;
        protected string nombre;
        protected List<Vehiculo> vehiculos;

        Estacionamiento() { this.vehiculos = new List<Vehiculo>(this.espacioDisponible); }

        public Estacionamiento(string nombre, int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
            this.nombre = nombre;
        }

        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nNombre: ({0})", e.nombre);
            sb.AppendFormat("\nEspacio disponible: ({0})", e.espacioDisponible);
            sb.AppendFormat("\nLista de Vehiculos\n\n");

            foreach (Vehiculo v in e.vehiculos)
            {
                sb.AppendFormat("{0}\n", v.ImprimirTicket());
            }

            return sb.ToString();
        }

        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            foreach (Vehiculo vec in e.vehiculos)
            {
                if (v == vec)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }

        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if (e != v && e.vehiculos.Count < e.espacioDisponible)
            {
                e.vehiculos.Add(v);
            }
            return e;
        }

        public static Estacionamiento operator -(Estacionamiento e, Vehiculo v)
        {
            if (e == v)
            {
                Console.WriteLine(v.ImprimirTicket());
                e.vehiculos.Remove(v);
            }
            else { Console.WriteLine("\nEl vehículo no es parte del estacionamiento\n"); }

            return e;
        }
    }
}
