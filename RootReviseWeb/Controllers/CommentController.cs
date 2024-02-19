using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootReviseWeb.Controllers {
   public class CommentController : Controller {
      private readonly IUnitOfWork _unitOfWork;

      public CommentController(IUnitOfWork unitOfWork) {
         _unitOfWork = unitOfWork;
      }

      public IActionResult Index() { 
         List<Comment> commentsList = _unitOfWork.CommentRepository.GetAll(includeProperties: "Author").ToList();
         return View(commentsList);
      }

      [HttpGet]
      public IActionResult GetCommentsByIssueId(int issueId) {
         List<Comment> commentsList = _unitOfWork.CommentRepository.GetAll(c => c.IssueId == issueId, includeProperties: "Author").ToList();
         return Json(new { data = commentsList });
      }

      [Authorize]
      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult AddComment(Comment comment) {
         if(ModelState.IsValid) {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            comment.AuthorId = userId;
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Save();
            TempData.Add("success", "The comment has been created.");
            return Json(new {success = true, message = "The comment has been created."});
         } else {
            TempData.Add("error", "Something went wrong. Creating comment failed");
            return Json(new {success=false, message="Something went wrong. Creating comment failed."});
         }
      }
   }
}
