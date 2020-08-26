using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public string Nombre { get { return "Durazno"; } }

        public Durazno(string color, double peso, int peluza) : base(color, peso)
        {
            this._cantPelusa = peluza;
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FRUTA: {0}\n", this.Nombre);
            sb.AppendFormat("{0}", base.FrutaToString());
            sb.AppendFormat("TIENE CAROZO: {0}\n", this.TieneCarozo);
            sb.AppendFormat("PELUSA: {0}\n", this._cantPelusa);

            return sb.ToString();
        }
    }
}
