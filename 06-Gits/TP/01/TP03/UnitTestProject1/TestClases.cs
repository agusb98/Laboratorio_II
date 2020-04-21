using System;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace UnitTestProject1
{
    [TestClass]
    public class TestClases
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarDNIArgentino()
        {
            Alumno a1 = new Alumno(1, "Juan", "Pérez", "90000000",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarDNIExtranjero()
        {
            Alumno a1 = new Alumno(1, "Juan", "Méndez", "89999999",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarRangoDNI()
        {
            Alumno a1 = new Alumno(1, "Dante", "López", "0",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarCaracteresDNI()
        {
            Alumno a1 = new Alumno(1, "Dante", "López", "111a111",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        public void ValidarDatosNulos()
        {
            Universidad uni = Universidad.Leer();

            foreach (Alumno alumno in uni.Alumnos)
            {
                Assert.IsNotNull(alumno.Apellido);
                Assert.IsNotNull(alumno.Nombre);
                Assert.IsNotNull(alumno.Nacionalidad);
                Assert.IsNotNull(alumno.DNI);
            }
        }
    }
}
