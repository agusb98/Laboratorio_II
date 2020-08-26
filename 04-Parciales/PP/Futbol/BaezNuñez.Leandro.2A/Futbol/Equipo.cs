using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Deportes { Basquet, Futbol, Handball, Rugby }
    public class Equipo
    {
        protected static Deportes deporte;
        protected DirectorTecnico dt;
        protected List<Jugador> jugadores;
        protected string nombre;

        public static Deportes Deporte { set { value = deporte; } }

        static Equipo() { Deporte = Deportes.Futbol; }

        private Equipo() { this.jugadores = new List<Jugador>(); }

        public Equipo(string nombre, DirectorTecnico dt) : this(nombre, dt, Deportes.Futbol) { }

        public Equipo(string nombre, DirectorTecnico dt, Deportes deportes) : this()
        {
            this.nombre = nombre;
            this.dt = dt;
            Deporte = deportes;
        }

        public static implicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n**{0}**", e.nombre);
            sb.AppendFormat("\nNomina de Jugadores:\n");

            foreach (Jugador l in e.jugadores)
            {
                sb.AppendFormat("{0}\n", l.ToString());
            }
            sb.AppendFormat("Dirigido por: {0}\n", e.dt.ToString());

            return sb.ToString();
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            foreach (Jugador jugador in e.jugadores)
            {
                if (jugador == j)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if (e == j)
            {
                Console.WriteLine("Ya se encuentra en el Equipo!!!");
            }
            else if (e.jugadores.Count == 11)
            {
                Console.WriteLine("Equipo lleno!!!");
            }
            else
            {
                e.jugadores.Add(j);
            }
            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if (e == j) { e.jugadores.Remove(j); }
            else { Console.WriteLine("No se encuentra en el Equipo!!!"); }
            return e;
        }
    }
}
