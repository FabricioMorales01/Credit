using Credit.Model;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtResponse : BaseResponse
    {
        [DataMember]
        public Debt Debt { get; set; }
    }
}