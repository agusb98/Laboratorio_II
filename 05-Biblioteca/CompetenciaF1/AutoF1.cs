using System;
using System.Text;


namespace Biblioteca
{
    public class AutoF1
    {
        #region Fields

        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        #endregion

        private AutoF1()
        {
        }

        public AutoF1(short numero, string escuderia)
        {
            this.numero = numero;
            this.escuderia = escuderia;
        }

        public short CantidadCombustible
        {
            get
            {
                return this.cantidadCombustible;
            }
            set
            {
                if (value >= 0)
                {
                    this.cantidadCombustible = value;
                }
            }
        }

        public bool EnCompetencia
        {
            get
            {
                return this.enCompetencia;
            }
            set
            {
                this.enCompetencia = value;
            }
        }

        public short VueltasRestantes
        {
            get
            {
                return this.vueltasRestantes;
            }
            set
            {
                if (value >= 0)
                {
                    this.vueltasRestantes = value;
                }
            }
        }
        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Combustible: " + this.cantidadCombustible);
            str.AppendLine("Estado: " + this.enCompetencia);
            str.AppendLine("Escuderia: " + this.escuderia);
            str.AppendLine("Numero: " + numero);
            str.AppendLine("Vueltas Restantes: " + this.vueltasRestantes);

            return str.ToString();
        }

        public static bool operator ==(AutoF1 a, AutoF1 b)
        {
            return a.numero == b.numero && a.escuderia == b.escuderia;
        }

        public static bool operator !=(AutoF1 a, AutoF1 b)
        {
            return !(a == b);
        }
    }
}
