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

    public interface ICheckEmail
    {
        bool CheckEmail(string Email);
    }
}
