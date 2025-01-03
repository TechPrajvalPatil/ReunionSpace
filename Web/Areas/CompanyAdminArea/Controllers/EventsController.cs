using Core;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyAdminArea.Controllers
{
    [Area("CompanyAdminArea")]
    public class EventsController : Controller
    {
        IEventRepo erepo;
        IWebHostEnvironment env;
        ICompanyAdminRepo crepo;
        public EventsController(IEventRepo erepo, IWebHostEnvironment env,ICompanyAdminRepo crepo)
        {
            this.erepo = erepo;
            this.env = env;
            this.crepo = crepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event rec)
        {
            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            if (ModelState.IsValid)
            {
                try
                {
                    if(rec.PhotoFile != null)
                    {
                        if(rec.PhotoFile.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "EventPhotos");
                            string path = Path.Combine(folderpath, rec.PhotoFile.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.PhotoFile.CopyTo(fs);
                            rec.EventLogo = Path.Combine(@"\EventPhotos", rec.PhotoFile.FileName);
                        }
                        else
                        {
                            ModelState.AddModelError("PhotoFile", "Please Select File having > 1 byte");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("PhotoFile", "Please Select File Uplod");
                        return View(rec);
                    }
                    this.erepo.Add(rec);
                    TempData["success"] = "Great! Your event has been added successfully!";
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }
            }
            return View(rec);
        }

        public IActionResult Edit(Int64 id)
        {
            var rec = this.erepo.GetById(id);

            ViewBag.Companies = new SelectList(this.crepo.GetAll(), "CompanyAdminId", "FullName");
            return View(rec);
        }


        [HttpPost]
        public IActionResult Edit(Event rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (rec.PhotoFile != null)
                    {
                        if (rec.PhotoFile.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "EventPhotos");
                            string path = Path.Combine(folderpath, rec.PhotoFile.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.PhotoFile.CopyTo(fs);
                            rec.EventLogo = Path.Combine(@"\EventPhotos", rec.PhotoFile.FileName);
                        }
                        else
                        {
                            ModelState.AddModelError("PhotoFile", "Please Select File having > 1 byte");
                            return View(rec);
                        }
                    }


                    this.erepo.Update(rec);
                    TempData["success"] = "Awesome! The event details have been updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    return View(rec);
                }
            }

            return View(rec);
        }

        public IActionResult Delete(Int64 id)
        {
            this.erepo.DeleteEventWithRegistrations(id);
            TempData["success"] = "Done! The event has been removed successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(Int64 id)
        {
            var rec = this.erepo.GetById(id);
            return View(rec);
        }
       
    }
}
