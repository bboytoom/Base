using Administrator.Manager.Helpers;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
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
