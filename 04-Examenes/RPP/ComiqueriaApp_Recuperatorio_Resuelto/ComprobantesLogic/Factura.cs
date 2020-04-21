using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobantesLogic
{
    public class Factura : Comprobante
    {
        private Factura factura;

        public Factura InstanciaFactura
        {
            get
            {
                if (factura == null)
                {
                    this.factura = new Factura();
                }

                return this.factura;
            }
        }

        private Factura()
        {

        }

        public override string GenerarComprobante()
        {
            throw new NotImplementedException();
        }
    }
}
