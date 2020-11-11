using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShopping.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroShopping.Controllers
{
    
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(string Adminname, string password)
        {
           
            var user = new IdentityUser
            {
                UserName = Adminname,
                Email = "",
                
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {

                var Roleresult = await _userManager.AddToRoleAsync(user, "Admin");
                if (Roleresult.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
            }

            return RedirectToAction("Index","Account");
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Account");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}