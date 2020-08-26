using System.Text;

namespace Entidades
{
    public class Importador : Comercio
    {
        #region Atributos

        public EPaises paisOrigen;

        #endregion

        #region Constructores

        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) :
            base(nombreComercio, comerciante, precioAlquiler)
        {
            this.paisOrigen = paisOrigen;
        }
        #endregion

        #region Metodos

        public static implicit operator double(Importador n)
        {
            return n._precioAlquiler;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("{0}\n", (string)this);
                sb.AppendFormat("PAÍS DE ORIGEN: {0}", paisOrigen);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida desigualdad entre dos Importadores
        /// </summary>
        /// <param name="a"></Importador 1>
        /// <param name="b"></Importador 2>
        /// <returns></returns>
        public static bool operator !=(Importador a, Importador b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Valida igualdad entre dos Importadores
        /// </summary>
        /// <param name="a"></Importador 1>
        /// <param name="b"></Importador 2>
        /// <returns></returns>
        public static bool operator ==(Importador a, Importador b)
        {
            if (a.paisOrigen == b.paisOrigen && (Comercio)a == b)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
