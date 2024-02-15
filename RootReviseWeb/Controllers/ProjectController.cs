using Microsoft.AspNetCore.Mvc;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootReviseWeb.Controllers {
   public class ProjectController : Controller {
      private readonly IUnitOfWork _unitOfWork;

      public ProjectController(IUnitOfWork unitOfWork) {
         _unitOfWork = unitOfWork;
      }
      public IActionResult Index() {
         List<Project> projectsList = _unitOfWork.ProjectRepository.GetAll().ToList();
         return View(projectsList);
      }

      public IActionResult Upsert(int? projectId) {
         if (projectId == null) {
            Project project = new();
            return View(project);
         } else {
            Project project = _unitOfWork.ProjectRepository.Get(u => u.ProjectId == projectId);
            return View(project);
         }

      }

      [HttpPost]
      public IActionResult Upsert(Project project) {
         if (ModelState.IsValid) {
            if (project.ProjectId == 0) {
               _unitOfWork.ProjectRepository.Add(project);
            } else {
               _unitOfWork.ProjectRepository.Update(project);
            }
            _unitOfWork.Save();
         } else {
            project = new();
            return View(project);
         }
         return RedirectToAction("Index");
      }
   }
}
