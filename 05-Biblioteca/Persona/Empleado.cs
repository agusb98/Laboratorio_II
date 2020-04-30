using System.Text;
using System;

namespace Biblioteca
{
    public class Empleado : Persona
    {
        #region Fields

        private int id;
        private double horasTrabajadas;
        private double salario;


        #endregion

        #region Constructores

        /// <summary>
        /// Instancia un nuevo Empleado
        /// </summary>

        public Empleado() : this(0, 0, 0, new Persona()) { }


        /// <summary>
        /// Instancia un nuevo Empleado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="horasTrabajadas"></param>
        /// <param name="salario"></param>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>

        public Empleado(int id, double horasTrabajadas, double salario, Persona persona) :
            base(persona)
        {
            this.Id = id;
            this.HorasTrabajadas = horasTrabajadas;
            this.Salario = salario;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Setea / Obtiene Id de Empleado
        /// </summary>

        public int Id
        {
            set
            {
                if (value >= 0)
                {
                    this.id = value;
                }
            }
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Setea / Obtiene Horas Trabajadas de Empleado
        /// </summary>

        public double HorasTrabajadas
        {
            set
            {
                if (value >= 0)
                {
                    this.horasTrabajadas = value;
                }
            }
            get
            {
                return this.horasTrabajadas;
            }
        }

        /// <summary>
        /// Setea / Obtiene salario de Empleado
        /// </summary>

        public double Salario
        {
            set
            {
                if (value >= 0)
                {
                    this.salario = value;
                }
            }
            get
            {
                return this.salario;
            }
        }

        #endregion

        #region Methods

        public string MostrarEmpleado()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Id: " + this.Id);
                str.AppendLine("Horas Trabajadas: " + this.HorasTrabajadas);
                str.AppendLine("Salario: " + this.Salario);
                str.AppendLine(base.Mostrar());
            }

            return str.ToString();
        }

        /// <summary>
        /// Verifica igualdad entre dos Empleados
        /// </summary>
        /// <param name="a"><Empleado/param>
        /// <param name="b"><Empleado/param>
        /// <returns></returns>
        public static bool operator ==(Empleado a, Empleado b)
        {
            return ((Persona)a == (Persona)b);
        }

        /// <summary>
        /// Verifica desigualdad entre dos Empleados
        /// </summary>
        /// <param name="a"><Empleado/param>
        /// <param name="b"><Empleado/param>
        /// <returns></returns>
        public static bool operator !=(Empleado a, Empleado b)
        {
            return !(a == b);
        }
        #endregion
    }
}