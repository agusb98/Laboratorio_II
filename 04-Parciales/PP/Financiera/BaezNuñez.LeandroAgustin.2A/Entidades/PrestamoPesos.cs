using System;
using System.Text;

namespace PrestamosPersonales
{
    public class PrestamoPesos : Prestamo
    {
        #region Atributos

        private float porcentajeInteres;

        #endregion

        #region Propiedades

        /// <summary>
        /// OnlyRead; muestra el porcentaje de intereses del Préstamo en Pesos
        /// </summary>
        public float Interes
        {
            get { return CalcularInteres(); }
        }

        #endregion

        #region Métodos

        private float CalcularInteres()
        {
            return (porcentajeInteres * Monto) % 100;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            float dias = (float)(Vencimiento - nuevoVencimiento).TotalDays;
            this.porcentajeInteres += (int)0.25 * dias;
            this.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Prestamo en Pesos\n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("Interes: {0}%\n", Interes);

            return sb.ToString();
        }

        public PrestamoPesos(float monto, DateTime vencimiento, float interes) : base(monto, vencimiento)
        {
            this.porcentajeInteres = interes;
        }

        public PrestamoPesos(Prestamo prestamo, float porcentajeInteres) : this(prestamo.Monto, prestamo.Vencimiento, porcentajeInteres)
        {
        }
        #endregion
    }
}
