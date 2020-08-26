using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Entidades.SP
{
    public class Ticketeadora
    {
        public static bool ImprimirTicket(double precio)
        {
            StreamWriter streamWriter = null;
            bool retorno = false;

            try
            {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", false);

                streamWriter.WriteLine(DateTime.Now.ToString());
                streamWriter.Write("Precio: " + precio);

                retorno = true;
            }
            catch { }
            finally
            {
                streamWriter.Close();
            }
            return retorno;
        }
    }
}
