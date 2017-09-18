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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAtencion" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAtencion.svc or ServiceAtencion.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAtencion : IServiceAtencion
    {
        #region Miembros de IComprobante

        private AtencionData AtencionDAO = new AtencionData();

        public Atencion Registro(Atencion AtencionObjeto)
        {
            try
            {
                if (AtencionDAO.Obtener(AtencionObjeto.Dni) != null)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Atencion ya existe"
                    }, new FaultReason("Error al intentar la Creacion"));
                }
                AtencionDAO.Crear(AtencionObjeto);
            }
            catch (FaultException<RepetidoException> error)
            {
                AtencionObjeto.Codigo = error.Detail.Codigo;
                AtencionObjeto.Descripcion = error.Reason.ToString() + "-" + error.Detail.Descripcion;
            }
            return AtencionObjeto;
            
        }

        public List<Atencion> Listar()
        {
            return AtencionDAO.Listar();
        }


        public Atencion Modificar(Atencion AtencionObjeto)
        {
            try
            {
                return AtencionDAO.Modificar(AtencionObjeto);
            }
            catch (FaultException<RepetidoException> error)
            {
                AtencionObjeto.Codigo = error.Detail.Codigo;
                AtencionObjeto.Descripcion = error.Reason.ToString() + "-" + error.Detail.Descripcion;
            }
            return AtencionObjeto;
        }

        public void Eliminar(string dni,ref string codigo,ref string descripcion)
        {
            Atencion ObjetoAtencion;
            
            try
            {
                ObjetoAtencion = AtencionDAO.Obtener(dni);
                if (ObjetoAtencion.Estado != "0")
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "No se puede eliminar la Atencion se encuentra Inactiva"
                    }, new FaultReason("Error al intentar eliminar la Atencion"));
                }
                AtencionDAO.Eliminar(dni);
            }
            catch (FaultException<RepetidoException> error)
            {
                codigo = error.Detail.Codigo;
                descripcion = error.Detail.Descripcion;
            }
            
        }

        public Atencion Obtener(string dni)
        {
            return AtencionDAO.Obtener(dni);
        }


        #endregion
    }
}
