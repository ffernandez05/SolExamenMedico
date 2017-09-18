using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WcfServices.Errores;

namespace WcfServices
{
    [DataContract]
    public class Atencion : RepetidoException
    {
        [DataMember]
        public string Dni { get; set; }

        [DataMember]
        public string Fecha{ get; set; }

        [DataMember]
        public string Estado{ get; set; }
    }
}