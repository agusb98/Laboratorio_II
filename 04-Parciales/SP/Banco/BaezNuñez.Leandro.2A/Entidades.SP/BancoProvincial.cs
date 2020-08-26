using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class BancoProvincial : BancoNacional
    {
        protected string provincia;

        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }

        public BancoProvincial(BancoNacional bancoNacional, string provincia)
            : base(bancoNacional.Nombre, bancoNacional.Pais)
        {
            this.Provincia = provincia;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", base.Mostrar());
            sb.AppendFormat("PROVINCIA: {0}\n", this.Provincia);

            return sb.ToString();
        }
        public override string Mostrar(Banco b)
        {
            return b.Mostrar();
        }
    }
}
