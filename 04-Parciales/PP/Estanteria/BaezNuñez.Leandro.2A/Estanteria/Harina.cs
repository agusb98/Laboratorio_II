using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 
    public class Harina : Producto
    {
        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion()
        {
            return (float)0.6 * this.Precio;
        }

        static Harina() { Harina.DeConsumo = true; }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo) :
            base(codigoBarra, marca, precio)
        { this._tipo = tipo; }

        public override string ToString()
        {
            return this.MostrarHarina();
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)this);
            sb.AppendFormat("\nTIPO: {0}", this._tipo);

            return sb.ToString();
        }
    public enum ETipoHarina { CuatroCeros, TresCeros, Integral }
    }
}
