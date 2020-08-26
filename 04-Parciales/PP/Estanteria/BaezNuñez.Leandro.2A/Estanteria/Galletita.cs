using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected float _peso;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion()
        {
            return (float)0.33 * this.Precio;
        }

        static Galletita() { Galletita.DeConsumo = true; }

        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso) :
            base(codigoBarra, marca, precio)
        { this._peso = peso; }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }

        private string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n{0}", (string)g);
            sb.AppendFormat("\nPESO: {0}", g._peso);

            return sb.ToString();
        }
    }
}
