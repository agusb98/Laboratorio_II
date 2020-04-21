using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Biblioteca
{
    public class Alumno
    {
        #region Campos

        byte nota1;
        byte nota2;
        double notaFinal;
        //int id;
        //bool status;
        //string name;
        //string surname;

        #endregion

        #region Métodos

        public void Add()
        {
            //this.person.status = true;
        }

        public void Delete()
        {
            //this.person.status = false;
        }
        public byte FirstExam
        {
            get
            {
                if (nota1 >= 0)
                    return this.nota1;

                else
                    return 0;
            }
            set
            {
                if (value >= 0)
                    this.nota1 = value;
            }
        }

        public byte SecondExam
        {
            get
            {
                if (nota2 >= 0)
                    return this.nota2;

                else
                    return 0;
            }
            set
            {
                if (value >= 0)
                    this.nota2 = value;
            }
        }

        public void CalcularFinal()
        {
            if (this.nota1 > 3 && this.nota2 > 3)
            {
                this.notaFinal = this.nota1 / this.nota2;
            }

            else
                this.notaFinal = -1;
        }

        public void Mostrar()
        {
            Console.WriteLine("Nota 1: {0}", this.nota1);
            Console.WriteLine("Nota 2: {0}", this.nota2);/*
            Console.WriteLine("Nombre: {0}", this.person.name);
            Console.WriteLine("Apellido: {0}", this.person.surname);
            Console.WriteLine("Legajo: {0}", this.person.id);*/

            if (this.notaFinal != -1)
                Console.WriteLine("Nota Final: {0}", this.notaFinal);

            else
                Console.WriteLine("Alumno Desaprobado");
        }

        #endregion
    }
}

