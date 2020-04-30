using System;
using System.Text;


namespace Biblioteca
{
    public class Jugador : Persona
    {
        #region Fields

        private int totalGoles;
        private int partidosJugados;
        private float promedioGoles;

        #endregion

        #region Properties

        /// <summary>
        /// Instancia un nuevo Jugador
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="totalGoles"></param>
        /// <param name="partidosJugados"></param>

        public Jugador(Persona persona, int totalGoles, int partidosJugados) : base(persona)
        {
            this.totalGoles = totalGoles;
            this.partidosJugados = partidosJugados;
            this.promedioGoles = PromedioGoles;
        }

        /// <summary>
        /// Instancia un nuevo Jugador con atributos vacios
        /// </summary>
        public Jugador() : this(new Persona(), 0, 0) { }

        /// <summary>
        /// Modifica / Obitiene el promedio de goles 
        /// </summary>

        public float PromedioGoles
        {
            get
            {
                if (this.partidosJugados != 0)
                {
                    this.promedioGoles = this.totalGoles / (float)this.partidosJugados;
                }
                return this.promedioGoles;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Mustra los Atributos del Jugador
        /// </summary>
        /// <returns></returns>

        public string MostrarJugador()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Total Goles: " + this.totalGoles);
                str.AppendLine("Partidos: " + this.partidosJugados);
                str.AppendLine("Promedio Goles: " + this.PromedioGoles);
                str.Append(base.Mostrar());
            }

            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Jugadores
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Jugador a, Jugador b)
        {
            return ((Persona)a == (Persona)b);
        }

        /// <summary>
        /// Verifica desigualdad entre dos Jugadores
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Jugador a, Jugador b)
        {
            return !(a == b);
        }
        #endregion
    }
}
