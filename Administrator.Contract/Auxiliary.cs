using System.Runtime.Serialization;

namespace Administrator.Contract
{
    public class ViewModelUpload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

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
