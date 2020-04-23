using System;

namespace Biblioteca
{
    public class Empleado : Persona
    {
        private int id;
        private string direccion;
        private int horasTrabajadas;

        #region Propiedades

        public Empleado() :
            this(0, string.Empty, 0)
        {
        }

        public Empleado(int id, string direccion, int horasTrabajadas)
        {
            this.id = id;
            this.direccion = direccion;
            this.horasTrabajadas = horasTrabajadas;
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value >= 0)
                {
                    this.id = value;
                }
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

        public int HorasTrabajadas
        {
            get
            {
                return this.horasTrabajadas;
            }
            set
            {
                if (value >= 0)
                {
                    this.horasTrabajadas = value;
                }
            }
        }

        #endregion
    }
}