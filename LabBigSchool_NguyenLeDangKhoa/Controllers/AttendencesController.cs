using LabBigSchool_NguyenLeDangKhoa.DTOs;
using LabBigSchool_NguyenLeDangKhoa.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace LabBigSchool_NguyenLeDangKhoa.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendencesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendences.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exisits");
            var attendence = new Attendence
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendences.Add(attendence);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
