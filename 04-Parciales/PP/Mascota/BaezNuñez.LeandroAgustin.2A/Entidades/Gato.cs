using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gato : Mascota
    {
        #region Métodos

        public override bool Equals(object obj)
        {
            if (obj is Gato)
            {
                return (Gato)obj == this;
            }
            return false;
        }

        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("Gato - {0}", this.DatosCompleto());
            }

            return sb.ToString();
        }

        public static bool operator ==(Gato g1, Gato g2)
        {
            return g1.Raza == g2.Raza && g1.Nombre == g2.Nombre;
        }

        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }

        public Gato(string nombre, string raza) : base(nombre, raza) { }

        public override string ToString()
        {
            return this.Ficha();
        }

        #endregion
    }
}
