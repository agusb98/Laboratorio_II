using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace FutbolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico a = new DirectorTecnico("Esteban", "Rey");
            Equipo miBiblioteca = new Equipo("Salchipapa", a, Deportes.Basquet);
            Jugador b = new Jugador("Joe", "Mayo", 4, true);
            Jugador b1 = new Jugador("Carlos", "Feo", 5, false);
            Jugador b2 = new Jugador("Carlos", "Feo", 5, false);
            Jugador b3 = new Jugador("Pepe", "Maso", 2, false);
            Jugador b4 = new Jugador("Juan", "Hola", 10, false);
            Jugador b5 = new Jugador("Jose", "Tardio", 14, false);

            miBiblioteca += b;
            miBiblioteca += b1;
            miBiblioteca += b3;
            miBiblioteca += b4;
            miBiblioteca += b5;
            //YA INGRESADO
            miBiblioteca += b2;

            Console.WriteLine();
            //TRUE
            Console.WriteLine(b1.Equals(b2));
            //FALSE
            Console.WriteLine(b.Equals("Joe Mayo"));
            //FALSE
            Console.WriteLine(b.Equals(b1));

            Console.WriteLine(miBiblioteca);
            Console.ReadLine();
        }
    }
}
