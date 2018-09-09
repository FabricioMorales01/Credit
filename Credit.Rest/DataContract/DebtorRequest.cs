using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{

    [DataContract]
    public class DebtorRequest
    {
        public DebtorRequest() {
            Debtor = new DebtorDataMember();
        }

        [DataMember]
        public DebtorDataMember Debtor { get; set; }
    }
}