using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RootRevise.Models;
using RootRevise.Models.ViewModels;
using RootRevise.DataAccess.Repository.IRepository;

namespace RootReviseWeb.Controllers {
   public class HomeController : Controller {
      private readonly ILogger<HomeController> _logger;
      private readonly IUnitOfWork _unitOfWork;

      public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) {
         _logger = logger;
         _unitOfWork = unitOfWork;
      }

      public IActionResult Index() {
         HomeVM homeVM = new() { 
            OpenIssueNumber = _unitOfWork.IssueRepository.GetAll(u => u.Status.Name == "Open").Count(),
            HighPriorityNumber = _unitOfWork.IssueRepository.GetAll(u=>u.Priority.Name == "High").Count()
         };
         return View(homeVM);
      }

      public IActionResult Privacy() {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error() {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
