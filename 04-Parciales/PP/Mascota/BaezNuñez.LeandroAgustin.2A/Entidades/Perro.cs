using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        #region Campos

        private int edad;
        private bool esAlfa;

        #endregion

        #region Métodos

        public override bool Equals(object obj)
        {
            if (obj is Perro)
            {
                return (Perro)obj == this;
            }
            return false;
        }

        public static explicit operator int(Perro p) { return p.edad; }

        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            if(!(this is null))
            {
                if (this.esAlfa)
                {
                    sb.AppendFormat("Perro - {0}, es Alfa de la manada, edad {1}", this.DatosCompleto(), this.edad);
                }
                else
                {
                    sb.AppendFormat("Perro - {0}, edad {1}", this.DatosCompleto(), this.edad);
                }
            }

            return sb.ToString();
        }

        public static bool operator ==(Perro p1, Perro p2)
        {
            return p1.Raza == p2.Raza && p1.Nombre == p2.Nombre && p1.edad == p2.edad;
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        public Perro(string nombre, string raza, int edad, bool esAlfa) : base(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        public Perro(string nombre, string raza) : this(nombre, raza, 0, false) { }

        public override string ToString()
        {
            return this.Ficha();
        }

        #endregion
    }
}

