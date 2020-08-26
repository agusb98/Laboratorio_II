using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public delegate void Delegado(object sender, EventArgs e);

    public class EntidadesFinancieras<T> where T : Banco
    {
        private List<T> _elementos;
        private int _capacidad;

        public event Delegado ElementosParesEvent;

        EntidadesFinancieras() { this._elementos = new List<T>(); }

        public EntidadesFinancieras(int capacidad) : this()
        {
            if (capacidad > 0)
            {
                this._capacidad = capacidad;
            }
        }

        public void Add(T elemento)
        {
            if (this._elementos.Count < this._capacidad)
            {
                this._elementos.Add(elemento);

                if ((this._elementos.Count % 2) == 0)
                {
                    this.ElementosParesEvent(elemento, null);
                }
            }
        }
    }
}
