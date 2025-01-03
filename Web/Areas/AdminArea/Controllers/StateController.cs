using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [AdminAuth]
    [Area("AdminArea")]
    public class StateController : Controller
    {
        IStateRepo srepo;
        ICountryRepo crepo;
        public StateController(IStateRepo srepo,ICountryRepo crepo)
        {
            this.srepo = srepo;
            this.crepo = crepo;
        }
        public IActionResult Index()
        {
            var res=this.srepo.GetAll();
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(State rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.srepo.Add(rec);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.ToString());
                }
            }
            return View(rec);
        }


        public IActionResult Edit(Int64 id)
        {
            var rec = this.srepo.GetById(id);

            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName");
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(State rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.srepo.Update(rec);
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
            return RedirectToAction("Index");
        }
    }
}
