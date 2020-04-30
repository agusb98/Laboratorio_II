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
        #region Nested types
        public enum Puesto
        {
            Caja1, Caja2
        }
        #endregion

        #region Fields

        private static int numeroActual;
        private Puesto puesto;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el Numero Actual 
        /// </summary>
        public static int NumeroActual
        {
            get
            {
                numeroActual++;
                return numeroActual;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></Cliente>
        /// <returns></returns>
        public bool Atender(Cliente c)
        {
            if (c != null)
            {
                Thread.Sleep(1500);
                return true;
            }
            return false;
        }

        private PuestoAtencion() { numeroActual = 0; }

        public PuestoAtencion(Puesto puesto) : this()
        {
            this.puesto = puesto;
        }
        #endregion
    }
}
