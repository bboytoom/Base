using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
{
    #region Servicios WCF

    [ServiceContract]
    public interface ICheckEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/checkemail", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CheckEmail(string Email);
    }

    #endregion
}
