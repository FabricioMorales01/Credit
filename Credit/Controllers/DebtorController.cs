using Credit.Data.Infrastructure;
using Credit.Model;
using System.Net;
using System.Web.Mvc;

namespace Credit.Controllers
{
    public class DebtorController : BaseController
    {
        // GET: Debtor
        public ActionResult Index()
        {
            var debtors = UnitOfWork.DebtorRepository.Get(null, null);
            return View(debtors);
        }

        // GET: Debtor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Debtor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Debtor debtor)
        {
            if (ModelState.IsValid) {
                UnitOfWork.DebtorRepository.Insert(debtor);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(debtor);
        }

        // GET: Debtor/Edit/[:id]
        public ActionResult Edit(int? id)
        {
            if (null == id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Debtor debtor = UnitOfWork.DebtorRepository.GetById(id);
            if (null == debtor)
            {
                return HttpNotFound();
            }
            return View(debtor);
        }

        // POST: Debtor/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Debtor debtor)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.DebtorRepository.Update(debtor);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(debtor);
        }

        // GET: Debtor/Delete/[:id]
        public ActionResult Delete(int? id)
        {
            if (null == id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Debtor debtor = UnitOfWork.DebtorRepository.GetById(id);
            if (null == debtor)
            {
                return HttpNotFound();
            }
            return View(debtor);
        }

        // POST: Debtor/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            
            UnitOfWork.DebtorRepository.Delete(id);
            UnitOfWork.Save();

            return RedirectToAction("Index");
            
        }

    }
}