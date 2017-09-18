using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Errores;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceEmpresa" in both code and config file together.
    [ServiceContract]
    public interface IServiceEmpresa
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Empresa Registro(Empresa obj);

        [OperationContract]
        List<Empresa> Listar();

        [OperationContract]
        Empresa Obtener(string nombre);

        [OperationContract]
        Empresa Modificar(Empresa empresaAModificar);

        [OperationContract]
        void Eliminar(string nombre, ref string codigo, ref string descripcion);




    }
}
