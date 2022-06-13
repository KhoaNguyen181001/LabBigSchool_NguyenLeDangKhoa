using LabBigSchool_NguyenLeDangKhoa.DTOs;
using LabBigSchool_NguyenLeDangKhoa.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LabBigSchool_NguyenLeDangKhoa.Controllers
{

    public class FollowingsController : ApiController 
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollwingDto follwingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == follwingDto.FolloweeId))
                return BadRequest("Following already exisits");
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = follwingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}