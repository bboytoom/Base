using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
{
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

    public interface IReadUser
    {
        ViewModelUser ReadUser(int Id);
    }

    public interface IReadAllUser
    {
        List<Tbl_Users> ReadAllUser(string sortorder, string searchstring);
    }
}
