using ComiqueriaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobantesLogic
{
    public class Recibo : Comprobante
    {
        private double importePagado;

        public Recibo(Venta venta, double importePagado) :base (venta)
        {
            this.importePagado = importePagado;
        }

        public override string GenerarComprobante()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RECIBO");
            sb.AppendLine();
            sb.AppendLine(String.Format("Fecha de Emisión: {0}", this.fechaEmision));
            sb.AppendLine();
            sb.AppendLine(String.Format("Se recibió el pago de ${0} en concepto de {1} unidades de {2}.", this.importePagado, this.Venta.Cantidad, 
                ((Producto)this.Venta).Descripcion));

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && obj is Recibo)
            {
                return true;
            }

            return false;
        }
    }
}
