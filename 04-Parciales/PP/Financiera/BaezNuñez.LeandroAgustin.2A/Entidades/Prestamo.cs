using System;
using System.Text;

namespace PrestamosPersonales
{
    #region Enumerados

    public enum TipoDePrestamo { Pesos, Dolares, Todos}

    public enum PeriocidadDePagos { Mensual, Bimestral, Trimestral}

    #endregion

    public abstract class Prestamo
    {
        #region Atributos

        protected float monto;
        protected DateTime vencimiento;

        #endregion

        #region Propiedades
        public float Monto
        {
            get
            {
                return this.monto;
            }
        }

        public DateTime Vencimiento
        {
            get
            {
                return this.vencimiento;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    this.vencimiento = value;
                }
                else { this.vencimiento = DateTime.Now; }
            }
        }
        #endregion

        #region Constructores

        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            Vencimiento = vencimiento;

        }
        #endregion

        #region Metodos

        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            return DateTime.Compare(p1.vencimiento, p2.vencimiento);
        }

        /// <summary>
        /// Abstract method, set date of vencimiento
        /// </summary>
        /// <param name="nuevoVencimiento"></param>
        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Monto: {0}\n", Monto);
            sb.AppendFormat("Fecha de Vencimiento: {0}\n", Vencimiento);

            return sb.ToString();
        }

        #endregion
    }
}
