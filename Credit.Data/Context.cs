using Credit.Model;
using System.Data.Entity;

namespace Credit.Data
{
    public class Context : DbContext
    {
        public Context() : base("CreditDBConnectionString") {

        }

        #region Properties

        public DbSet<Debt> Debt { get; set; }
        public DbSet<Debtor> Debtors { get; set; }

        

        #endregion
    }
}
