using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Biblioteca
{
    public class Validacion
    {
        /// <summary>
        /// Valida confirmacion ingresada por teclado
        /// </summary>
        /// <returns></returns>
        public static bool Confirm()
        {
            Console.Write("¿Realizar Operacion? (S/N) : ");
            string confirm = Console.ReadLine();

            if (confirm == "S" || confirm == "s")
                return true;

            return false;
        }

        /// <summary>
        /// Valida si la cadena ingresada contiene un Numero
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsNumber(string str)
        {
            return Regex.Match(str, @"\d").Success;
        }

        /// <summary>
        /// Valida si el char ingresado contiene un Numero
        /// </summary>
        /// <param name="chr">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsNumber(char chr)
        {
            return ContainsNumber(chr.ToString());
        }

        /// <summary>
        /// Valida si la cadena ingresada contiene un Numero
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsSpecialCharacter(string str)
        {
            return Regex.Match(str, @"[|¬°!#$%&@/()=¡¿'?¨´+*~}{^\-/[\]_<>]").Success;
        }
        /// <summary>
        /// Valida que el char ingresado por parámetro sea un caracter especial.
        /// </summary>
        /// <param name="chr">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsSpecialCharacter(char chr)
        {
            return ContainsSpecialCharacter(chr.ToString());
        }

        /// <summary>
        /// Valida si la cadena ingresada contiene una Letra
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsLetter(string str)
        {
            return Regex.IsMatch(str, "^[a-zA-Z]*$");
        }

        /// <summary>
        /// Valida que el char ingresado por parámetro sea un caracterer de letras.
        /// </summary>
        /// <param name="chr">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool ContainsLetter(char chr)
        {
            return ContainsLetter(chr.ToString());
        }

        /// <summary>
        /// Valida que la cadena ingresada contenga sólo numeros y letra
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool IsAlphanumeric(string str)
        {
            return (ContainsLetter(str) && ContainsNumber(str) && !ContainsSpecialCharacter(str));
        }

        /// <summary>
        /// Valida que la contraseña creada sea correcta
        /// </summary>
        /// <param name="strNumero">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Password(string pass)
        {
            Match matchNumeros = Regex.Match(pass, @"\d");
            Match matchEspeciales = Regex.Match(pass, @"[|¬°!#$%&@/()=¡¿'?¨´+*~}{^\-/[\]_<>]");
            Match matchMinusculas = Regex.Match(pass, @"[a-z]");
            Match matchMayusculas = Regex.Match(pass, @"[A-Z]");
            Match matchAdmin = Regex.Match(pass, @"[admin,Admin,adm,Adm]");
            Match matchContraseña = Regex.Match(pass, @"[contraseña,pass,password,contra]");
            // MATCH con el valor de nombreUsuario
            // MATCH con el valor de la identificacion del usuario
            // Ahora creamos un Array de palabras prohibidas  :)
            string[] palabrasProhibidas = { "000", "123", "12345", "56789", "123456789", "321", "54321", "987654321", "56789", "qwerty", "asdf", "zxcv", "poiuy", "lkjhg", " mnbv" };

            bool status = true;

            if (pass.Length < 8 || pass.Length > 20)
            {
                Console.WriteLine("Ups! Tu contraseña debe de tener una longitud entre 8-15 caracteres");
                status = false;
            }

            else if (!matchNumeros.Success)
            {
                Console.WriteLine("Ups! Tu contraseña debe  contener mínimo un número");
                status = false;
            }

            else if (!matchEspeciales.Success)
            {
                Console.WriteLine("Ups! Tu contraseña debe contener mínimo un caracter especial");
                status = false;
            }

            else if (!matchMinusculas.Success)
            {
                Console.WriteLine("Ups! Tu contraseña debe contener mínimo una minúscula");
                status = false;
            }

            else if (!matchMayusculas.Success)
            {
                Console.WriteLine("Ups! Tu contraseña debe contener mínimo una mayúscula");
                status = false;
            }

            else if (!matchAdmin.Success)
            {
                Console.WriteLine("Ups! Tu contraseña no debe contener 'admin' o referencias");
                status = false;
            }

            else if (!matchContraseña.Success)
            {
                Console.WriteLine("Ups! Tu contraseña no debe contener 'contraseña' o referencias");
                status = false;
            }

            for (int i = 0; i < palabrasProhibidas.Length; i++)
            {
                Match Match = Regex.Match(pass, palabrasProhibidas[i]);
                if (Match.Success)
                {
                    Console.WriteLine("Ups! Tu contraseña No debe  contener la secuencia numerica {0}", Match);
                    status = false;
                }
            }
            if (status)
                Console.WriteLine("La contraseña cumple con las normas de seguridad");

            Console.ReadLine();
            return status;
        }

        /// <summary>
        /// Valida que la cadena ingresada cumpla los estándares de un nombre
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Surname(ref string str)
        {
            return Name(ref str);
        }
        /// <summary>
        /// Valida que la cadena ingresada cumpla los estándares de un nombre
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Name(ref string str)
        {
            bool flag;
            if (ContainsNumber(str) || ContainsSpecialCharacter(str) || str.Length == 0)
            {
                Console.WriteLine("Ups! Solo debe tener letras");
                flag = false;
            }
            else
            {
                Console.WriteLine("Dato Ingresado con Éxito");
                str = str.ToUpperInvariant();
                flag = true;
            }

            Console.ReadLine();
            return flag;
        }

        /// <summary>
        /// Valida que la cadena ingresada cumpla los estándares de una marca
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Marca(ref string str)
        {
            bool flag = false;
            if (!ContainsSpecialCharacter(str))
            {
                Console.WriteLine("Dato Ingresado con Éxito");
                str = str.ToUpperInvariant();
                flag = true;
            }

            Console.ReadLine();
            return flag;
        }

        /// <summary>
        /// Valida que la cadena ingresada cumpla ser patente
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Patent(ref string str)
        {
            bool flag = false;

            if (ValidPatent(ref str))
            {
                Console.WriteLine("Dato Ingresado con Éxito");
                flag = true;
            }

            else
                Console.WriteLine("La patente ingresada no cumple con las normas");

            Console.ReadLine();
            return flag;
        }

        /// <summary>
        /// Valida que la cadena ingresada cumpla ser patente Argentina
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        private static bool ValidPatent(ref string str)
        {
            str = str.ToUpperInvariant();
            str = str.Replace(" ", "");

            //Para las patentes antiguas aún vigentes

            if (str.Length == 6)
            {
                //
            }

            //Para las patentes nuevas

            else if (str.Length == 7)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (ContainsLetter(str[i]))
                        return false;
                }

                for (int i = 5; i < str.Length; i++)
                {
                    if (ContainsLetter(str[i]))
                        return false;
                }

                for (int i = 2; i < 5; i++)
                {
                    if (!ContainsNumber(str[i]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Valida que el numero ingresado sea correcto
        /// </summary>
        /// <param name="num">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Dni(ref long num)
        {
            string str = num.ToString();

            if (!Validacion.Dni(ref str))
                return false;

            long.TryParse(str, out num);
            return true;
        }
        /// <summary>
        /// Valida que el dni creada sea correcto
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Dni(ref string str)
        {
            str = str.Replace(" ", "");

            bool flag = true;

            if (ContainsSpecialCharacter(str) || ContainsLetter(str))
            {
                Console.WriteLine("Ups! Tu dni solo debe estar compuesto por numeros");
                flag = false;
            }
            else if (ContainsNumber(str) && str.Length != 8)
            {
                Console.WriteLine("Ups! Tu dni solo puede tener 8 digitos");
                flag = false;
            }

            else if (flag)
                Console.WriteLine("Dato Ingresado con Éxito");

            Console.ReadLine();
            return flag;
        }
        /// <summary>
        /// Valida que el numero ingresado sea correcto
        /// </summary>
        /// <param name="num">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool PhoneNumber(ref double num)
        {
            string str = num.ToString();

            if (Validacion.PhoneNumber(ref str))
                return true;

            double.TryParse(str, out num);
            return false;
        }

        /// <summary>
        /// Valida que el numero ingresado sea correcto
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool PhoneNumber(ref string str)
        {
            str = str.Replace(" ", "");

            bool flag = true;

            if (ContainsSpecialCharacter(str) || ContainsLetter(str))
            {
                Console.WriteLine("Ups! El ingreso debe estar compuesto por numeros");
                flag = false;
            }
            else if (str.Length < 7 || str.Length > 10)
            {
                Console.WriteLine("Ups! El ingreso debe tener entre 7 y 10 digitos");
                flag = false;
            }

            else if (flag)
                Console.WriteLine("Dato Ingresado con Éxito");

            Console.ReadLine();
            return flag;
        }

        /// <summary>
        /// Valida que el email ingresado sea correcto
        /// </summary>
        /// <param name="str">Cadena a ser validada.</param>
        /// <returns></returns>
        public static bool Email(string str)
        {
            bool flag = false;
            var addr = new System.Net.Mail.MailAddress(str);

            if (addr.Address == str)
            {
                Console.WriteLine("Dato Ingresado con Éxito");
                flag = true;
            }

            else if (!flag)
                Console.WriteLine("Ups! El mail ingresado no puede ser usado");

            Console.ReadLine();
            return flag;
        }

        /// <summary>
        /// Verifica si el numero es primo
        /// </summary>
        /// <param name="numero">El número en formato cadena se transforma a dato numérico.</param>
        /// <returns></returns>
        public static bool NumeroPrimo(string numero)
        {
            if (double.TryParse(numero, out double aux) == true)
            {
                for (int i = 2; i < aux; i++)
                {
                    if (aux % i == 0)
                        return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica si el numero es primo
        /// </summary>
        /// <param name="num">
        /// <returns></returns>
        public static bool NumeroPrimo(double numero)
        {
            string str = numero.ToString();
            return (Validacion.NumeroPrimo(str));
        }

        /// <summary>
        /// Verifica si el numero es binario
        /// </summary>
        /// <param name="numero">El número en formato cadena se transforma a dato numérico.</param>
        /// <returns></returns>

        public static bool IsBinary(string str)
        {
            str = str.Replace('.', ',');
            if (System.Text.RegularExpressions.Regex.IsMatch(str, "[0-1]"))
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si el numero es binario
        /// </summary>
        /// <param name="numero">El número en formato cadena se transforma a dato numérico.</param>
        /// <returns></returns>
        public static bool IsBinary(double num)
        {
            return (Validacion.IsBinary(num.ToString()));
        }

        /// <summary>
        /// Verifica si el string solo posee numeros
        /// </summary>
        /// <param name="numero">El número en formato cadena se transforma a dato numérico.</param>
        /// <returns></returns>
        public static bool OnlyNumbers(string str)
        {
            if (!Validacion.ContainsLetter(str) && !Validacion.ContainsSpecialCharacter(str))
                return true;

            return false;
        }
    }

}