using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado
    }


    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;

        string direccionEntrega;
        EEstado estado;
        string trackingID;

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion
        
        #region Metodos
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Cambia el estado del paquete para completar su ciclo, y ejecuta un evento InformaEstado.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);

                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.Estado = EEstado.Entregado;
                        break;
                }

                this.InformaEstado(this, new EventArgs());
            }

            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra los datos de un paquete como texto.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);

            return retorno;
        }

        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
