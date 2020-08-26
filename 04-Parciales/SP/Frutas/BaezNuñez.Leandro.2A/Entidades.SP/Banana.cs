using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public string Nombre { get { return "Banana"; } }

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FRUTA: {0}\n", this.Nombre);
            sb.AppendFormat("{0}", base.FrutaToString());
            sb.AppendFormat("TIENE CAROZO: {0}\n", this.TieneCarozo);
            sb.AppendFormat("PAIS ORIGEN: {0}\n", this._paisOrigen);

            return sb.ToString();
        }
    }
}
