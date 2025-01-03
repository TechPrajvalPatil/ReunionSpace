using Core;
using Infra;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.AdminArea.Controllers
{
    [AdminAuth]
    [Area("AdminArea")]
    public class CountriesController : Controller
    {
        ICountryRepo crepo;
        public CountriesController(ICountryRepo crepo)
        {
            this.crepo = crepo;
        }
        public IActionResult Index()
        {
            var res= this.crepo.GetAll();
            return View(res);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.crepo.Add(rec);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("",ex.ToString());
                }
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec= this.crepo.GetById(id);
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(Country rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.crepo.Update(rec);
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
            this.crepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
