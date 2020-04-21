using ComiqueriaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprobantesLogic
{    
    public abstract class Comprobante
    {
        protected DateTime fechaEmision;
        private Venta venta;

        internal Venta Venta
        {
            get
            {
                return this.venta;
            }
        }

        public Comprobante(Venta venta)
        {
            this.venta = venta;
            this.fechaEmision = venta.Fecha;
        }

        public abstract string GenerarComprobante();

        public override bool Equals(object obj)
        {
            if (obj is Comprobante && ((Comprobante)obj).fechaEmision == this.fechaEmision)
            {
                return true;
            }

            return false;
        }
    }
}
