using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobantesLogic
{
    public abstract class Comprobante
    {
        private DateTime FechaEmision;
        private Venta venta;

        public abstract string GenerarComprobante();
    }
}
