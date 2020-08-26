using System;
using EntidadFinanciera;
using PrestamosPersonales;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Financiera financiera = new Financiera("Mi Financiera");
            PrestamoDolares pd1 = new PrestamoDolares(1500, new DateTime(2017, 11, 01),
            PeriocidadDePagos.Mensual);
            PrestamoDolares pd2 = new PrestamoDolares(2000, new DateTime(2017, 12, 05),
            PeriocidadDePagos.Bimestral);
            PrestamoDolares pd3 = new PrestamoDolares(2500, new DateTime(2022, 01, 01),
            PeriocidadDePagos.Trimestral);
            PrestamoPesos pp1 = new PrestamoPesos(8000, new DateTime(2022, 01, 01), 20);
            PrestamoPesos pp2 = new PrestamoPesos(7000, new DateTime(2001, 10, 01), 25);
            PrestamoPesos pp3 = new PrestamoPesos(5000, new DateTime(2017, 11, 20), 20);

            financiera = financiera + pd1;
            financiera = financiera + pd2;
            financiera = financiera + pd3;
            financiera = financiera + pd3; //Préstamo repetido
            financiera = financiera + pp1;
            financiera = financiera + pp2;
            financiera = financiera + pp3;
            financiera = financiera + pp3; //Préstamo repetido
            Console.WriteLine((String)financiera);
            pd1.ExtenderPlazo(new DateTime(2017, 12, 01));
            pp1.ExtenderPlazo(new DateTime(2018, 02, 01));
            financiera.OrdenarPrestamos();
            Console.WriteLine("\n ********************ORDENADOS POR FECHA**************************");
            Console.WriteLine(Financiera.Mostrar(financiera));
            Console.ReadKey();

        }
    }
}
