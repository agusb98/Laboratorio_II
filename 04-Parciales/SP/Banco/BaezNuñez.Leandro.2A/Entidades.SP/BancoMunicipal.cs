using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class BancoMunicipal : BancoProvincial
    {
        private string municipio;

        public string Municipio
        {
            get { return this.municipio; }
            set { this.municipio = value; }
        }

        public BancoMunicipal(BancoProvincial bancoProvincial, string municipio)
            : base(new BancoNacional(bancoProvincial.Nombre, bancoProvincial.Pais), bancoProvincial.Provincia)
        {
            this.Municipio = municipio;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", base.Mostrar());
            sb.AppendFormat("MUNICIPALIDAD: {0}\n", this.Municipio);

            return sb.ToString();
        }

        public override string Mostrar(Banco b)
        {
            return b.Mostrar();
        }
    }
}
