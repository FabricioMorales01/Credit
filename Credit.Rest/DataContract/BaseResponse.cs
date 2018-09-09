using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}