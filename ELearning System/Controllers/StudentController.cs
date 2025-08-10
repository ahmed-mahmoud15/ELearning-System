using ELearning_System.Models;
using ELearning_System.Services;
using ELearning_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ELearning_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService) {
            this.studentService = studentService;
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

       // [HttpPost]
        //public async Task<IActionResult> Create(RegisterStudentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Student student = new Student()
        //        {
                    
        //        };
        //    }
        //}
    }
}
