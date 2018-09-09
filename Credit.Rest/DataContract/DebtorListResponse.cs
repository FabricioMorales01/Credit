using Credit.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtorListResponse : BaseResponse
    {

        [DataMember]
        public IEnumerable<DebtorDataMember> DebtorsList { get; set; }

    }
}