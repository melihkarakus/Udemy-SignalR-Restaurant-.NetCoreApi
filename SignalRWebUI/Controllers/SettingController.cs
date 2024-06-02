using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDtos userEditDtos = new UserEditDtos();
            userEditDtos.Surname = values.Surname;
            userEditDtos.Name = values.Name;
            userEditDtos.UserName = values.UserName;
            userEditDtos.Mail = values.Email;

            return View(userEditDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDtos userEditDtos)
        {
            if (userEditDtos.Password == userEditDtos.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDtos.Name;
                user.Surname = userEditDtos.Surname;
                user.Email = userEditDtos.Mail;
                user.UserName = userEditDtos.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDtos.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
