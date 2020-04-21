using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificarListaInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void VerificarSumaIdIguales()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Avellaneda", "1111");
            Paquete p2 = new Paquete("Bernal", "1111");

            correo += p1;
            Assert.IsTrue(correo.Paquetes.Contains(p1));
            correo += p2;
        }
    }
}
