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
    public interface ICreateEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/create", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string CreateEmail(ViewModelEmail Data);
    }

    [ServiceContract]
    public interface IUpdateEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/update", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateEmail(ViewModelEmail Data);
    }

    [ServiceContract]
    public interface IDeleteEmail
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/delete", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteEmail(int Id, int HighUser);
    }

    public interface IReadEmail
    {
        List<ViewModelEmail> ReadEmail(int Id);
    }

    public interface IReadAllEmail
    {
        List<ViewModelEmail> ReadAllEmail();
    }
}
