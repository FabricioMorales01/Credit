using Credit.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtListResponse : BaseResponse
    {
        public DebtListResponse()
        {
            DebtsList = new List<Debt>();
        }

        [DataMember]
        public IEnumerable<Debt> DebtsList { get; set; }
    }
}