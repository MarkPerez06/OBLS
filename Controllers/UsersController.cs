﻿using OBLS.Data;
using OBLS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;

namespace OBLS.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger, SignInManager<IdentityUser> signInManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            var model = _context.Users.ToList();
            var Roles = _context.Roles.ToList().OrderBy(m => m.Name);
            ViewBag.Role = new List<IdentityRole>(Roles);
            ViewBag.Roles = new SelectList(Roles, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(string Id, string Email, string PhoneNumber, string Password, string ConfirmPassword, string EmailConfirmed, string RoleId)
        {
            IdentityUser user = await _signInManager.UserManager.FindByIdAsync(Id);
            if (user != null)
            {
                if (EmailConfirmed == "True")
                {
                    user.EmailConfirmed = true;
                }
                else
                {
                    user.EmailConfirmed = false;
                }

                if ((Password != "" && Password != null) && (ConfirmPassword != "" && ConfirmPassword != null))
                {
                    if (Password == ConfirmPassword)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, Password);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Password and Confirm Password doesn't match!" });
                    }
                }
                user.Email = Email;
                user.NormalizedEmail = Email.ToUpper();
                user.PhoneNumber = PhoneNumber;
                user.SecurityStamp = RoleId != null ? RoleId : "bb9825cc-d2d1-4121-ace8-7335225f2c89";
                await _signInManager.UserManager.UpdateAsync(user);

                return Json(new { success = true, message = "User was successfully updated!" });

            }
            else
            {
                return Json(new { success = false, message = "User doesn't exists!" });
            }
        }
    }
}