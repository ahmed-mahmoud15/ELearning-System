using System.Security.Claims;
using ELearning_System.Models;
using ELearning_System.Services;
using ELearning_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ELearning_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IUserService userService;
        public StudentController(IStudentService studentService, IUserService userService)
        {
            this.studentService = studentService;
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await studentService.GetAllStudentsAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Bio = model.Bio,
                    PhotoPath = model.PhotoPath,
                    BirthDate = model.BirthDate,
                    IdentityId = HttpContext.Session.GetString("user_id")
                };

                await userService.AddUserAsync(user);

                Student student = new Student() { 
                    Id = user.Id,
                    GitHubAccount = model.GitHubAccount
                };

                await studentService.AddStudentAsync(student);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
