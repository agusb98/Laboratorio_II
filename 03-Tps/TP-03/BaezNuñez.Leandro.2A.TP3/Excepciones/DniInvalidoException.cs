using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensaje = "DNI inválido.";
        public DniInvalidoException(): base(mensaje) { }

        public DniInvalidoException(Exception e) : base(mensaje, e) { }

        public DniInvalidoException(string error) : base(error) { }

        public DniInvalidoException(Exception e, string error) : base(error, e) { }


    }
}
