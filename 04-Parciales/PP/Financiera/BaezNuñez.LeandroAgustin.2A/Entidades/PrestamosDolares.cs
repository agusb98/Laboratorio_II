using System;
using System.Text;

namespace PrestamosPersonales
{
    public class PrestamoDolares : Prestamo
    {
        #region Atributos

        private PeriocidadDePagos periocidadDePagos;

        #endregion

        #region Propiedades

        /// <summary>
        /// OnlyRead; muestra el porcentaje de intereses del Préstamo en Pesos
        /// </summary>
        public float Interes
        {
            get { return CalcularInteres(); }
        }

        /// <summary>
        /// OnlyRead; muestra periocidad de pagos
        /// </summary>
        public PeriocidadDePagos Periocidad
        {
            get { return periocidadDePagos; }
        }

        #endregion

        #region Métodos

        private float CalcularInteres()
        {
            switch (periocidadDePagos)
            {
                case PeriocidadDePagos.Mensual:
                    {
                        return 25;
                    }
                case PeriocidadDePagos.Bimestral:
                    {
                        return 35;
                    }
                case PeriocidadDePagos.Trimestral:
                    {
                        return 40;
                    }
            }
            return -1;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            double dias = (nuevoVencimiento - (Vencimiento)).TotalDays;
            monto += (float)(dias * 2.5);
            Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Prestamo en Dólares\n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("Periocidad de Pagos: {0}\n", Periocidad);

            return sb.ToString();
        }

        public PrestamoDolares(float monto, DateTime vencimiento, PeriocidadDePagos periocidad) :
            base(monto, vencimiento)
        { this.periocidadDePagos = periocidad; }

        public PrestamoDolares(Prestamo prestamo, PeriocidadDePagos periocidad)
            : base(prestamo.Monto, prestamo.Vencimiento) { }

        #endregion
    }
}
