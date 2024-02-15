using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;
using RootRevise.Models.ViewModels;

namespace RootReviseWeb.Controllers {
   public class IssueController : Controller {
      private readonly IUnitOfWork _unitOfWork;

      public IssueController(IUnitOfWork unitOfWork) {
         _unitOfWork = unitOfWork;
      }
      public IActionResult Index() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project").ToList();
         return View(issueList);
      }

      public IActionResult Upsert(int? id) {
         IssueVM issueVM = new() {
            ProjectList = _unitOfWork.ProjectRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.ProjectId.ToString(),
               }),
            Issue = new Issue()
         };
         if (id == null || id == 0) {
            return View(issueVM);
         } else {
            issueVM.Issue = _unitOfWork.IssueRepository.Get(u => u.IssueId == id);
            return View(issueVM);
         }
      }

      [HttpPost]
      public IActionResult Upsert(IssueVM issueVM) {
         if (ModelState.IsValid) {
            if (issueVM.Issue.IssueId == 0) {
               issueVM.Issue.DateReported = DateTime.Now;
               _unitOfWork.IssueRepository.Add(issueVM.Issue);
               TempData.Add("success", "The issue has been created successfully");
            } else {
               _unitOfWork.IssueRepository.Update(issueVM.Issue);
               TempData.Add("success", "The issue has been updated successfully");
            }
            _unitOfWork.Save();
         } else {
            issueVM.ProjectList = _unitOfWork.ProjectRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.ProjectId.ToString()
               });
            return View(issueVM);
         }
         return RedirectToAction("Index");
      }

      #region API CALL
      [HttpGet]
      public IActionResult GetAllIssues() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project").ToList();
         return Json(new { data = issueList });
      }

      public IActionResult Delete(int id) {
         Issue? issueToBeDeleted = _unitOfWork.IssueRepository.Get(u => u.IssueId == id);
         if (issueToBeDeleted == null) {
            TempData.Add("error", "Something went wrong, deletion failed");
            return Json(new { success = false, message = "Something went wrong, deleting failed" });
         }
         _unitOfWork.IssueRepository.Delete(issueToBeDeleted);
         _unitOfWork.Save();
         TempData.Add("success", "The issue has been deleted");
         return Json(new { success = true, message = "The issue has been deleted" });
      }
      #endregion
   }
}
