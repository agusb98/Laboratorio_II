using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libro
    {
        #region Fields

        private List<string> paginas = new List<string>();

        #endregion

        #region Properties

        public string this[int index]
        {
            get
            {
                if (index < this.paginas.Count && index >= 0)
                {
                    return this.paginas[index];
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                if (index < this.paginas.Count && index >= 0)
                {
                    this.paginas[index] = value;
                }
                else if (index > this.paginas.Count)
                {
                    this.paginas.Add(value);
                }
            }
        }

        #endregion
    }
}