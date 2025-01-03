using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.CustFilters;

namespace Web.Areas.MemberArea.Controllers
{
    [MemberAuth]
    [Area("MemberArea")]
    public class FeedsController : Controller
    {
        IWebHostEnvironment env;
        IFeedRepo frepo;
        public FeedsController(IWebHostEnvironment env, IFeedRepo frepo)
        {
            this.env = env;
            this.frepo = frepo;
        }
        public IActionResult Index()
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));
            var res =this.frepo.DisplayAllFeeds(memberId);
            return View(res);
        }

        public IActionResult ManageFeed()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeedsPhotoVideoVM rec)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            if (ModelState.IsValid)
            {
                try
                { 
                    

                    if (rec.FeedType == FeedTypeEnum.Photo && rec.FileUpload != null)
                    {
                        if (rec.FileUpload.Length > 0)
                        {

                            string folderpath = Path.Combine(env.WebRootPath, "FeedPhotos");
                            string path = Path.Combine(folderpath, rec.FileUpload.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                           rec.FileUpload.CopyTo(fs);
                            rec.PhotoPathFile = Path.Combine(@"\FeedPhotos", rec.FileUpload.FileName);
                        }
                        else
                        {
                            ModelState.AddModelError("FileUpload", "Please select a file with size greater than 0 bytes.");
                        }
                    }
                    else if (rec.FeedType == FeedTypeEnum.Video && rec.FileUpload != null)
                    {
                        if (rec.FileUpload.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "FeedVideos");
                            string path = Path.Combine(folderpath, rec.FileUpload.FileName);

                            FileStream fs = new FileStream(path, FileMode.Create);
                            rec.FileUpload.CopyTo(fs);
                            rec.VideoUrl = Path.Combine(@"\FeedVideos", rec.FileUpload.FileName);


                        }
                        else
                        {
                            ModelState.AddModelError("FileUpload", "Please select a file with size greater than 0 bytes.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please select a file to upload.");
                        return View(rec);
                    }

                    
                    this.frepo.CreateFeed(rec, memberId);
                    TempData["success"] = "Feed Saved Successfully and Waiting For Approval";
                    return RedirectToAction("ManageFeed");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            return View(rec);
        }

        public IActionResult Edit(Int64 id)
        {
            var res = this.frepo.GetFeedViewModelById(id);
            
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(EditFeedPhotoVideoVM rec)
        {
            var memberId = Convert.ToInt64(HttpContext.Session.GetString("MemberId"));

            if (ModelState.IsValid)
            {
                try
                {
                    
                    string existingPhotoPath = Request.Form["ExistingPhotoPath"];
                    string existingVideoUrl = Request.Form["ExistingVideoUrl"];

                    
                    var existingFeed = this.frepo.GetFeedViewModelById(rec.FeedsId);
                    existingFeed.FeedTitle = rec.FeedTitle;
                    existingFeed.FeedsDescription = rec.FeedsDescription;

                    
                    if (rec.FeedType == FeedTypeEnum.Photo)
                    {
                        if (rec.FileUpload != null && rec.FileUpload.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "FeedPhotos");
                            string path = Path.Combine(folderpath, rec.FileUpload.FileName);

                            using (FileStream fs = new FileStream(path, FileMode.Create))
                            {
                                rec.FileUpload.CopyTo(fs);
                            }

                            rec.PhotoPathFile = Path.Combine(@"\FeedPhotos", rec.FileUpload.FileName);
                        }
                        else
                        {
                            rec.PhotoPathFile = existingPhotoPath;
                        }
                    }
                    else if (rec.FeedType == FeedTypeEnum.Video)
                    {
                        if (rec.FileUpload != null && rec.FileUpload.Length > 0)
                        {
                            string folderpath = Path.Combine(env.WebRootPath, "FeedVideos");
                            string path = Path.Combine(folderpath, rec.FileUpload.FileName);

                            using (FileStream fs = new FileStream(path, FileMode.Create))
                            {
                                rec.FileUpload.CopyTo(fs);
                            }
                            rec.VideoUrl = Path.Combine(@"\FeedVideos", rec.FileUpload.FileName);
                        }
                        else
                        {
                            rec.VideoUrl = existingVideoUrl;
                        }
                    }

                    this.frepo.UpdateFeed(rec, memberId);
                    TempData["success"] = "Feed Updated Successfully";
                    return RedirectToAction("ManageFeed");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            return View(rec);
        }



        public IActionResult Delete(Int64 id)
        {
            this.frepo.DeleteFeed(id);
            TempData["success"] = "Feed deleted successfully.";
            return RedirectToAction("ManageFeed");
        }


        public IActionResult FeedsByMember(Int64 id)
        {
            var mf= this.frepo.GetMemberFeedById(id);

            
            return View(mf);
        }

    }
}
