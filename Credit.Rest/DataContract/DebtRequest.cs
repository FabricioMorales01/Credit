using Credit.Model;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtRequest
    {
        [DataMember]
        public Debt Debt { get; set; }
    }
}