using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Persistencia;
using WcfServices.Errores;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceEmpresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceEmpresa.svc or ServiceEmpresa.svc.cs at the Solution Explorer and start debugging.
    public class ServiceEmpresa : IServiceEmpresa
    {
        #region Miembros de IComprobante

        private EmpresaData empresaDAO = new EmpresaData();

        public Empresa Registro(Empresa empresaObjeto)
        {
            try
            {
                if (empresaDAO.Obtener(empresaObjeto.Nombre) != null)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Empresa ya existe"
                    }, new FaultReason("Error al intentar la Creacion"));
                }
                empresaDAO.Crear(empresaObjeto);
            }
            catch (FaultException<RepetidoException> error)
            {
                empresaObjeto.Codigo = error.Detail.Codigo;
                empresaObjeto.Descripcion = error.Reason.ToString() + "-" + error.Detail.Descripcion;
            }
            return empresaObjeto;
            
        }

        public List<Empresa> Listar()
        {
            return empresaDAO.Listar();
        }


        public Empresa Modificar(Empresa empresaAModificar)
        {
            try
            {
                return empresaDAO.Modificar(empresaAModificar);
            }
            catch (FaultException<RepetidoException> error)
            {
                empresaAModificar.Codigo = error.Detail.Codigo;
                empresaAModificar.Descripcion = error.Reason.ToString() + "-" + error.Detail.Descripcion;
            }

            return empresaAModificar;
        }

        public void Eliminar(string nombre, ref string codigo, ref string descripcion)
        {
            try
            {
                Empresa ObjetoEmpresa;
                ObjetoEmpresa = empresaDAO.Obtener(nombre);

                if (ObjetoEmpresa.Estado != "0")
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "No se puede eliminar la Empresa se encuentra Inactiva"
                    }, new FaultReason("Error al intentar eliminar la empresa"));
                }
                empresaDAO.Eliminar(nombre);
            }
            catch (FaultException<RepetidoException> error)
            {
                codigo = error.Detail.Codigo;
                descripcion = error.Detail.Descripcion;
            }
            
        }

        public Empresa Obtener(string nombre)
        {
            return empresaDAO.Obtener(nombre);
        }


        #endregion
    }
}
