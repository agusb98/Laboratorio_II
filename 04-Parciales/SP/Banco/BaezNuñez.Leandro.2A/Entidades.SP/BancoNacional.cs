using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class BancoNacional : Banco
    {
        protected string pais;

        public string Pais
        {
            get { return this.pais; }
            set { this.pais = value; }
        }

        public BancoNacional(string nombre, string pais) : base(nombre)
        {
            this.Pais = pais;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE: {0}\n", this.Nombre);
            sb.AppendFormat("PAIS: {0}\n", this.Pais);

            return sb.ToString();
        }

        public override string Mostrar(Banco b)
        {
            return b.Mostrar();
        }
    }
}
