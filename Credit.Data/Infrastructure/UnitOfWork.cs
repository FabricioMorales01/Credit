using Credit.Model;
using System;

namespace Credit.Data.Infrastructure
{
    public class UnitOfWork : IDisposable{
        #region Fields

        private Context context = new Context();

        private BaseRepository<Debtor> debtorRepository;

        private DebtRepository debtRepository;

        private bool disposed = false;
        #endregion

        #region Properties

        public BaseRepository<Debtor> DebtorRepository
        {
            get
            {

                if (null == this.debtorRepository)
                {
                    this.debtorRepository = new BaseRepository<Debtor>(context);
                }

                return this.debtorRepository;
            }
        }

        public DebtRepository DebtRepository
        {
            get
            {
                if (null == this.debtRepository)
                {
                    this.debtRepository = new DebtRepository(context);
                }

                return this.debtRepository;
            }
        }

        #endregion

        #region Methods

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
