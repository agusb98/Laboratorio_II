using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        #region Campos

        int espacioDisponible;
        List<Vehiculo> vehiculos;

        #endregion

        #region Métodos

        /// <summary>
        /// Constructor por defecto, inicializa la lista de vehiculos.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor parametrizado, inicializa la lista de vehiculos asignándole un espacio disponible al objeto.
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible del Estacionakiento</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles \n", c.vehiculos.Count, c.espacioDisponible);

            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if (!c.vehiculos.Contains(p) && c.vehiculos.Count < c.espacioDisponible)
            {
                c.vehiculos.Add(p);
            }

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(v);
                    break;
                }
            }

            return c;
        }

        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Tipos de Vehiculos disponibles para Estacionamiento
        /// </summary>
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #endregion
    }
}
