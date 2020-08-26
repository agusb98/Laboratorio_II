using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        protected string apellido;
        protected string nombre;

        public string Apellido { get { return this.apellido; } }

        public string Nombre { get { return this.nombre; } }

        protected abstract string FichaTecnica();

        protected virtual string NombreCompleto()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} {1}", this.Nombre, this.Apellido);

            return sb.ToString();
        }

        /// <summary>
        /// Instancia nombre y apellido de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
