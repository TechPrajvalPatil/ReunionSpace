using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class PollsController : Controller
    {
        IPollRepo prepo;
        ICompanyAdminRepo crepo;
        public PollsController(IPollRepo prepo,ICompanyAdminRepo crepo) 
        {
            this.prepo = prepo;
            this.crepo = crepo;
        }
        public IActionResult Index()
        {
            var res = this.prepo.GetPollListCount();
            return View(res);
        }


        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Poll rec)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    this.prepo.Add(rec);
                    TempData["success"] = "Poll Added Successfully";
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
            var rec = this.prepo.GetById(id);
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(Poll rec)
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");

            if (ModelState.IsValid)
            {
                try
                {
                    this.prepo.Update(rec);
                    TempData["success"] = "Poll Updated Successfully";
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
            this.prepo.DeletePollWithDependencies(id);
            TempData["success"] = "Poll Deleted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(Int64 id)
        {
            var res = this.prepo.GetMemberResponse(id);
            return View(res);
        }
    }
}
