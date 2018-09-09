using Credit.Model;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtorResponse : BaseResponse
    {
        [DataMember]
        public DebtorDataMember Debtor { get; set; }
    }
}