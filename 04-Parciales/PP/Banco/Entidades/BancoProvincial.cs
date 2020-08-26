using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoProvincial : BancoNacional
    {
        #region Atributos

        private string provincia;

        #endregion

        #region Atributos

        /// <summary>
        /// Obtiene la provincia de la clase BancoProvincial
        /// </summary>
        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }

        #endregion

        #region Metodos

        public BancoProvincial(BancoNacional bancoNacional ,string provincia) 
            : base(bancoNacional.Nombre, bancoNacional.Pais)
        {
            this.provincia = provincia;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre : {0}", Nombre);

            return sb.ToString();
        }

        public override string Mostrar(Banco banco)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(banco.Mostrar());
            sb.AppendFormat(" - Provincia : {0}", ((BancoProvincial)banco).Provincia);

            return sb.ToString();
        }

        #endregion
    }
}
