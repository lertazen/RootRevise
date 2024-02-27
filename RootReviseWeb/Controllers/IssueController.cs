using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly UserManager<IdentityUser> _userManager;

      public IssueController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
         _unitOfWork = unitOfWork;
         _roleManager = roleManager;
         _userManager = userManager;
      }

      public IActionResult Index() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project").ToList();
         return View(issueList);
      }

      public IActionResult Upsert(int? id) {
         var developerList = new List<SelectListItem>();
         var usersInRole = _userManager.GetUsersInRoleAsync("Developer").GetAwaiter().GetResult();
         foreach (var user in usersInRole) {
            var appUser = user as ApplicationUser;
            if (appUser != null) {
               developerList.Add(new SelectListItem {
                  Text = appUser.Name,
                  Value = appUser.Id
               });
            }
         }
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
            DeveloperList = developerList,
            Issue = new Issue()
         };
         var claimsIdentity = (ClaimsIdentity)User.Identity;
         var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
         issueVM.Issue.ReporterId = userId;
         if (id == null || id == 0) {
            return View(issueVM);
         } else {
            issueVM.Issue = _unitOfWork.IssueRepository.Get(u => u.IssueId == id, includeProperties: "Reporter");
            return View(issueVM);
         }
      }

      [HttpPost]
      public IActionResult Upsert(IssueVM issueVM) {
         bool isAdmin = User.IsInRole(SD.Role_Admin);
         var developerList = new List<SelectListItem>();
         var usersInRole = _userManager.GetUsersInRoleAsync("Developer").GetAwaiter().GetResult();
         foreach (var user in usersInRole) {
            var appUser = user as ApplicationUser;
            if (appUser != null) {
               developerList.Add(new SelectListItem {
                  Text = appUser.Name,
                  Value = appUser.Id
               });
            }
         }
         if (ModelState.IsValid) {
            if (issueVM.Issue.IssueId == 0) {
               issueVM.Issue.DateReported = DateTime.Now;
               if(issueVM.Issue.PriorityId == 0) {
                  issueVM.Issue.PriorityId = (int)SD.PriorityLevel.Low;
               }
               if(issueVM.Issue.StatusId == 0) {
                  issueVM.Issue.StatusId = (int)SD.IssueStatus.Open;
               }
               _unitOfWork.IssueRepository.Add(issueVM.Issue);
               TempData.Add("success", "The issue has been created successfully");
            } else {
               if (!isAdmin) {
                  TempData.Add("error", "Unauthorized attempt to deit an issue.");
                  return RedirectToAction("Index");
               }
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
            issueVM.DeveloperList = developerList;
            return View(issueVM);
         }
         return RedirectToAction("Index");
      }

      public IActionResult Details(int issueId, string source) {
         IssueDetailsVM issueDetailsVM = new() {
            Issue = _unitOfWork.IssueRepository.Get(i => i.IssueId == issueId, includeProperties: "Project,Status,Priority,Reporter,Assignee"),
            ReturnUrl = source
         };
         return View(issueDetailsVM);
      }

      #region API CALL
      [HttpGet]
      public IActionResult GetAllIssues() {
         List<Issue> issueList = _unitOfWork.IssueRepository.GetAll(includeProperties: "Project,Status,Priority,Reporter,Assignee").ToList();
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
