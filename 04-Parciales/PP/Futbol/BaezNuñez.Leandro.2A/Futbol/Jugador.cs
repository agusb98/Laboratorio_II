using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        protected bool esCapitam;
        protected int numero;

        public bool EsCapitan { get { return this.esCapitam; } }

        public int Numero { get { return this.numero; } }
    
        public Jugador(string nombre, string apellido, int numero, bool capitan):
            base(nombre, apellido)
        {
            this.numero = numero;
            this.esCapitam = capitan;
        }

        public Jugador(string nombre, string apellido) :
            this(nombre, apellido, 0, false)
        { }

        public override bool Equals(object obj)
        {
            if (obj is Jugador)
            {
                return (Jugador)obj == this;
            }
            return false;
        }

        public static explicit operator int (Jugador jugador)
        {
            return jugador.Numero;
        }

        protected override string FichaTecnica()
        {
            StringBuilder sb = new StringBuilder();

            if (this.EsCapitan == true)
            {
                sb.AppendFormat("{0}, capitán del equipo, camiseta numero {1}", this.NombreCompleto(), (int)this);
            }
            else
            {
                sb.AppendFormat("{0}, camiseta numero {1}", this.NombreCompleto(), (int)this);
            }
            return sb.ToString();
        }

        public static bool operator ==(Jugador a, Jugador b)
        {
            return a.NombreCompleto() == b.NombreCompleto() && (int)a == (int)b;
        }

        public static bool operator !=(Jugador a, Jugador b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }
    }
}
