using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Banco
    {
        #region Atributos

        private string nombre;

        #endregion

        #region Propiedades

        /// <summary>
        /// OnlyRead: Retorna el nombre de la clase Abstracta Banco
        /// </summary>
        public string Nombre { get { return nombre; } }

        #endregion

        #region Metodos

        public Banco(string nombre) { this.nombre = nombre; }

        public abstract string Mostrar();

        public abstract string Mostrar(Banco banco);

        public override bool Equals(object obj)
        {
            return (Banco)obj == this;
        }

        #endregion
    }
}
