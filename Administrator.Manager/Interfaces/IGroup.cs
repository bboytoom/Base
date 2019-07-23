using Administrator.Manager.Helpers;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
{
    #region Servicios WCF

    [ServiceContract]
    public interface ICreateGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/create", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CreateGroup(ViewModelGroup Data);
    }

    [ServiceContract]
    public interface IUpdateGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/update", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string UpdateGroup(ViewModelGroup Data);
    }

    [ServiceContract]
    public interface IDeleteGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/delete", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteGroup(int Id, int HighUser);
    }

    #endregion
}
