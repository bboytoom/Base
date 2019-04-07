using GestionUsuarios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Helpers
{

    public class OutJsonCheck
    {
        public int Status { get; set; }
        public bool Respuesta { get; set; }
    }

    [DataContract]
    public class CustomErrorDetail
    {
        public CustomErrorDetail(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDetails { get; private set; }
    }
}
