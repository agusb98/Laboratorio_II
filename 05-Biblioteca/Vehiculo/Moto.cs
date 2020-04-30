﻿using System;
using System.Text;

namespace Biblioteca
{
    public class Moto : Vehiculo
    {
        #region Atributos

        private double velocidadMax;

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

        #endregion

        #region Constructores

        /// <summary>
        /// Instancia Moto con atributos pasados por parametro
        /// </summary>
        /// <param name="velocidadMax"></param>
        /// <param name="marca"></param>
        /// <param name="vehiculo"></param>
        public Moto(double velocidadMax, string patente, byte cantRuedas, EColores color):
            base(patente, cantRuedas, color)
        {
            this.velocidadMax = velocidadMax;
        }

        /// <summary>
        /// Instancia Moto con atributos vacios
        /// </summary>
        public Moto() : base(){ }

        #endregion

        #region Metodos

        protected override string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine(base.Mostrar());
                str.AppendLine("Velocidad Max: " + this.VelocidadMax);
            }

            return str.ToString();
        }

        public override string ToString()
        {
            return Mostrar();
        }
        #endregion
    }
}
