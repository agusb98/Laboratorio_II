using System;
using System.Text;

namespace Biblioteca
{
    public class Moto : Vehiculo
    {
        #region Atributos

        private double velocidadMax;
        private string marca;

        #endregion

        #region Propiedades

        public double VelocidadMax
        {
            get
            {
                return this.velocidadMax;
            }
            set
            {
                if (value >= 0)
                    this.velocidadMax = value;
            }
        }

        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }

        #endregion

        #region Constructores

        public Moto() :
           this(0, string.Empty)
        {

        }

        public Moto(double velocidadMax, string marca)
        {
            this.velocidadMax = velocidadMax;
            this.marca = marca;
        }

        #endregion

        #region Metodos

        public string MostrarMoto()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Marca: " + this.Marca);
            str.AppendLine("Velocidad Max: " + this.VelocidadMax);

            return str.ToString();
        }

        #endregion
    }
}
