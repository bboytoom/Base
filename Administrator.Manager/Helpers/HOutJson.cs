using System.Runtime.Serialization;

namespace Administrator.Manager.Helpers
{
    [DataContract]
    public class CustomErrorDetail
    {
        public CustomErrorDetail(int errorstatus, string errorInfo, string errorDetails)
        {
            ErrorStatus = errorstatus;
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        [DataMember]
        public int ErrorStatus { get; private set; }

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDetails { get; private set; }
    }
}
