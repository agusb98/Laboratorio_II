using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        protected ConsoleColor color;
        protected static int valorHora;

        static Automovil() { Automovil.valorHora = 50; }

        public Automovil(string patente, ConsoleColor color) : 
            base(patente)
        {
            this.color = color;
        }

        public Automovil(string patente, ConsoleColor color, int valorHora) :
            this(patente, color)
        {
            Automovil.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nCOLOR {0}", this.color);

            return sb.ToString();
        }

        public override string ImprimirTicket()
        {
            return this.ConsultarDatos();
        }

        public override bool Equals(object obj)
        {
            return obj is Automovil;
        }
    }
}
