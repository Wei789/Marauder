using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using NLog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Marauder.Web.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService comapnyService;

        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        
        public CompanyController(ICompanyService comapnyService)
        {
            this.comapnyService = comapnyService;
        }

        // GET: Company
        public ActionResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var query = this.comapnyService.GetAll();
            var companys = query.ToPagedList(currentPage, base.pageSize);
            return View(companys);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyView acct_company = this.comapnyService.GetByID(id);
            if (acct_company == null)
            {
                return HttpNotFound();
            }
            return View(acct_company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "acct_company_id,name,code,display_name,contact,title,note,date_created")] CompanyView acct_company)
        {
            if (ModelState.IsValid)
            {
                this.comapnyService.Create(acct_company);
                this.comapnyService.Save();
                return RedirectToAction("Index");
            }

            return View(acct_company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyView acct_company = this.comapnyService.GetByID(id);
            if (acct_company == null)
            {
                return HttpNotFound();
            }
            return View(acct_company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "acct_company_id,name,code,display_name,contact,title,note,date_created")] CompanyView acct_company)
        {
            if (ModelState.IsValid)
            {
                this.comapnyService.Update(acct_company);
                this.comapnyService.Save();
                return RedirectToAction("Index");
            }
            return View(acct_company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            CompanyView acct_company = this.comapnyService.GetByID(id);
            if (acct_company == null)
            {
                return HttpNotFound();
            }
            return View(acct_company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CompanyView acct_company = this.comapnyService.GetByID(id);
            this.comapnyService.Delete(id);
            this.comapnyService.Save();
            return RedirectToAction("Index");
        }
    }
}
