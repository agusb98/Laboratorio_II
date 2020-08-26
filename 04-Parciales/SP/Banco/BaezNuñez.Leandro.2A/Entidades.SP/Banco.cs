using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public abstract class Banco
    {
        protected string nombre;
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public Banco(string nombre) { this.Nombre = nombre; }

        public abstract string Mostrar();
        
        public abstract string Mostrar(Banco b);

        public override string ToString()
        {
            return this.Mostrar(this);
        }
    }
}
