using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    
    [Area("MemberArea")]
    public class ProfileController : Controller
    {
        IProfileRepo prepo;
        IWebHostEnvironment env;
        public ProfileController(IProfileRepo prepo, IWebHostEnvironment env)
        {
            this.prepo = prepo;
            this.env = env;
        }


        public IActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEducation(MemberEducation rec)
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            rec.MemberId = memberId;
            this.prepo.AddMemberEducation(rec);
            TempData["success"] = "Education Details Added successfully!";
            return RedirectToAction("EditProfile", "MemberHome");
        }

        public IActionResult EditEducation(Int64 id)
        {
            var rec = this.prepo.GetById(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditEducation(MemberEducation rec)
        {
            this.prepo.UpdateMemberEducation(rec);
            TempData["success"] = "Education Details updated successfully!";
            return RedirectToAction("EditProfile","MemberHome");
        }


        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(MemberExperience rec)
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            rec.MemberId = memberId;
            this.prepo.AddMemberExperience(rec);
            TempData["success"] = "Experience Added successfully!";
            return RedirectToAction("EditProfile", "MemberHome");
        }


        public IActionResult EditExperience(Int64 id)
        {
            var rec = this.prepo.GetMemberExperienceId(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditExperience(MemberExperience rec)
        {
            this.prepo.UpdateMemberExperience(rec);
            TempData["success"] = "Experience updated successfully!";
            return RedirectToAction("EditProfile", "MemberHome");
        }


        public IActionResult AddResume()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddResume(MemberResume rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (rec.ResumeFile != null)
                    {
                        if (rec.ResumeFile.Length > 0)
                        {
                            string fileName = Path.GetFileName(rec.ResumeFile.FileName);
                            string folderpath = Path.Combine(env.WebRootPath, "ResumesDoc");
                            string path = Path.Combine(folderpath, rec.ResumeFile.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.ResumeFile.CopyTo(fs);
                            rec.ResumeFilePath = Path.Combine(@"\ResumesDoc", rec.ResumeFile.FileName);
                            rec.FileType = Path.GetExtension(fileName).TrimStart('.').ToUpper();
                        }
                        else
                        {
                            ModelState.AddModelError("ResumeFilePath", "Please Select File having > 1 byte");
                            return View(rec);
                        }
                        Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
                        this.prepo.AddResume(rec, memberId);
                        TempData["success"] = "Resume Added Successfully!!";
                        return RedirectToAction("EditProfile", "MemberHome");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    return View(rec);
                }
            }
            return View(rec);
        }



        public IActionResult EditResume(Int64 id)
        {
            var rec= this.prepo.GetResumeById(id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult EditResume(MemberResume rec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (rec.ResumeFile != null)
                    {
                        if (rec.ResumeFile.Length > 0)
                        {
                            string fileName = Path.GetFileName(rec.ResumeFile.FileName);
                            string folderpath = Path.Combine(env.WebRootPath, "ResumesDoc");
                            string path = Path.Combine(folderpath, rec.ResumeFile.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.ResumeFile.CopyTo(fs);
                            rec.ResumeFilePath = Path.Combine(@"\ResumesDoc", rec.ResumeFile.FileName);
                            rec.FileType = Path.GetExtension(fileName).TrimStart('.').ToUpper();
                        }
                        else
                        {
                            ModelState.AddModelError("ResumeFilePath", "Please Select File having > 1 byte");
                            return View(rec);
                        }
                        Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
                        this.prepo.EditResume(rec, memberId);
                        TempData["success"] = "Resume Updated Successfully!!";
                        return RedirectToAction("EditProfile", "MemberHome");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                    return View(rec);
                }
            }
            return View(rec);
        }


        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(MemberSkills rec, Int64[] chk)
        {
            Int64 memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            this.prepo.AddMemberSkills(rec,chk,memberId);
            TempData["success"] = "Skills Added Successfully!!";
            return RedirectToAction("EditProfile", "MemberHome");
        }

    }

}
