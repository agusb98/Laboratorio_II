using System;
using System.Text;

namespace Biblioteca
{
    public class Persona
    {
        #region Fields

        protected long dni;
        protected string apellido;
        protected string nombre;
        protected DateTime fechaNacimiento;

        #endregion

        #region Constructores

        /// <summary>
        /// Instancia Persona con atributos vacios
        /// </summary>
        public Persona() :
            this(0, "DESCONOCIDO", "DESCONOCIDO", new DateTime())
        {
        }

        /// <summary>
        /// Instancia Persona con atributo pasado por parametro
        /// </summary>
        /// <param name="persona"></param>
        public Persona(Persona persona) :
            this(persona.Dni, persona.Apellido, persona.Nombre, persona.fechaNacimiento)
        { }

        /// <summary>
        /// Instancia Persona con atributos pasados por parametro
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="apellido"></param>
        /// <param name="nombre"></param>
        /// <param name="fechaNacimiento"></param>
        public Persona(long dni, string apellido, string nombre, DateTime fechaNacimiento)
        {
            this.Dni = dni;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.FechaNacimiento = fechaNacimiento;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene/Modifica DNI de Persona
        /// </summary>
        public long Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (Validacion.Dni(ref value))
                {
                    this.dni = value;
                }
            }
        }

        /// <summary>
        /// Obtiene/Modifica Nombre de Persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (Validacion.Name(ref value))
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Obtiene/Modifica Apellido de Persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (Validacion.Surname(ref value))
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Devuelve/Modifica fecha de nacimiento de Persona
        /// </summary>
        public DateTime FechaNacimiento
        {
            get
            {
                return this.fechaNacimiento;
            }
            set
            {
                this.fechaNacimiento = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Muestra por pantalla datos de Persona
        /// </summary>
        /// <returns></returns> string con datos de Persona
        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Dni: " + this.Dni);
                str.AppendLine("Apellido: " + this.Apellido);
                str.AppendLine("Nombre: " + this.Nombre);
                str.AppendLine("Fecha de Nacimiento: " + this.FechaNacimiento);
            }

            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Personas
        /// </summary>
        /// <param name="a1"><Persona/param>
        /// <param name="a2"><Persona/param>
        /// <returns></returns>

        public static bool operator ==(Persona a1, Persona a2)
        {
            return a1.Dni == a2.Dni;
        }

        /// <summary>
        /// Verifica desigualdad entre dos Personas
        /// </summary>
        /// <param name="a1"><Persona/param>
        /// <param name="a2"><Persona/param>
        /// <returns></returns>

        public static bool operator !=(Persona a1, Persona a2)
        {
            return !(a1 == a2);
        }
        #endregion
    }
}