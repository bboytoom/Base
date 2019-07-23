using Administrator.Manager.Helpers;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
{
    #region Servicios WCF

    [ServiceContract]
    public interface ICreateUser
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/create", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string CreateUser(ViewModelUser Data);
    }

    [ServiceContract]
    public interface IUpdateUser
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/update", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string UpdateUser(ViewModelUser Data);
    }

    [ServiceContract]
    public interface IDeleteUser
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/delete", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteUser(int Id, int HighUser);
    }

    [ServiceContract]
    public interface IUploadImg
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/upload", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void UploadImg(ViewModelUploadImg File);
    }

    #endregion
}
