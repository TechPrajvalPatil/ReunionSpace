using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class PollOptionsController : Controller
    {
        IPollOptionRepo orepo;
        IPollRepo prepo;

        public PollOptionsController(IPollOptionRepo orepo, IPollRepo prepo)
        {
            this.orepo = orepo;
            this.prepo = prepo;
        }
        public IActionResult Index()
        {
            var res = this.orepo.GetAll();
            return View(res);
        }

        public IActionResult Create()
        {
            ViewBag.Polls = new SelectList(this.prepo.GetAll(), "PollId", "PollQuestion");
            ViewBag.CorrectOptions = new List<SelectListItem>
            {
              new SelectListItem { Text = "Yes", Value = "true" },
              new SelectListItem { Text = "No", Value = "false" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(PollOption rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.orepo.Add(rec);
                    TempData["success"] = "Poll Option Added Successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }
            }

            return View();

        }

        public IActionResult Edit(Int64 id)
        {
            var rec = this.orepo.GetById(id);
            ViewBag.CorrectOptions = new List<SelectListItem>
            {
              new SelectListItem { Text = "Yes", Value = "true" },
              new SelectListItem { Text = "No", Value = "false" }
            };

            ViewBag.Polls = new SelectList(this.prepo.GetAll(), "PollId", "PollQuestion");
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(PollOption rec)
        {
            ViewBag.Polls = new SelectList(this.prepo.GetAll(), "PollId", "PollQuestion");

            if (ModelState.IsValid)
            {
                try
                {
                    this.orepo.Update(rec);
                    TempData["success"] = "Poll Option Updated Successfully";
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
            this.orepo.Delete(id);
            TempData["success"] = "Poll Option Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
