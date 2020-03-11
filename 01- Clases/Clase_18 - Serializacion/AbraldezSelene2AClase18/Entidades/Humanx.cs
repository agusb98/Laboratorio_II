﻿using System;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Alumnx))]
    [XmlInclude(typeof(Profesorx))]
    [XmlInclude(typeof(Humanx))]

    public class Humanx
    {
        #region Atributos
        private int _dni;
        #endregion

        #region Propiedades
        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        #endregion

        #region Metodos
        #region Sobreescritura
        public override string ToString()
        {
            return this.Dni.ToString();
        }
        #endregion
        #endregion

        #region Serializar 
        public static bool SerializarHumanx(Humanx a)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Humanx));
                using (StreamWriter streamWriter = new StreamWriter(@"E:\Segundo cuatri\Prog y Labo II\1-Clases\Clase_18 -\alumno.xml", true))
                {
                    serializer.Serialize(streamWriter, a);
                    retorno = true;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }
        #endregion

        #region Deserializar
        public static Humanx DeserializarHumanx()
        {
            Humanx retorno = new Humanx();
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Humanx));
                using (StreamReader streamreader = new StreamReader(@"E:\Segundo cuatri\Prog y Labo II\1-Clases\Clase_18 -\alumno.xml", true))
                {
                    retorno = (Humanx)deserializer.Deserialize(streamreader);
                }
            }
            catch (Exception)
            {
                retorno = null;
            }
            return retorno;
        }
        #endregion
    }
}
