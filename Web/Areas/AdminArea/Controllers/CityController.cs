using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [AdminAuth]
    [Area("AdminArea")]
    public class CityController : Controller
    {
        ICityRepo ctrepo;
        IStateRepo srepo;
        ICountryRepo crepo;
        public CityController(ICityRepo ctrepo, IStateRepo srepo, ICountryRepo crepo)
        {
            this.ctrepo = ctrepo;
            this.srepo = srepo;
            this.crepo = crepo;
        }
        public IActionResult Index()
        {
            var res=this.ctrepo.GetAll();
            return View(res);
        }


        public JsonResult GetStates(Int64 CountryId)
        {
            var res=this.srepo.GetStateByCountryId(CountryId);
            return Json(res);
        }

        public IActionResult Create()
        {
            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName");
            //ViewBag.states = new SelectList(this.srepo.GetAll(),"StateId","StateName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(City rec)
        {
            ViewBag.states = new SelectList(this.srepo.GetAll(), "StateId", "StateName");
            if (ModelState.IsValid)
            {
                try
                {
                    this.ctrepo.Add(rec);
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
            var rec = this.ctrepo.GetById(id);

            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName",rec.State.CountryId);

            var states = this.srepo.GetStateByCountryId(rec.State.CountryId);
            ViewBag.states = new SelectList(states, "StateId", "StateName",rec.StateId);

            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(City rec,Int64 country)
        {
            ViewBag.countries = new SelectList(this.crepo.GetAll(), "CountryId", "CountryName",country);

            var states = this.srepo.GetStateByCountryId(country);
            ViewBag.states = new SelectList(this.srepo.GetAll(), "StateId", "StateName",rec.StateId);

            if (ModelState.IsValid)
            {
                try
                {
                    this.ctrepo.Update(rec);
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
            this.ctrepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
