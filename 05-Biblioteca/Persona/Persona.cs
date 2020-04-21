using System;

namespace Biblioteca
{
    public class Persona
    {
        #region Fields

        private double dni;
        private string apellido;
        private string nombre;

        #endregion

        #region Methods

        public Persona(double dni)
            : this(dni, string.Empty, string.Empty)
        {
        }

        public Persona(double dni, string apellido, string nombre)
            : this(apellido, nombre)
        {
            this.dni = dni;
        }

        public Persona(string apellido, string nombre)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public double Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (!double.IsNaN(value))
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

        public void Mostrar()
        {
            Console.WriteLine("Nombre: {0}", this.nombre);
            Console.WriteLine("Apellido: {0}", this.apellido);
            Console.WriteLine("Dni: {0}", this.dni);
            Console.WriteLine();
        }

        #endregion
    }
}