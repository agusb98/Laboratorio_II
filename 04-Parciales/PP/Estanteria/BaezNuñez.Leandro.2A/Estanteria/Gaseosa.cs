using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion()
        {
            return (float)0.42 * this.Precio;
        }

        static Gaseosa() { Gaseosa.DeConsumo = true; }

        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros) :
            base(codigoBarra, marca, precio)
        { this._litros = litros; }

        public Gaseosa(Jugo jugo, float litros) : base((int)jugo, jugo.Marca, jugo.Precio)
        { }

        public override string ToString()
        {
            return this.MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)this);
            sb.AppendFormat("\nLITROS: {0}", this._litros);

            return sb.ToString();
        }
    }
}
