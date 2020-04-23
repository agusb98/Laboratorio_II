using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Biblioteca
{
    public class PuestoAtencion
    {
        #region Enumerados
        public enum Puesto
        {
            Caja1, Caja2
        }
        #endregion

        #region Atributos

        private static int numeroActual;
        private Puesto puesto;

        #endregion

        #region Propiedades
        public static int NumeroActual
        {
            get
            {
                numeroActual++;
                return numeroActual;
            }
        }
        public bool Atender(Cliente cli)
        {
            bool retorno = false;
            if (cli != null)
            {
                Thread.Sleep(1500);
                retorno = true;
            }

            return retorno;
        }
        #endregion

        #region Constructores

        private PuestoAtencion()
        {
            numeroActual = 0;
        }

        public PuestoAtencion(Puesto puesto) : this()
        {
            this.puesto = puesto;
        }
        #endregion
    }
}
