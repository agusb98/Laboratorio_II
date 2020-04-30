using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Equipo
    {
        private short cantidad;
        private List<Jugador> jugadores;
        private string nombre;

        public Equipo(short cantidad, string nombre) : this()
        {
            this.cantidad = cantidad;
            this.nombre = nombre;
        }

        public Equipo()
        {
            jugadores = new List<Jugador>();
        }

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Nombre: " + this.nombre);
                str.AppendLine("Cantidad: " + this.cantidad);

                str.AppendLine("\n----------------------------------------------------------");

                for (int i = 0; i < this.jugadores.Count; i++)
                {
                    str.AppendLine(this.jugadores[i].Mostrar());
                }
            }

            return str.ToString();
        }

        public static bool operator +(Equipo e, Jugador j)
        {
            if (e.jugadores.Count < e.cantidad && !e.jugadores.Contains(j))
            {
                e.jugadores.Add(j);
                return true;
            }

            return false;
        }
    }
}
