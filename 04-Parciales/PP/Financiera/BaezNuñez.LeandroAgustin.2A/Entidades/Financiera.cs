using System;
using System.Collections.Generic;
using System.Text;
using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        #region Atributos

        private List<Prestamo> listaDePrestamos;
        private string razonSocial;

        #endregion

        #region Propiedades

        public float InteresesEnDolares
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Dolares);
            }
        }

        public float InteresesEnPesos
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Pesos);
            }
        }

        public float InteresesTotales
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Todos);
            }
        }

        public List<Prestamo> ListaDePrestamos
        {
            get
            {
                return this.listaDePrestamos;
            }
        }

        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }
        #endregion

        #region Constructores
        private Financiera()
        {
            this.listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }
        #endregion

        #region Metodos

        private float CalcularInteresGanado(TipoDePrestamo tipoDePrestamo)
        {
            float interesDolar = 0;
            float interesPeso = 0;
            float interesGeneral = 0;
            float retorno = 0;

            foreach (Prestamo item in this.listaDePrestamos)
            {
                if (item is PrestamoPesos)
                {
                    interesPeso += ((PrestamoPesos)item).Interes;
                    interesGeneral += interesPeso;
                }
                else if (item is PrestamoDolares)
                {
                    interesDolar += ((PrestamoDolares)item).Interes;
                    interesGeneral += interesDolar;
                }
            }

            switch (tipoDePrestamo)
            {
                case TipoDePrestamo.Pesos:
                    retorno = interesPeso;
                    break;
                case TipoDePrestamo.Dolares:
                    retorno = interesDolar;
                    break;
                case TipoDePrestamo.Todos:
                    retorno = interesGeneral;
                    break;
                default:
                    break;
            }
            return retorno;
        }

        public static explicit operator string(Financiera financiera)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n******************************************\n\n");
            sb.AppendFormat("Razon Social: {0}\n", financiera.RazonSocial);
            sb.AppendFormat("Intereses en Dólares: {0}\n", financiera.InteresesEnDolares);
            sb.AppendFormat("Intereses en Pesos: {0}\n", financiera.InteresesEnPesos);
            sb.AppendFormat("Intereses Totales: {0}\n\n", financiera.InteresesTotales);

            financiera.OrdenarPrestamos();

            foreach (Prestamo prestamo in financiera.listaDePrestamos)
            {
                sb.AppendFormat((prestamo).Mostrar());
            }
            sb.AppendFormat("\n\n******************************************\n");

            return sb.ToString();
        }

        public static string Mostrar(Financiera financiera)
        {
            return (string)financiera;
        }

        /// <summary>
        /// Validad igualdad entre Shopping y Prestamo
        /// </summary>
        /// <param name="financiera"></Financiera>
        /// <param name="prestamo"></Prestamo>
        /// <returns></returns>
        public static bool operator ==(Financiera financiera, Prestamo prestamo)
        {
            foreach (Prestamo item in financiera.ListaDePrestamos)
            {
                if (item == prestamo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Validad desigualdad entre Shopping y Prestamo
        /// </summary>
        /// <param name="financiera"></Financiera>
        /// <param name="prestamo"></Prestamo>
        /// <returns></returns>
        public static bool operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }

        public static Financiera operator +(Financiera financiera, Prestamo prestamo)
        {
            if (financiera == prestamo)
            { Console.WriteLine("El prestamo ya se encuentra en la Financiera!"); }

            else { financiera.listaDePrestamos.Add(prestamo); }

            return financiera;
        }

        public void OrdenarPrestamos()
        {
            this.ListaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }

        #endregion
    }
}
