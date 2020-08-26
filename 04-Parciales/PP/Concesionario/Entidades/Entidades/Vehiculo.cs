using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EPais { Italia, Francia, Alemania }

    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        /// <summary>
        /// Instancia atributo estatico generador de velocidades de Vehiculo
        /// </summary>
        static Vehiculo()
        {
            Vehiculo.generadorDeVelocidades = new Random();
        }

        /// <summary>
        /// Instancia Vehiculo
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="modelo"></param>
        /// <param name="fabri"></param>
        public Vehiculo(float precio, string modelo, Fabricante fabri)
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
            this.velocidadMaxima = this.VelocidadMaxima;
        }

        /// <summary>
        /// Instancia Vehiculo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="pais"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Vehiculo(string marca, EPais pais, string modelo, float precio):
            this(precio, modelo, new Fabricante(marca, pais))
        { }

        /// <summary>
        /// Propiedad read/Write del atributo Velocidad Maxima de Vehiculo
        /// </summary>
        public int VelocidadMaxima
        {
            get
            {
                if (velocidadMaxima == 0)
                {
                    this.velocidadMaxima = Vehiculo.generadorDeVelocidades.Next(100, 281);
                }
                return this.velocidadMaxima;
            }
        }

        /// <summary>
        /// Retorna cadena de string con informacion del vehiculo
        /// </summary>
        /// <param name="v"></param>
        public static explicit operator string(Vehiculo v)
        {
            return Mostrar(v);
        }

        /// <summary>
        /// Retorna cadena de string con informacion del vehiculo
        /// </summary>
        /// <param name="v"></param>
        private static string Mostrar(Vehiculo v)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat((string)v.fabricante);
            sb.AppendFormat("\nMODELO: {0}", v.modelo);
            sb.AppendFormat("\nVELOCIDAD MÁXIMA: {0}", v.VelocidadMaxima);
            sb.AppendFormat("\nPRECIO: {0}", v.precio);

            return sb.ToString();
        }

        /// <summary>
        /// Valida igualdad entre dos Vehiculos
        /// </summary>
        /// <param name="a"></Vehiculo 1>
        /// <param name="b"></Vehiculo 2>
        /// <returns></True son iguales, False si no>
        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            return a.modelo == b.modelo && a.fabricante == b.fabricante;
        }

        /// <summary>
        /// Valida desigualdad entre dos Vehiculos
        /// </summary>
        /// <param name="a"></Vehiculo 1>
        /// <param name="b"></Vehiculo 2>
        /// <returns></false son iguales, true si no>
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }
    }
}
