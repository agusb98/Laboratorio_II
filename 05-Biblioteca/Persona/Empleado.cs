using System;

namespace Biblioteca
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private long dni;

        public Empleado(string nombre, string apellido, long dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public void Mostrar()
        {
            Console.WriteLine("Nombre: {0}", this.nombre);
            Console.WriteLine("Apellido: {0}", this.apellido);
            Console.WriteLine("Dni: {0}", this.dni);
            Console.WriteLine();
        }

    }
}