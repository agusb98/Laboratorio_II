using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETipo{ Deportivo, Sedan, Coupe, Familiar}
    public class Auto : Vehiculo
    {
        ETipo tipo;

        /// <summary>
        /// Instancia Auto
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        /// <param name="fabri"></param>
        /// <param name="tipo"></param>
        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo):
            base(precio, modelo, fabri)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Obtiene datos en string de Auto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)(Vehiculo)this);
            sb.AppendFormat("\nTIPO: {0}", this.tipo);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo sobreescrito validando que dos ovjetos son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Auto)
            {
                return (Auto)obj == this && (Vehiculo)obj == this;
            }
            return false;
        }

        /// <summary>
        /// retorna el precio de un Autot
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator float(Auto a)
        {
            return a.precio;
        }

        /// <summary>
        /// Valida igualdad entre dos Autos
        /// </summary>
        /// <param name="a"></Auto 1>
        /// <param name="b"></Auto 2>
        /// <returns></True son iguales, False son distintos>
        public static bool operator ==(Auto a, Auto b)
        {
            return a.tipo == b.tipo;
        }

        /// <summary>
        /// Valida desigualdad entre dos Autos
        /// </summary>
        /// <param name="a"></Auto 1>
        /// <param name="b"></Auto 2>
        /// <returns></False son iguales, True son distintos>
        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }
    }
}
