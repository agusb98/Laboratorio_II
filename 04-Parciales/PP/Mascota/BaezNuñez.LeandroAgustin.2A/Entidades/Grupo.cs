using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo

    {
        #region Atributos

        private List<Mascota> manada;
        private string nombre;
        private static ETipoManada tipo;

        #endregion

        #region Metodos

        public static ETipoManada Tipo { set { tipo = value; } }

        static Grupo() { Tipo = ETipoManada.Unica; }

        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Grupo(string nombre, ETipoManada tipo) : this(nombre)
        {
            Tipo = tipo;
        }

        public static implicit operator string(Grupo g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Grupo: {0} - Tipo {1}\n", g.nombre, Grupo.tipo);
            sb.AppendFormat("Integrantes: ({0})\n", g.manada.Count);
            sb.AppendFormat("\n*********************************************\n\n");

            foreach (Mascota mascota in g.manada)
            {
                sb.AppendFormat(mascota.ToString());
                sb.AppendFormat("\n");
            }
            return sb.ToString();
        }

        public static bool operator ==(Grupo g, Mascota m)
        {
            foreach (Mascota mascota in g.manada)
            {
                if (m == mascota)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }

        public static Grupo operator +(Grupo g, Mascota m)
        {
            if (g == m)
            {
                Console.WriteLine("{0} Ya se encuentra en el grupo!!!", m);
            }
            else
            {
                g.manada.Add(m);
            }
            return g;
        }

        public static Grupo operator -(Grupo g, Mascota m)
        {
            if (g == m)
            {
                g.manada.Remove(m);
            }
            else
            {
                Console.WriteLine("{0} No se encuentra en el grupo!!!", m);
            }
            return g;
        }

        #endregion
    }
}
