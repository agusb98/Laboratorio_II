using System;
using System.Text;

namespace Biblioteca
{
    public class Persona
    {
        #region Fields

        private long dni;
        private string apellido;
        private string nombre;

        #endregion

        #region Methods

        public Persona():
            this (0, string.Empty, string.Empty)
        {
        }

        public Persona(long dni, string apellido, string nombre)
        {
            this.dni = dni;
            this.apellido = apellido;
            this.nombre = nombre;
        }

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

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Nombre: " + this.Nombre);
            str.AppendLine("Apellido: " + this.Apellido);
            str.AppendLine("Dni: " + this.Dni);

            return str.ToString();
        }

        #endregion
    }
}