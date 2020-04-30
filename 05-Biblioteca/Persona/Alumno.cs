using System.Text;
using System;

namespace Biblioteca
{
    public class Alumno : Persona
    {
        #region Campos

        private byte nota1;
        private byte nota2;
        private double notaFinal;

        #endregion

        #region Constructores

        /// <summary>
        /// Instancia un nuevo Alumno
        /// </summary>
        
        public Alumno() : this(0, 0, new Persona()) { }


        /// <summary>
        /// Instancia un nuevo Alumno
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        
        public Alumno(byte nota1, byte nota2, Persona persona) :
            base(persona)
        {
            this.Nota1 = nota1;
            this.Nota2 = nota2;
            this.NotaFinal = NotaFinal;
        }

        #endregion

        #region Propiedades

        public byte Nota1
        {
            set
            {
                if (value <= 10)
                {
                    this.nota1 = value;
                }
            }
            get
            {
                return this.nota1;
            }
        }

        public byte Nota2
        {
            set
            {
                if (value <= 10)
                {
                    this.nota2 = value;
                }
            }
            get
            {
                return this.nota2;
            }
        }

        public double NotaFinal
        {
            set
            {
                if (this.nota1 > 3 && this.nota2 > 3)
                {
                    this.notaFinal = this.nota1 / this.nota2;
                }

                else
                    this.notaFinal = -1;
            }
            get
            {
                return this.notaFinal;
            }
        }

        #endregion

        #region Metodos

        public string MostrarAlumno()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Nota 1: " + this.Nota1);
                str.AppendLine("Nota 2: " + this.Nota2);
                str.Append(base.Mostrar());

                if (this.NotaFinal != -1)
                {
                    str.AppendLine("Nota Final: " + this.NotaFinal);
                }
                else
                {
                    str.AppendLine("Alumno Desaprobado");
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Alumnos
        /// </summary>
        /// <param name="a"><Alumno/param>
        /// <param name="b"><Alumno/param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Alumno b)
        {
            return ((Persona)a == (Persona)b);
        }

        /// <summary>
        /// Verifica desigualdad entre dos Alumnos
        /// </summary>
        /// <param name="a"><Alumno/param>
        /// <param name="b"><Alumno/param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Alumno b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Verifica igualdad 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Alumno && this == (Alumno)obj;
        }
        #endregion
    }
}

