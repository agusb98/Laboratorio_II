using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #region Metodos
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// Finaliza todos los hilos secundarios activos de la lista.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        /// <summary>
        /// Muestra los datos de cada paquete del correo.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = (List<Paquete>)((Correo)elementos).paquetes;
            StringBuilder sb = new StringBuilder();
            
            foreach (Paquete p in l)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }

            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            bool contienePaquete = false;

            foreach (Paquete item in c.Paquetes)
            {
                if (p == item)
                {
                    contienePaquete = true;
                }
            }

            if (contienePaquete)
            {
                throw new TrackingIdRepetidoException("El trackingID ya existe!");
            }
            else
            {
                c.Paquetes.Add(p);
                Thread hiloPaquete = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hiloPaquete);
                hiloPaquete.Start();
            }

            return c;
        }
        #endregion
    }
}
