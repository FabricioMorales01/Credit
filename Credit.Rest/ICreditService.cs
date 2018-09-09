using Credit.Rest.DataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Credit.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICreditService" in both code and config file together.
    [ServiceContract]
    public interface ICreditService
    {

        #region Debotor Methods 

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DebtorListResponse GetDebtors();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DebtorResponse GetDebtor(int id);
        
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse InsertDebtor(DebtorRequest debtorRequest);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse UpdateDebtor(DebtorRequest debtorRequest);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse DeleteDebtor(DebtorRequest debtorRequest);

        #endregion

    }
    
}
