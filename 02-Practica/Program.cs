using System;
using Biblioteca;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            string pass, name, patent, dni, phone, email, num;
            bool status;
            
            do
            {
                Console.Clear();
                Console.Write("Name : ");
                name = Console.ReadLine();
                status = Validacion.Name(ref name);
            }
            while (!status);

            do
            {
                Console.Clear();
                Console.Write("Contraseña : ");
                pass = Console.ReadLine();
                status = Validacion.Password(pass);
            }
            while (!status);

            do
            {
                Console.Clear();
                Console.Write("Patente : ");
                patent = Console.ReadLine();
                status = Validacion.Patent(ref patent);
            }
            while (!status);

            do
            {
                Console.Clear();
                Console.Write("DNI : ");
                dni = Console.ReadLine();
                status = Validacion.Dni(ref dni);
            }
            while (!status);

            do
            {
                Console.Clear();
                Console.Write("Teléfono : ");
                phone = Console.ReadLine();
                status = Validacion.PhoneNumber(ref phone);
            }
            while (!status);
            
            do
            {
                Console.Clear();
                Console.Write("Email : ");
                email = Console.ReadLine();
                status = Validacion.Email(email);
            }
            while (!status);

            Console.WriteLine("Data : {0} {1} {2} {3} {4} {5}", name, dni, patent, pass, phone, email);

            */
            /*
            Decimal_ dec;
            Binario bin;
            string resString;
            double resDouble;

            dec = 15;
            bin = 000001101;   // 13

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.Value, bin.Value);
            Console.WriteLine("Son iguales? " + (bin == dec));

            resString = bin + dec;
            resDouble = dec + bin;

            Console.WriteLine("Suma decimal: " + resDouble);
            Console.WriteLine("Suma binario: " + resString);

            dec = 18;
            bin = 00010010;

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.Value, bin.Value);
            Console.WriteLine("Son iguales? " + (bin == dec));

            dec = 10;

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.Value, bin.Value);
            Console.WriteLine("Son iguales? " + (bin == dec));

            resString = bin - dec;
            resDouble = dec - bin;

            Console.WriteLine("Suma decimal: " + resDouble);
            Console.WriteLine("Suma binario: " + resString);
            */
            /*
            Decimal_ d1 = new Decimal_(10);
            Binary b1 = new Binary(1010);

            double d2 = (Decimal_)b1;
            double b2 = (Binary)d1;

            Console.WriteLine("a Decimal: {0}", d2);
            Console.WriteLine("a Binario: {0}", b2);

            double d3 = d1 + (Decimal_)b1;
            double b3 = b1 + (Binary)d1;

            Console.WriteLine("a Decimal: {0}", d3);
            Console.WriteLine("a Binario: {0}", b3);

            Console.ReadLine();
            */
            /*

            // Creo un estante
            Estante estante = new Estante(3, 1);
            // Creo 4 productos
            Producto p1 = new Producto("Pepsi", "PESDS97413", (float)18.5);
            Producto p2 = new Producto("Coca-Cola", "COSDS55752", (float)11.5);
            Producto p3 = new Producto("Manaos", "MASDS51292", (float)20.5);
            Producto p4 = new Producto("Crush", "CRSDS54861", (float)10.75);
            // Agrego los productos al estante
            if (estante + p1)
            {
                Console.WriteLine("Agregó {0} {1} {2}", p1.Marca, (string)p1, p1.Precio);
            }
            else
            {
                Console.WriteLine("¡NO agregó {0} {1} {2}!", p1.Marca, (string)p1, p1.Precio);
            }
            if (estante + p1)
            {
                Console.WriteLine("Agregó {0} {1} {2}", p1.Marca, (string)p1, p1.Precio);
            }
            else
            {
                Console.WriteLine("¡NO agregó {0} {1} {2}!", p1.Marca, (string)p1, p1.Precio);
            }
            if (estante + p2)
            {
                Console.WriteLine("Agregó {0} {1} {2}", p2.Marca, (string)p2, p2.Precio);
            }
            else
            {
                Console.WriteLine("¡NO agregó {0} {1} {2}!", p2.Marca, (string)p2, p2.Precio);
            }
            if (estante + p3)
            {
                Console.WriteLine("Agregó {0} {1} {2}", p3.Marca, (string)p3, p3.Precio);
            }
            else
            {
                Console.WriteLine("¡NO agregó {0} {1} {2}!", p3.Marca, (string)p3, p3.Precio);
            }
            if (estante + p4)
            {
                Console.WriteLine("Agregó {0} {1} {2}", p4.Marca, (string)p4, p4.Precio);
            }
            else
            {
                Console.WriteLine("¡NO agregó {0} {1} {2}!", p4.Marca, (string)p4, p4.Precio);
            }
            // Muestro todo el estante
            Console.WriteLine();
            Console.WriteLine("<------------------------------------------------->");
            Console.WriteLine(Estante.MostrarEstante(estante));
            Console.ReadKey();

            */
            /*
            Competencia c1 = new Competencia(15, 3);
            AutoF1 a1 = new AutoF1(1, "Mercedes");
            AutoF1 a2 = new AutoF1(2, "Ferrari");
            AutoF1 a3 = new AutoF1(3, "RedBull");

            if (c1 + a1 && c1 + a2 && c1 + a3)
            {
                Console.WriteLine(c1.Mostrar());
            }

            Console.ReadKey();
            */
            /*
            Negocio negocio = new Negocio("Heladeria");
            Cliente c1 = new Cliente(1, "Alex");
            Cliente c2 = new Cliente(2, "Mariana");
            Cliente c3 = new Cliente(3, "Camilo");
            Cliente c4 = new Cliente(4, "Diego");

            negocio.Cliente = c1;
            negocio.Cliente = c2;
            negocio.Cliente = c3;
            negocio.Cliente = c4;

            while (~negocio)
                Console.WriteLine("Cliente atendido");

            Console.WriteLine("Sin Clientes");


            Console.ReadKey();*/

            Console.WriteLine("Un libro. Le sumo páginas con un indexador y las imprimo.\n");

            Libro libro = new Libro();

            libro[int.MaxValue] = "Pag 1";
            libro[int.MaxValue] = "Pag 2";
            libro[int.MaxValue] = "Pag 3";
            libro[int.MaxValue] = "Pag 4";
            libro[int.MaxValue] = "Pag 5";
            libro[int.MaxValue] = "Pag 6";
            libro[int.MaxValue] = "Pag 7";

            for (int f = 0; f < 10; f++)
            {
                Console.WriteLine(libro[f]);
            }

            libro[4] = "Página modificada";
            libro[-1] = "Página que no debería agregar";

            for (int f = 0; f < 10; f++)
            {
                Console.WriteLine(libro[f]);
            }
        }
    }
}
