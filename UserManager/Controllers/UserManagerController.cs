using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManager.Data.Model;
using UserManager.Models;
using UserManager.Service;

namespace UserManager.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccessRoleService _accessRoleService;

        public UserManagerController(
            IUserService userService,
            IAccessRoleService accessRoleService)
        {
            _userService = userService;
            _accessRoleService = accessRoleService;
        }

        public async Task<IActionResult> UserManager()
        {
            return View(
                new UserManagerViewModel
                {
                    Users = await _userService.SearchAsync(""),
                    AccessRoles = _accessRoleService.GetAllRoles()
                });
        }

        [HttpPost]
        public async Task<IActionResult> CheckAddUser(User user)
        {
            await _userService.CreateUserAsync(
                username: user.Username,
                password: user.Password,
                roleId: user.AccessRoleId);

            var newUser = await _userService.GetUserByUsernameAsync(user.Username);

            return Json(
                new UserViewModel
                {
                    Id = newUser.UserId,
                    Username = user.Username,
                    AccessRole = _accessRoleService.GetRoleById(user.AccessRoleId).Role
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> SearchUsers(string username)
        {
            return Json(await _userService.SearchAsync(username));
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(IFormCollection value)
        {
            Console.WriteLine(Int32.Parse(value["id"]));
            Console.WriteLine(value["username"]);
            Console.WriteLine(value["accessRoleId"]);
            var user = new User
            {
                UserId = Int32.Parse(value["id"]),
                Username = value["username"],
                AccessRoleId = Int16.Parse(value["accessRoleId"])
            };
            await _userService.UpdateUserAsync(user);

            var role = _accessRoleService.GetRoleById(Int16.Parse(value["accessRoleId"]));

            UserViewModel newUser = new UserViewModel
            {
                Id = user.UserId,
                Username = user.Username,
                AccessRole = role.Role
            };

            return Json(newUser);
        }

        // DELETE: Users/Delete/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Json(id);
        }

        [HttpGet]
        public IActionResult GetAccessRoles()
        {
            return Json(_accessRoleService.GetAllRoles());
        }
    }
}