using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Interface
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/login", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string Login(string Email, string Password);
    }

    [ServiceContract]
    public interface ICheckEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/checkemail", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CheckEmail(string Email);
    }
}
