using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
{
    public interface ILogin
    {
        Tbl_Users Login(ViewModelsLogin data);
    }

    [ServiceContract]
    public interface ICheckEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/checkemail", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CheckEmail(string Email);
    }
}
