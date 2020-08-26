using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion()
        {
            return (float)0.40 * this.Precio;
        }

        static Jugo() { Jugo.DeConsumo = true; }

        public Jugo (int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor) :
            base(codigoBarra, marca, precio)
        { this._sabor = sabor; }

        public override string ToString()
        {
            return this.MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)this);
            sb.AppendFormat("\nSABOR: {0}", this._sabor);

            return sb.ToString();
        }
    public enum ESaborJugo { Asqueroso, Pasable, Rico }
    }
}
