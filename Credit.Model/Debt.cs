using System;
using System.ComponentModel.DataAnnotations;

namespace Credit.Model
{
    public class Debt
    {
        #region Properties

        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public double Percentage { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }

        [Required]
        public int DebtorId { get; set; }

        public virtual Debtor Debtor { get; set; }

        #endregion
    }
}
