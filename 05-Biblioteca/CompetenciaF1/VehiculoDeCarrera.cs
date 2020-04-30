using System;
using System.Text;

namespace Biblioteca
{
    public class VehiculoDeCarreras
    {
        #region Fields

        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        #endregion

        #region Properties
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

        public short Numero
        {
            get
            {
                return this.numero;
            }
            set
            {
                if (value >= 0)
                {
                    this.numero = value;
                }
            }
        }

        public string Escuderia
        {
            get
            {
                return this.escuderia;
            }
            set
            {
                this.escuderia = value;
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

        #endregion

        #region Methods

        /// <summary>
        /// Instancia un nuevo Vehiculo de Carreras con atributos pasados por parametro
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="escuderia"></param>
        public VehiculoDeCarreras(short numero, string escuderia)
        {
            this.numero = numero;
            this.escuderia = escuderia;
        }

        /// <summary>
        /// Muestra por pantalla los datos del Vehiculo de Carreras
        /// </summary>
        /// <returns></returns> string con datos Mostrados por pantalla
        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Combustible: " + CantidadCombustible);
                str.AppendLine("Estado: " + EnCompetencia);
                str.AppendLine("Escuderia: " + Escuderia);
                str.AppendLine("Numero: " + Numero);
                str.AppendLine("Vueltas Restantes: " + VueltasRestantes);
            }
            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Vehiculos de Carreras
        /// </summary>
        /// <param name="a"><Vehiculo 1/param>
        /// <param name="b"><Vehiculo 1/param>
        /// <returns></returns>
        public static bool operator == (VehiculoDeCarreras a, VehiculoDeCarreras b)
        {
            return a.Escuderia == b.Escuderia && a.Numero == b.Numero;
        }

        /// <summary>
        /// Verifica desigualdad entre dos Vehiculos de Carreras
        /// </summary>
        /// <param name="a"><Vehiculo 1/param>
        /// <param name="b"><Vehiculo 1/param>
        /// <returns></returns>
        public static bool operator !=(VehiculoDeCarreras a, VehiculoDeCarreras b)
        {
            return !(a == b);
        }

        #endregion
    }
}
