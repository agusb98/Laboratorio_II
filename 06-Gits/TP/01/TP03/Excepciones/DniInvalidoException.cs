using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        string mensajeBase;

        public DniInvalidoException() : this("El DNI ingresado es inválido.") { }

        public DniInvalidoException(Exception e) : this("El DNI ingresado es inválido.", e) { }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {
            this.mensajeBase = mensaje;
        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            this.mensajeBase = mensaje;
        }

    }
}
