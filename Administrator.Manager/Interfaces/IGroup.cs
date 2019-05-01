using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Administrator.Manager.Interfaces
{
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
        string DeleteGroup(ViewModelGroup Data);
    }

    public interface IReadGroup
    {
        List<ViewModelGroup> ReadGroup(int Id);
    }

    public interface IReadAllGroup
    {
        List<Tbl_Groups> ReadAllGroup();
    }
}
