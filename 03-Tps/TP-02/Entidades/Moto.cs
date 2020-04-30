using System;
using System.Text;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará el tamaño de Moto
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Instanciacion Moto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) :
            base(codigo, marca, color)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0} \n", this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
