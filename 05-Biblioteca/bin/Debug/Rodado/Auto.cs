using System;

namespace Biblioteca
{
    public class Auto
    {
        int id;
        string marca;
        string modelo;
        int cilindrada;
        double potencia;
        double precio;
        bool status;

        public void Add()
        {
            status = true;
        }

        public void Delete()
        {
            status = false;
        }
        public int GetId()
        {
            if (double.TryParse((this.id).ToString(), out _))
                return this.id;
            else
                return 0;
        }

        public bool SetId(int id)
        {
            if (id >= 0)
            {
                this.id = id;
                return true;
            }

            return false;
        }

        public bool SetId(string id)
        {
            if (int.TryParse(id.ToString(), out int num))
                return SetId(num);

            return false;
        }

        public string GetMarca()
        {
            if (Validacion.Name(ref this.marca))
                return this.marca;
            else
                return "";
        }

        public bool SetMarca(string marca)
        {
            if (Validacion.Name(ref marca))
            {
                this.marca = marca;
                return true;
            }

            return false;
        }
        public string GetModelo()
        {
            if (!Validacion.ContainsSpecialCharacter(this.modelo))
                return this.modelo;
            else
                return "";
        }

        public bool SetModelo(string modelo)
        {
            if (!Validacion.ContainsSpecialCharacter(modelo))
            {
                this.modelo = modelo;
                return true;
            }

            return false;
        }

        public int GetCilindrada()
        {
            if (int.TryParse((this.cilindrada).ToString(), out _))
                return this.cilindrada;
            else
                return 0;
        }

        public bool SetCilindrada(int cilindrada)
        {
            if (id >= 1)
            {
                this.cilindrada = cilindrada;
                return true;
            }

            return false;
        }

        public double GetPotencia()
        {
            if (double.TryParse((this.potencia).ToString(), out _))
                return this.potencia;
            else
                return 0;
        }

        public bool SetPotencia(int potencia)
        {
            if (potencia >= 1)
            {
                this.potencia = potencia;
                return true;
            }

            return false;
        }

        public double GetPrecio()
        {
            if (double.TryParse((this.precio).ToString(), out _))
                return this.precio;
            else
                return 0;
        }

        public bool SetPrecio(int precio)
        {
            if (precio >= 1)
            {
                this.precio = precio;
                return true;
            }

            return false;
        }

        public void MostrarEstado()
        {
            Console.WriteLine("ID: {0}", this.id);
            Console.WriteLine("Marca: {0}", this.marca);
            Console.WriteLine("Modelo: {0}", this.modelo);
            Console.WriteLine("Cilindrada: {0}", this.cilindrada);
            Console.WriteLine("Potencia: {0}", this.potencia);
            Console.WriteLine("Precio: ${0}", this.precio);
            Console.WriteLine("Estado: {0}", this.status);
        }

    } // Final de la clase Persona   
}

