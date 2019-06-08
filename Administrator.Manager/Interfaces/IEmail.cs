﻿using Administrator.Manager.Data;
using Administrator.Manager.Helpers;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Administrator.Manager.Interfaces
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
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/delete", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteEmail(ViewModelEmail Data);
    }

    public interface IReadEmail
    {
        List<ViewModelEmail> ReadEmail(int Id);
    }

    public interface IReadAllEmail
    {
        List<Tbl_Emails> ReadAllEmail();
    }
}