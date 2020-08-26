using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        protected override string FichaTecnica()
        {
            return this.NombreCompleto();
        }

        public DirectorTecnico(string nombre, string apellido):
            base(nombre, apellido)
        { }

        public override string ToString()
        {
            return base.NombreCompleto();
        }
    }
}
