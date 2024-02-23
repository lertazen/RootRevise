using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;
using RootRevise.Models.ViewModels;
using RootRevise.Utility;

namespace RootReviseWeb.Controllers {
   [Authorize]
   public class IssueController : Controller {
      private readonly IUnitOfWork _unitOfWork;

      public IssueController(IUnitOfWork unitOfWork) {
         _unitOfWork = unitOfWork;
      }
      public IActionResult Index() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project").ToList();
         return View(issueList);
      }

      [Authorize(Roles = SD.Role_Admin)]
      public IActionResult Upsert(int? id) {
         IssueVM issueVM = new() {
            ProjectList = _unitOfWork.ProjectRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.ProjectId.ToString(),
               }),
            StatusList = _unitOfWork.StatusRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.StatusId.ToString(),
               }),
            PriorityList = _unitOfWork.PriorityRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.PriorityId.ToString(),
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
      [Authorize(Roles = SD.Role_Admin)]
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
            issueVM.StatusList = _unitOfWork.StatusRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.StatusId.ToString()
               });
            issueVM.PriorityList = _unitOfWork.PriorityRepository.GetAll().Select(
               u => new SelectListItem {
                  Text = u.Name,
                  Value = u.PriorityId.ToString()
               });
            return View(issueVM);
         }
         return RedirectToAction("Index");
      }

      public IActionResult Details(int issueId) {
         Issue issue = _unitOfWork.IssueRepository.Get(i => i.IssueId == issueId, includeProperties: "Project,Status,Priority,Reporter,Assignee");
         return View(issue);
      }

      #region API CALL
      [HttpGet]
      public IActionResult GetAllIssues() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project,Status,Priority").ToList();
         return Json(new { data = issueList });
      }

      [HttpGet]
      public IActionResult GetIssuesByProjectId(int projectId) {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(i => i.ProjectId == projectId, includeProperties: "Status").ToList();
         return Json(new { data = issueList });
      }

      [Authorize(Roles = SD.Role_Admin)]
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
