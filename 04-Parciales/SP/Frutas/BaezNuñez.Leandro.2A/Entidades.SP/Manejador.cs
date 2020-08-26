using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades.SP
{
    public class Manejador
    {
        public void manejadorTexto(double precio)
        {
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\archivo de evento.txt", false);

                streamWriter.WriteLine(DateTime.Now.ToString());
                streamWriter.Write("Precio: " + precio);
            }
            catch { }
            finally
            {
                streamWriter.Close();
            }
        }
    }
}
