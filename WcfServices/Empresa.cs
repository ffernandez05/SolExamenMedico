using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WcfServices.Errores;

namespace WcfServices
{

    [DataContract]
    public class Empresa : RepetidoException
    {
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string RUC { get; set; }

        [DataMember]
        public string Estado { get; set; }

    }
}