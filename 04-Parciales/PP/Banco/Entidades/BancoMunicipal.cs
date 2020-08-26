using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoMunicipal : BancoProvincial
    {
        #region Atributos

        private string municipio;

        #endregion

        #region Propiedades

        protected string Municipio
        {
            get { return this.municipio; }
            set { this.municipio = value; }
        }

        #endregion

        #region Metodos

        public BancoMunicipal(BancoProvincial provincial, string municipio)
            : base(provincial, provincial.Provincia)
        {
            this.municipio = municipio;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}", Nombre);

            return sb.ToString();
        }

        public override string Mostrar(Banco banco)
        {
            StringBuilder sb = new StringBuilder();

            if (!(banco is null))
            {
                sb.AppendFormat(banco.Mostrar());
                sb.AppendFormat(" - Municipio : {0}", ((BancoMunicipal)banco).Municipio);
            }

            return sb.ToString();
        }

        #endregion
    }
}
