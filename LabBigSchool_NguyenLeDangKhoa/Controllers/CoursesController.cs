using LabBigSchool_NguyenLeDangKhoa.Models;
using LabBigSchool_NguyenLeDangKhoa.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_NguyenLeDangKhoa.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: Courses
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public object LecturerID { get; private set; }
        public DateTime DateTime { get; private set; }
        public byte CategoryId { get; private set; }
        public string Place { get; private set; }

        [Authorize]
        public ActionResult Create()
        {
           
            {
                var viewModel = new CourseViewModel
                {
                    Categories = _dbContext.Categories.ToList()
                };
                return View(viewModel);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var course = new Course();
            {
                LecturerID = User.Identity.GetUserId();
                DateTime = viewModel.GetDateTime();
                CategoryId = viewModel.Category;
                Place = viewModel.Place;
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAcTion("Index", "Home");
        }

        private ActionResult RedirectToAcTion(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}