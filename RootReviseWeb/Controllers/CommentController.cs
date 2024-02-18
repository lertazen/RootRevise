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
      public IActionResult GetComments(int issueId) {
         List<Comment> commentsList = _unitOfWork.CommentRepository.GetAll(c => c.IssueId == issueId).ToList();
         return View(commentsList);
      }

      [HttpPost]
      public IActionResult AddComment(Comment comment) {
         if(ModelState.IsValid) {
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Save();
         } else {
            return View();
         }
         
         return RedirectToAction(nameof(GetComments));
      }
   }
}
