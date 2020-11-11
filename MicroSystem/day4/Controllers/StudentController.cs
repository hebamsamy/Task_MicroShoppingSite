using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShopping.Services;
using MicroShopping.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroShopping.Controllers
{
    public class StudentController : Controller
    {
        ////StudentService studentService;
        //private readonly IServices<Student> services;
        //private readonly IServices<Department> deptservices;
        //public StudentController(IServices<Student> services,IServices<Department> deptservices)
        //{
        //    this.services = services;
        
        //}
        //    public IActionResult Index()
        //{
        //    return View(services.GetAll());
        //}
        //public IActionResult Calc(int x,int y)
        //{
        //    return Content(x+y.ToString());
        //}
        //public IActionResult AddStudent()
        //{
        //    ViewBag.Depts = deptservices.GetAll();
        //    return View(new Student());
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult AddStudent(Student student)
        //{
        //    ViewBag.Depts = deptservices.GetAll();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            services.Add(student);
        //            return RedirectToAction("Index");
        //        }
        //        catch(Exception ex)
        //        {
        //            ModelState.AddModelError("", ex.Message);
        //            return View(student);
        //        }
        //    }
            
           
        //    return View(student);
        //}
    }
}