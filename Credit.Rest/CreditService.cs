using Credit.Data.Infrastructure;
using Credit.Model;
using Credit.Rest.DataContract;
using System;

namespace Credit.Rest
{
    public class CreditService : ICreditService
    {

        #region Fields
        private UnitOfWork UnitOfWork = new UnitOfWork();

        #endregion

        #region Debtor Methods

        public DebtorListResponse GetDebtors()
        {
            var Response = new DebtorListResponse();
            try
            {
                Response.DebtorsList = DebtorDataMember.ConvertFromEntityList(
                    UnitOfWork.DebtorRepository.Get()
                );
                Response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = ex.Message;

            }

            return Response;
        }

        public DebtorResponse GetDebtor(int id)
        {
            var Response = new DebtorResponse();
            try
            {
                Response.Debtor = Response.Debtor = DebtorDataMember.ConvertFromEntity(
                    UnitOfWork.DebtorRepository.GetById(id)
                );
                Response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = ex.Message;

            }

            return Response;
        }

        public BaseResponse InsertDebtor(DebtorRequest debtorRequest) {
            var Response = new BaseResponse();
            try
            {
                UnitOfWork.DebtorRepository.Insert(debtorRequest.Debtor.Entity);
                UnitOfWork.Save();
                Response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = ex.Message;

            }

            return Response;
        }

        public BaseResponse UpdateDebtor(DebtorRequest debtorRequest)
        {
            var Response = new BaseResponse();
            try
            {

                Debtor debtor = UnitOfWork.DebtorRepository.GetById(debtorRequest.Debtor.Id);

                if (debtor == null)
                {
                    Response.ErrorMessage = string.Format("Usuario {0} no encontrado", 
                        debtorRequest.Debtor.Id);
                }
                else
                {
                    debtor.Name = debtorRequest.Debtor.Name;
                    debtor.Email = debtorRequest.Debtor.Email;
                    debtor.Phone = debtorRequest.Debtor.Phone;

                    UnitOfWork.DebtorRepository.Update(debtor);
                    UnitOfWork.Save();
                    Response.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = ex.Message;

            }

            return Response;
        }


        public BaseResponse DeleteDebtor(DebtorRequest debtorRequest)
        {
            var Response = new BaseResponse();
            try
            {   
                UnitOfWork.DebtorRepository.Delete(debtorRequest.Debtor.Id);
                UnitOfWork.Save();
                Response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                Response.IsSuccessful = false;
                Response.ErrorMessage = ex.Message;

            }

            return Response;
        }

        #endregion

    }
}
