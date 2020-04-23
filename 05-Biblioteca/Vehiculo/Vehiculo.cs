using System;
using System.Text;

namespace Biblioteca
{
    public class Vehiculo
    {
        #region Atributos

        private string patente;
        private string propietario;
        private byte cantRuedas;
        private EMarca marca;

        #endregion

        #region Propiedades

        public string Propietario
        {
            get
            {
                return this.propietario;
            }
            set
            {
                this.propietario = value;
            }
        }

        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                this.patente = value;
            }
        }

        public byte CantRuedas
        {
            get
            {
                return this.cantRuedas;
            }
            set
            {
                if (value > 0)
                    this.cantRuedas = value;
            }
        }

        #endregion

        #region Constructor

        public Vehiculo() :
           this(string.Empty, string.Empty, 0)
        {

        }

        public Vehiculo(string patente, string propietario, byte cantRuedas)
        {
            this.patente = patente;
            this.cantRuedas = cantRuedas;
            this.propietario = propietario;
        }

        #endregion

        #region Metodos

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Patente: " + this.Patente);
            str.AppendLine("Propietario: " + this.Propietario);
            str.AppendLine("Cantidad de Ruedas: " + this.CantRuedas);

            return str.ToString();
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.Patente == v2.Patente;
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion
    }
}
