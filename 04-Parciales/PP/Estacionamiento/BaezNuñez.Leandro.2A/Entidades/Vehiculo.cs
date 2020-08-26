using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected DateTime ingreso;
        protected string patente;

        public string Patente
        {
            get { return this.patente; }
            set
            {
                if (value.Length == 6) { this.patente = value; }
            }
        }
        public abstract string ConsultarDatos();

        public virtual string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(this.ToString());
            sb.AppendFormat("\nFECHA HORA DE INGRESO {0}", this.ingreso);

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nPATENTE {0}", this.Patente);

            return sb.ToString();
        }

        public Vehiculo(string patente)
        {
            this.Patente = patente;
            this.ingreso = DateTime.Now.AddHours(-3);
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            return a.Equals(b) && a.Patente == b.Patente;
        }

        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Vehiculo;
        }
    }
}
