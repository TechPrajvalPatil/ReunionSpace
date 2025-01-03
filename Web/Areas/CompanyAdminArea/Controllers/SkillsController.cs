using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class SkillsController : Controller
    {
        ISkillsRepo srepo;
        public SkillsController(ISkillsRepo srepo)
        {
            this.srepo = srepo;
        }

        public IActionResult Index()
        {
            var res = this.srepo.GetAll();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.srepo.Add(rec);
                    TempData["success"] = "Skill Added Successfully";
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
            var rec = this.srepo.GetById(id);
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(Skill rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.srepo.Update(rec);
                    TempData["success"] = "Skill Updated Successfully";
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
            this.srepo.Delete(id);
            TempData["success"] = "Skill Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

