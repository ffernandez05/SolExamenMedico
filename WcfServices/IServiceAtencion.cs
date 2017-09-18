using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Errores;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceAtencion" in both code and config file together.
    [ServiceContract]
    public interface IServiceAtencion
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Atencion Registro(Atencion obj);

        [OperationContract]
        List<Atencion> Listar();

        [OperationContract]
        Atencion Obtener(string dni);

        [OperationContract]
        Atencion Modificar(Atencion AtencionAModificar);

        [OperationContract]
        void Eliminar(string dni, ref string codigo, ref string descripcion);

    }
}
