using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        int dni;
        string nombre;
        string apellido;
        ENacionalidad nacionalidad;

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!(string.IsNullOrWhiteSpace(this.ValidarNombreApellido(value))))
                {
                    this.apellido = value;
                }
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if ( !(string.IsNullOrWhiteSpace(this.ValidarNombreApellido(value))) )
                {
                    this.nombre = value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                {
                    this.nacionalidad = value;
                }
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Muestra el nombre completo y la nacionalidad de la entidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Nombre + ", " + this.Apellido);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida el DNI de la entidad, teniendo en cuenta la nacionalidad y el número.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la entidad.</param>
        /// <param name="dato">Número de DNI en formato numérico.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            /* Chequeo que se corresponda el tipo de nacionalidad con su rango numérico */
            if ((nacionalidad == ENacionalidad.Argentino && (dato <= 89999999 && dato >= 1)) ||
                (nacionalidad == ENacionalidad.Extranjero && (dato <= 99999999 && dato >= 90000000)))
            {
                return dato;
            }
            else
            {
                /* Arroja la primera excepción si el número no es válido,
                 * arroja la segunda excepción si la nacionalidad no coincide con su rango */
                if (dato > 99999999 || dato < 1)
                {
                    throw new DniInvalidoException();
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        /// <summary>
        /// Valida el DNI de la entidad, teniendo en cuenta la nacionalidad y el número.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la entidad.</param>
        /// <param name="dato">Número de DNI en formato de cadena.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numero;
            /* Verifico que el DNI sea un número */
            if (int.TryParse(dato, out numero))
            {
                return this.ValidarDni(nacionalidad, numero);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// Valida que el Nombre, o el Apellido de la entidad sólo contenga caracteres alfabéticos.
        /// </summary>
        /// <param name="dato">Nombre o Apellido a verificar.</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            bool soloLetras = true;
            /* Recorro toda la cadena y verifico caracter por caracter que sea una letra,
             * si detectara un número o caracter especial se baja la bandera y se termina
             * la verificación, devolviendo en su lugar una cadena vacía.*/
            foreach (char caracter in dato)
            {
                if (char.IsLetter(caracter) == false)
                {
                    soloLetras = false;
                    break;
                }
            }
            if (soloLetras)
            {
                return dato;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
