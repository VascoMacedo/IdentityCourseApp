using IdentityCourseApp.Data;
using IdentityCourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCourseApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        private readonly UserManager<AppUser> userManager;

        public UserController(ApplicationDBContext _dBContext, UserManager<AppUser> _userManager)
        {
            dBContext = _dBContext;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            var userList = userManager.Users.ToList();
            //var userList = dBContext.AppUser.ToList();
            var roleList = dBContext.Roles.ToList();
            var userRoleList = dBContext.UserRoles.ToList();

            foreach (var user in userList)
            {
                var role = userRoleList.FirstOrDefault(x => x.UserId == user.Id);
                if (role == null)
                {
                    user.Role = "None";
                }
                else
                {
                    user.Role = roleList.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }
            }

            return View(userList);
        }
    }
}
