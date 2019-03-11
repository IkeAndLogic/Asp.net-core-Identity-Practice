using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly RoleManager<Role> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }



        public IActionResult WelcomePage()
        {
            WelcomePageViewModel vm = new WelcomePageViewModel();
            return View(vm);
        }



        public IActionResult Register()
        {
            List<Role> AllRoles = _roleManager.Roles.ToList();
            RegisterViewModel registerViewModel = new RegisterViewModel()
            {
                EmployeeRoles = new SelectList(_roleManager.Roles.OrderBy(n => n.Name))
            };

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    MiddleName = registerViewModel.MiddleName,

                    Dob = registerViewModel.Dob,

                    StreetNumber = registerViewModel.StreetNumber,
                    StreetName = registerViewModel.StreetName,
                    City = registerViewModel.City,
                    ZipCode = registerViewModel.ZipCode,

                    SSN = registerViewModel.SSN,
                    SsnConfirm = registerViewModel.SsnConfirm,

                    LicNumber = registerViewModel.LicNumber,
                    LicIssue = registerViewModel.LicIssue,
                    LicExpire = registerViewModel.LicExpire,

                    UserName = registerViewModel.UserName,
                    MedCardNumber = registerViewModel.MedCardNumber,
                    MedIssue = registerViewModel.MedIssue,
                    MedExpire = registerViewModel.MedExpire,
                };

                var result = await _userManager.CreateAsync(applicationUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, registerViewModel.RoleToBeAssigned);

                    // await _userManager.AddToRoleAsync(applicationUser, applicationUser.Title.ToString());           
                    await _signInManager.SignInAsync(applicationUser, false);
                    return Redirect("/Employee/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }

        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect("/Account/WelcomePage");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return View(loginViewModel);
                }
            }
            return View(loginViewModel);

        }

        [HttpPost]
        public async Task <IActionResult> Logout()
        {
           //var  returnURL = returnUrl ?? Url.Content("~/");
             await _signInManager.SignOutAsync();


            return Content("Account/Login");
                //return LocalRedirect(returnUrl);
                //return Redirect("/Account/Login");
                //return View();
            
        }

        public IActionResult Remove()
        {
            var users = _userManager.Users.OrderBy(o=> o.LastName).ToList();
            RemoveViewModel removeViewModel = new RemoveViewModel(users);
            return View(removeViewModel);
        }

        [HttpPost]
        public async Task <IActionResult> Remove(int[] UserIds)
        {
            if (UserIds != null)
            {
                    foreach (int userId in UserIds)
                {
                    var userToBeRemoved = await _userManager.FindByIdAsync(userId.ToString());

                    var RolesRelatedToUser = await _userManager.GetRolesAsync(userToBeRemoved);


                    var result = await _userManager.DeleteAsync(userToBeRemoved);

                    if (!result.Succeeded)
                    {
                        throw new System.ArgumentException("Parameter cannot be null", "original");
                    }

                    await _userManager.RemoveFromRolesAsync(userToBeRemoved, RolesRelatedToUser);

                }

                return Redirect("/Home/Index");
            }
            return View();
        }    


    }
}