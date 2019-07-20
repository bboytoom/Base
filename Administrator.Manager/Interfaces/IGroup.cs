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

    #region Generales

    public interface IReadGroup
    {
        ViewModelGroup ReadGroup(int Id);
    }

    public interface IReadAllGroup
    {
        List<Tbl_Groups> ReadAllGroup(string sortOrder, string searchstring, int id_main);
    }

    public interface IReadGroupUser
    {
        List<Tbl_Groups> ReadGroupUser(int Id);
    }

    #endregion
}
