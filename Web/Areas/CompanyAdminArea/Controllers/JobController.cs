using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class JobController : Controller
    {
        IJobProfileRepo jrepo;
        ICompanyAdminRepo crepo;
        public JobController(IJobProfileRepo jrepo, ICompanyAdminRepo crepo)
        {
            this.jrepo = jrepo;
            this.crepo = crepo;
        }

        public IActionResult Index()
        {
            var res = this.jrepo.GetAll();
            return View(res);
        }

        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.jrepo.Add(rec);
                    TempData["success"] = "Job Added Successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }
            }
            return View(rec);
        }

        public IActionResult Edit(Int64 id)
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            var rec = this.jrepo.GetById(id);
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(Job rec)
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");

            if (ModelState.IsValid)
            {
                try
                {
                    this.jrepo.Update(rec);
                    TempData["success"] = "Job updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }
            }
            return View(rec);
        }

        public IActionResult Delete(Int64 id)
        {
            this.jrepo.Delete(id);
            TempData["success"] = "Job deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
