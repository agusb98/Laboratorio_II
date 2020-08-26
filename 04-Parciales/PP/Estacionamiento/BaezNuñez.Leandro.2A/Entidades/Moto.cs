using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        protected int cilindrada;
        protected short ruedas;
        protected static int valorHora;

        static Moto() { Moto.valorHora = 30; }

        public Moto(string patente, int cilindrada) :
            base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = 2;
        }

        public Moto(string patente, int cilindrada, short ruedas) :
            this(patente, cilindrada)
        {
            this.ruedas = ruedas;
        }

        public Moto(string patente, int cilindrada, short ruedas, int valorHora) :
            this(patente, cilindrada, ruedas)
        {
            Moto.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ImprimirTicket());
            sb.AppendFormat("\nCILINDRADA {0}", this.cilindrada);
            sb.AppendFormat("\nRUEDAS {0}", this.ruedas);

            return sb.ToString();
        }

        public override string ImprimirTicket()
        {
            return this.ConsultarDatos();
        }

        public override bool Equals(object obj)
        {
            return obj is Moto;
        }
    }
}
