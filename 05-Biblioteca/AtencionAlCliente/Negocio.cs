using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        private Negocio()
        {
            clientes = new Queue<Cliente>();
            caja = new PuestoAtencion(PuestoAtencion.Puesto.Caja1);
        }

        public Negocio(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Cliente Cliente
        {
            get
            {
                if (this.clientes.Count != 0)
                    return this.clientes.Dequeue();
                else
                    return null;
            }
            set
            {
                bool var = this + value;
            }
        }

        public static bool operator +(Negocio n, Cliente c)
        {
            if (n != c) //Si no esta en la cola.
            {
                n.clientes.Enqueue(c);
                return true;
            }

            return false;
        }

        public static bool operator ==(Negocio n, Cliente c)
        {
            foreach (Cliente cliente in n.clientes)
            {
                if (cliente == c)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }

        public static bool operator ~(Negocio negocio)
        {
            bool retorno = false;

            if (negocio.caja.Atender(negocio.Cliente))
                retorno = true;

            return retorno;
        }
    }
}
