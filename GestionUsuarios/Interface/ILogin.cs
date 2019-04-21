using GestionUsuarios.Helpers;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GestionUsuarios.Interface
{
    public interface ILogin
    {
        IQueryable Login(ViewModelsLogin data);
    }

    [ServiceContract]
    public interface ICheckEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/checkemail", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CheckEmail(string Email);
    }
}
