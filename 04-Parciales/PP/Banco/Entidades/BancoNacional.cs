using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BancoNacional : Banco
    {
        #region Atributos

        private string pais;

        #endregion

        #region Propiedades

        public string Pais
        {
            get { return this.pais; }
            set { this.pais = value; }
        }

        #endregion

        #region Metodos

        public BancoNacional(string nombre, string pais) : base(nombre) { Pais = pais; }

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
                sb.AppendFormat(" - Pais : {0}", ((BancoNacional)banco).pais);
            }

            return sb.ToString();
        }

        #endregion
    }
}
