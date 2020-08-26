using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PickUp : Vehiculo
    {
        protected string modelo;
        protected static int valorHora;

        static PickUp() { PickUp.valorHora = 70; }

        public PickUp(string patente, string modelo) :
            base(patente)
        {
            this.modelo = modelo;
        }

        public PickUp(string patente, string modelo, int valorHora) :
            this(patente, modelo)
        {
            PickUp.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat("\nMODELO {0}", this.modelo);

            return sb.ToString();
        }

        public override string ImprimirTicket()
        {
            return this.ConsultarDatos();
        }

        public override bool Equals(object obj)
        {
            return obj is PickUp;
        }
    }
}
