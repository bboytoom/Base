using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GestionUsuarios.Interface
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
        string DeleteUser(ViewModelUser Data);
    }

    public interface IReadUser
    {
        List<ViewModelUser> ReadUser(int Id);
    }

    public interface IReadAllUser
    {
        List<Tbl_Usuarios> ReadAllUser();
    }
}
