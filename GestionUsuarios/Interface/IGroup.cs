using GestionUsuarios.Helpers;
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
    public interface ICreateGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/create", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string CreateGroup(ViewModelGroup Data);
    }

    [ServiceContract]
    public interface IUpdateGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/update", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateGroup(ViewModelGroup Data);
    }

    [ServiceContract]
    public interface IDeleteGroup
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/delete", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteGroup(int Id, int HighUser);
    }

    public interface IReadGroup
    {
        List<ViewModelGroup> ReadGroup(int Id);
    }

    public interface IReadAllGroup
    {
        List<ViewModelGroup> ReadAllGroup();
    }
}
