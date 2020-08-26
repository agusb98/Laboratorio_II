using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Mascota
    {
        #region Campos

        private string nombre;
        private string raza;

        #endregion

        #region Propiedades

        public string Nombre { get { return this.nombre; } }
        public string Raza { get { return this.raza; } }



        #endregion

        #region Métodos

        protected virtual string DatosCompleto()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("{0} - {1}", Nombre, Raza);
            }

            return sb.ToString();
        }

        protected abstract string Ficha();

        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }

        public static bool operator ==(Mascota m1, Mascota m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }
        #endregion
    }
}
