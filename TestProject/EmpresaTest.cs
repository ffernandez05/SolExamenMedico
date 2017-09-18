using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;

namespace TestProject
{
    [TestClass]
    public class EmpresaTest
    {
        [TestMethod]
        public void Test_CrearEmpresa()
        {
            ServiceEmpresa.ServiceEmpresaClient proxy = new ServiceEmpresa.ServiceEmpresaClient();
            ServiceEmpresa.Empresa EmpresaCreado = proxy.Registro(new ServiceEmpresa.Empresa
            {
                Nombre = "inkafarma",
                Direccion = "Av Canada 12",
                Telefono = "987456325",
                RUC = "11145263987",
                Estado = "0"
            });
            Assert.AreEqual("inkafarma", EmpresaCreado.Nombre);
            Assert.AreEqual("Av Canada 12", EmpresaCreado.Direccion);
            Assert.AreEqual("987456325", EmpresaCreado.Telefono);
            Assert.AreEqual("11145263987", EmpresaCreado.RUC);
            Assert.AreEqual("0", EmpresaCreado.Estado);
        }

        [TestMethod]
        public void Test_ModificarEmpresa()
        {
            ServiceEmpresa.ServiceEmpresaClient proxy = new ServiceEmpresa.ServiceEmpresaClient();
            ServiceEmpresa.Empresa EmpresaCreado = proxy.Modificar(new ServiceEmpresa.Empresa
            {
                Nombre = "inkafarma",
                Direccion = "Av Canada 1548",
                Telefono = "987456325",
                RUC = "11145263987",
                Estado = "0"
            });
            Assert.AreEqual("inkafarma", EmpresaCreado.Nombre);
            Assert.AreEqual("Av Canada 1548", EmpresaCreado.Direccion);
            Assert.AreEqual("987456325", EmpresaCreado.Telefono);
            Assert.AreEqual("11145263987", EmpresaCreado.RUC);
            Assert.AreEqual("0", EmpresaCreado.Estado);
        }

        [TestMethod]
        public void Test_EliminarEmpresa()
        {
            try
            {
                string codigo = "";
                string descripcion = "";
                ServiceEmpresa.ServiceEmpresaClient proxy = new ServiceEmpresa.ServiceEmpresaClient();
                proxy.Eliminar("inkafarma",ref codigo,ref descripcion);
            }
            catch (FaultException<ServiceAtencion.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar eliminar la empresa", error.Reason);
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "No se puede eliminar la Atencion se encuentra Inactiva");
            }

        }

        [TestMethod]
        public void Test_ListarEmpresa()
        {
            List<ServiceEmpresa.Empresa> Listado = new List<ServiceEmpresa.Empresa>();
            ServiceEmpresa.ServiceEmpresaClient proxy = new ServiceEmpresa.ServiceEmpresaClient();
            Listado.AddRange(proxy.Listar());
            Assert.AreEqual(2, Listado.Count);
        }





    }
}
