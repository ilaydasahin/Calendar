using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCalendar.Data.Entity;
using WeddingCalendar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeddingCalendar.Controllers
{
    [Authorize(Roles = "DugunSahibi, Organizator")]
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            if (user == null)
            {
                return View("Error");
            }

            if (_userManager.IsInRoleAsync(user, "DugunSahibi").Result)
            {
                var organizators = _userManager.Users.Where(x => x.IsOrganizator);
                DugunSahibiViewModel model = new DugunSahibiViewModel()
                {
                    User = user,
                    Organizators = organizators,
                    OrganizatorsSelectList = organizators.Select(n => new SelectListItem { 
                        Value = n.Id,
                        Text = $"Organizator. {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("DugunSahibi", model);
            }
            else
            {
                var organizators = _userManager.Users.Where(x => x.IsOrganizator);
                DugunSahibiViewModel model = new DugunSahibiViewModel()
                {
                    User = user,
                    Organizators = organizators,
                    OrganizatorsSelectList = organizators.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Organizator. {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Organizator", model);
            }

        }

        public IActionResult DugunSahibi()
        {
            return View();
        }

        [Authorize(Roles = "Organizator")]
        public IActionResult Organizator()
        {
            return View();
        }
    }
}