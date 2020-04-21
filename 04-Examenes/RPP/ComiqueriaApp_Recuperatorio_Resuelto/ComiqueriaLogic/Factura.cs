using ComiqueriaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobantesLogic
{
    public class Factura : Comprobante
    {
        public enum TipoFactura
        {
            A, B, C, E
        }

        private DateTime fechaVencimiento;
        private TipoFactura tipoFactura;

        public Factura (Venta venta, int diasParaVencimiento, TipoFactura tipoFactura) :base (venta)
        {
            this.fechaVencimiento = DateTime.Now.AddDays(diasParaVencimiento);
            this.tipoFactura = tipoFactura;
        }

        public Factura (Venta venta, TipoFactura tipoFactura) :this (venta, 15, tipoFactura)
        {           
        }

        public override string GenerarComprobante()
        {
            double precioUnidad = ((Producto)this.Venta).Precio;
            double subTotal = precioUnidad * this.Venta.Cantidad;
            double importeTotal = Venta.CalcularPrecioFinal(precioUnidad, this.Venta.Cantidad);
            double importeIva = importeTotal - subTotal;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Factura {0}", this.tipoFactura));
            sb.AppendLine();
            sb.AppendLine(String.Format("Fecha de Emisión: {0}", this.fechaEmision));
            sb.AppendLine(String.Format("Fecha de Vencimiento: {0}", this.fechaVencimiento));
            sb.AppendLine();
            sb.AppendLine(String.Format("Producto: {0}", ((Producto)this.Venta).Descripcion));
            sb.AppendLine(String.Format("Cantidad: {0}", this.Venta.Cantidad));
            sb.AppendLine(String.Format("Precio Unitario: ${0:0.00}", ((Producto)this.Venta).Precio));
            sb.AppendLine();
            sb.AppendLine(String.Format("Subtotal: ${0:0.00}", subTotal));
            sb.AppendLine(String.Format("Importe IVA: ${0:0.00}", importeIva));
            sb.AppendLine(String.Format("Importe Total: ${0:0.00}", importeTotal));

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Factura && base.Equals(obj) && this.tipoFactura == ((Factura)obj).tipoFactura)
            {
                return true;
            }

            return false;
        }
    }
}
