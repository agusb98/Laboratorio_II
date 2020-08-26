using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ECilindrada { cc50, cc125, cc250, cc500 }
    public class Moto : Vehiculo
    {
        ECilindrada cilindrada;

        /// 
        /// <summary>
        /// Instancia Moto 
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="pais"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        /// <param name="cilindrada"></param>
        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada) :
            base(marca, pais, modelo, precio)
        {
            this.cilindrada = cilindrada;
        }

        /// <summary>
        /// Obtiene datos en string de Moto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)(Vehiculo)this);
            sb.AppendFormat("\nCILINDRADA: {0}", this.cilindrada);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo sobreescrito validando que dos ovjetos son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Moto)
            {
                return (Moto)obj == this && (Vehiculo)obj == this;
            }
            return false;
        }

        /// <summary>
        /// retorna el precio de la Moto
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator float(Moto a)
        {
            return a.precio;
        }

        /// <summary>
        /// Valida igualdad entre dos Motos
        /// </summary>
        /// <param name="a"></Moto 1>
        /// <param name="b"></Moto 2>
        /// <returns></true si son iguales, false si no>
        public static bool operator ==(Moto a, Moto b)
        {
            return a.cilindrada == b.cilindrada;
        }

        /// <summary>
        /// Valida desigualdad entre dos Motos
        /// </summary>
        /// <param name="a"></Moto 1>
        /// <param name="b"></Moto 2>
        /// <returns></true si no son iguales, false si si>
        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }
    }
}
