using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;

namespace TestProject
{
    [TestClass]
    public class AtencionTest
    {
        [TestMethod]
        public void Test_CrearAtencion()
        {
            ServiceAtencion.ServiceAtencionClient proxy = new ServiceAtencion.ServiceAtencionClient();
            ServiceAtencion.Atencion AtencionCreado = proxy.Registro(new ServiceAtencion.Atencion
            {
                Dni = "44880022",
                Fecha = "09/09/2017",
                Estado = "1"
            });
            Assert.AreEqual("44880022", AtencionCreado.Dni);
            Assert.AreEqual("09/09/2017", AtencionCreado.Fecha);
            Assert.AreEqual("1", AtencionCreado.Estado);
        }

        [TestMethod]
        public void Test_ModificarAtencion()
        {
            ServiceAtencion.ServiceAtencionClient proxy = new ServiceAtencion.ServiceAtencionClient();
            ServiceAtencion.Atencion AtencionEditado = proxy.Modificar(new ServiceAtencion.Atencion
            {
                Dni = "44880022",
                Fecha = "20/09/2017",
                Estado = "1"
            });
            Assert.AreEqual("44880022", AtencionEditado.Dni.Trim());
            Assert.AreEqual("20/09/2017", AtencionEditado.Fecha.Trim());
            Assert.AreEqual("1", AtencionEditado.Estado.Trim());


        }

        [TestMethod]
        public void Test_EliminarAtencion()
        {
            try
            {
                ServiceAtencion.ServiceAtencionClient proxy = new ServiceAtencion.ServiceAtencionClient();
                string dni = "44880022";
                string codigo = "";
                string descripcion = "";
                proxy.Eliminar(dni, ref codigo, ref descripcion);
                Assert.AreEqual("44880022", dni);
            }
            catch (FaultException<ServiceAtencion.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar eliminar la empresa", error.Reason);
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "No se puede eliminar la Atencion se encuentra Inactiva");
            }

        }

        [TestMethod]
        public void Test_ListarAtencion()
        {
            List<ServiceAtencion.Atencion> AtencionsEncontrados = new List<ServiceAtencion.Atencion>();
            ServiceAtencion.ServiceAtencionClient proxy = new ServiceAtencion.ServiceAtencionClient();
            AtencionsEncontrados.AddRange(proxy.Listar());
            Assert.AreEqual(1, AtencionsEncontrados.Count);

        }


    }

}
