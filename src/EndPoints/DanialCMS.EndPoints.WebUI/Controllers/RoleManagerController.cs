using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.EndPoints.WebUI.Infrastructures.Identity;
using DanialCMS.EndPoints.WebUI.Models.RoleManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }


        public IActionResult Index() => RedirectToAction(nameof(List));


        public IActionResult List(List<string> errors = null)
        {
            AddErrosToModelState(errors);
            var roles = _roleManager.Roles.ToList();
            if(!roles.Any())
            {
                ModelState.AddModelError("", "نقشی وجود ندارد");
            }
            return View(roles);
        }
        public IActionResult Add() => View();
        
        [HttpPost]
        public async Task<IActionResult> Add(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_roleManager.RoleExistsAsync(model.Name).Result)
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(List));
                    }
                    else
                    {
                        AddErrosToModelState(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "این نقش وجود دارد");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(List));
                }
                AddErrosToModelState(result);
            }
            else
            {
                ModelState.AddModelError("", "نقش یافت نشد");
            }
            return RedirectToAction(nameof(List), new { errors =
                GetErrosFromModelState()});
        }

        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                var model = new UpdateRoleViewModel()
                {
                    Name = role.Name,
                    OldName = role.Name,
                    Id = role.Id,
                };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "نقش یافت نشد");
            }
            return RedirectToAction(nameof(List), new {
                errors = GetErrosFromModelState() });
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role != null)
            {
                if (!_roleManager.RoleExistsAsync(model.Name).Result)
                {
                    role.Name = model.Name;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(List));
                    }
                    else
                    {
                        AddErrosToModelState(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "نقش  با این نام ثبت شده.");
                }
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "نقش پیدا نشد");
                return RedirectToAction(nameof(List), new
                {
                    errors = GetErrosFromModelState()
                });
            }            
        }







        private List<string> GetErrosFromModelState()
        {
            var modelErrors = new List<string>();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return modelErrors;
        }
        private void AddErrosToModelState(List<string> errors)
        {
            if (errors != null)
            {
                foreach (var err in errors)
                {
                    ModelState.AddModelError("", err);
                }
            }
        }
        private void AddErrosToModelState(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }
        }
    }
}
