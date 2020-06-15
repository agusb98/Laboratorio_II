using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Campos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de Escritura y Lectura para el Nombre de Persona
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (ValidarNombreApellido(value) != string.Empty)
                    this.nombre = value;
            }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para el DNI de Persona
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(Nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para la Nacionalidad de Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para el Apellido de Persona
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (ValidarNombreApellido(value) != string.Empty)
                    this.apellido = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura para la DNI de Persona en cadena de caracteres
        /// </summary>
        public string StringToDNI
        {
            set
            {
                DNI = ValidarDni(Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) :
            this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):
            this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve en formato de texto los datos de la persona.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", Nombre, Apellido);
                sb.AppendFormat("NACIONALIDAD: {0}\n", Nacionalidad);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida el DNI de acuerdo a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI si es válido.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    {
                        if (dato > 0 && dato <= 89999999)
                            return dato;
                        else
                            throw new NacionalidadInvalidaException();
                    }
                case ENacionalidad.Extranjero:
                    {
                        if (dato > 90000000 && dato <= 99999999)
                            return dato;
                        else
                            throw new NacionalidadInvalidaException();
                    }
                default:
                    {
                        throw new NacionalidadInvalidaException();
                    }
            }
        }

        /// <summary>
        /// Valida el DNI de acuerdo a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI si es válido.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato.Trim();
            dato.Replace(".", "");

            if (dato.Length <= 6 || dato.Length > 8 || Regex.Matches(dato, @"[a-zA-Z]").Count > 0)
                throw new DniInvalidoException();
            else
                return ValidarDni(nacionalidad, Convert.ToInt32(dato));
        }

        /// <summary>
        /// Verifica que un nombre o apellido contenga caracteres válidos.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar.</param>
        /// <returns>El dato ingresado si es válido o una cadena vacía si no lo es.</returns>
        private string ValidarNombreApellido(string dato)
        {
            dato.Trim();
            if (dato.All(Char.IsLetter))
            {
                Char.ToUpper(dato[0]);
                for (short f = 0; f < dato.Length; f++)
                {
                    if (dato[f] == ' ')
                    {
                        Char.ToUpper(dato[f + 1]);
                    }
                }
                return dato;
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Valores de nacionalidad utilizados en la clase Persona
        /// </summary>
        public enum ENacionalidad { Argentino, Extranjero }

        #endregion
    }
}
