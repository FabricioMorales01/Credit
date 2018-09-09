using Credit.Model;
using System.Net;
using System.Web.Mvc;

namespace Credit.Controllers
{
    public class DebtController : BaseController
    {
        
        #region Methods
        // GET: Debts?debtorId=5
        public ActionResult Index(int? debtorId)
        {
            Debtor debtor = null;
            var action = GetDebtorAction(debtorId, ref debtor);
            if (action != null)
            {
                return action;
            }

            ViewBag.DebtorId = debtorId;
            ViewBag.DebtorName = debtor.Name;
            var debts = UnitOfWork.DebtRepository.GetByDebotorId(debtorId.Value);
            return View(debts);
        }

        // GET: Debts/Details/5
        public ActionResult Details(int? id)
        {
            Debt debt = null;
            var action = GetDebtAction(id, ref debt);
            if (action != null)
            {
                return action;
            }
            return View(debt);
        }

        // GET: Debts/Create?debtorId=5
        public ActionResult Create(int? debtorId)
        {            
            Debtor debtor = null;
            var action = GetDebtorAction(debtorId, ref debtor);
            if (action != null)
            {
                return action;
            }

            Debt debt = new Debt()
            {
                DebtorId = debtorId.Value,
                Debtor = debtor
            };

            return View(debt);
        }

        // POST: Debts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,DebtorId")] Debt debt)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.DebtRepository.Insert(debt);
                UnitOfWork.Save();
                return RedirectToAction("Index", new { debtorId = debt.DebtorId});
            }
            
            return View(debt);
        }

        // GET: Debts/Edit/5
        public ActionResult Edit(int? id)
        {
            Debt debt = null;
            var action = GetDebtAction(id, ref debt);
            if (action != null)
            {
                return action;
            }

            return View(debt);
        }

        // POST: Debts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,DebtorId")] Debt debt)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.DebtRepository.Update(debt);
                UnitOfWork.Save();
                return RedirectToAction("Index", new { debtorId = debt.DebtorId });
            }
            
            return View(debt);
        }

        // GET: Debts/Delete/5
        public ActionResult Delete(int? id)
        {
            Debt debt = null;
            var action = GetDebtAction(id, ref debt);
            if (action != null)
            {
                return action;
            }

            return View(debt);
        }

        // POST: Debts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitOfWork.DebtRepository.Delete(id);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }

       
        #endregion

        #region Private Methods

        private ActionResult GetDebtorAction(int? debtorId, ref Debtor debtor) {
            if (debtorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            debtor = UnitOfWork.DebtorRepository.GetById(debtorId);
            if (debtor == null)
            {
                return HttpNotFound();
            }

            return null;
        }

        private ActionResult GetDebtAction(int? debtId, ref Debt debt)
        {
            if (debtId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            debt = UnitOfWork.DebtRepository.GetById(debtId);
            if (debt == null)
            {
                return HttpNotFound();
            }

            return null;
        }

        #endregion
    }
}
