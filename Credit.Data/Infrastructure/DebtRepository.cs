using Credit.Model;
using System.Collections.Generic;

namespace Credit.Data.Infrastructure
{
    public class DebtRepository : BaseRepository<Debt>
    {

        #region Constructor
        public DebtRepository(Context context) : base(context)
        {
        }
        #endregion

        #region Methods

        public virtual IEnumerable<Debt> GetByDebotorId(int debtorId)
        {
            return Get(debt => debt.DebtorId == debtorId, null);
        }

        #endregion
    }
}
