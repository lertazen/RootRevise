using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;
using RootRevise.Models.ViewModels;
using RootRevise.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RootReviseWeb.Controllers {
   [Authorize(Roles = SD.Role_Admin)]
   public class UserController : Controller {
      private readonly IUnitOfWork _unitOfWork;
      private readonly UserManager<IdentityUser> _userManager;
      private readonly RoleManager<IdentityRole> _roleManager;

      public UserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
         _unitOfWork = unitOfWork;
         _userManager = userManager;
         _roleManager = roleManager;
      }
      public IActionResult Index() {
         return View();
      }

      public IActionResult Edit(string userId) {
         UserVM userVM = new() {
            ApplicationUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId),
            RoleList = _roleManager.Roles.Select(i => new SelectListItem {
               Text = i.Name,
               Value = i.Name
            })
         };
         return View(userVM);
      }

      [HttpPost]
      public IActionResult Edit(UserVM userVM) {
         ApplicationUser oldUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userVM.ApplicationUser.Id);
         string oldRole =
            _userManager.GetRolesAsync(oldUser).GetAwaiter().GetResult().FirstOrDefault();

         if (ModelState.IsValid) {
            oldUser.Name = userVM.ApplicationUser.Name;
            oldUser.UserName = userVM.ApplicationUser.UserName;
            oldUser.Email = userVM.ApplicationUser.Email;

            _unitOfWork.ApplicationUserRepository.Update(oldUser);
            _unitOfWork.Save();
            if (oldRole != userVM.ApplicationUser.Role) {
               _userManager.RemoveFromRoleAsync(oldUser, oldRole).GetAwaiter().GetResult();
               _userManager.AddToRoleAsync(oldUser, userVM.ApplicationUser.Role).GetAwaiter().GetResult();
            } 
         } else {
            userVM.RoleList = _roleManager.Roles.Select(i => new SelectListItem {
               Text = i.Name,
               Value = i.Name
            });

            return View(userVM);
         }

         return RedirectToAction(nameof(Index));
      }

      #region API Call
      [HttpGet]
      public IActionResult GetAllUsers() {
         List<ApplicationUser> userList = _unitOfWork.ApplicationUserRepository.GetAll().ToList();

         foreach (var user in userList) {
            user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();
         }
         return Json(new { data = userList });
      }
      #endregion

   }
}
