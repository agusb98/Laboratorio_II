using System;
using System.Text;


namespace Biblioteca
{
    public class Jugador
    {
        #region Fields

        private double dni;
        private string nombre;
        private int partidosJugados;
        private float promedioGoles;
        private int totalGoles;

        #endregion

        private Jugador()
        {
        }

        public Jugador(double dni, string nombre, int partidosJugados) :
            this(dni, nombre, partidosJugados, 0)
        {
        }

        public float PromedioGoles
        {
            get
            {
                if (this.partidosJugados != 0)
                {
                    this.promedioGoles = this.totalGoles / (float)this.partidosJugados;
                }
                else
                {
                    this.promedioGoles = 0;
                }
                return this.promedioGoles;
            }
        }

        public Jugador(double dni, string nombre, int partidosJugados, int totalGoles)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.partidosJugados = partidosJugados;
            this.totalGoles = totalGoles;
            this.promedioGoles = PromedioGoles;
        }

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Dni: " + this.dni);
            str.AppendLine("Nombre: " + this.nombre);
            str.AppendLine("Partidos: " + this.partidosJugados);
            str.AppendLine("Promedio Goles: " + PromedioGoles);
            str.AppendLine("Total Goles: " + this.totalGoles);

            return str.ToString();
        }

        public static bool operator ==(Jugador a, Jugador b)
        {
            return (a.dni == b.dni);
        }

        public static bool operator !=(Jugador a, Jugador b)
        {
            return !(a == b);
        }
    }
}
