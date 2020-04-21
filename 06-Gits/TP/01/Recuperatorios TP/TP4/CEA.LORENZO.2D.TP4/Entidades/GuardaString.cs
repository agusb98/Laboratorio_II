using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// (Extension) Permite guardar texto a un archivo que se genera en el Escritorio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter writer;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            writer = new StreamWriter(path + "\\" + archivo, true, Encoding.UTF8);

            try
            {
                writer.WriteLine(texto);
                return true;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
