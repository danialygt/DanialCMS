using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Identity
{
    public class CustomPasswordValidator : PasswordValidator<User>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {

            var baseResult = await base.ValidateAsync(manager, user, password);
            var erros = baseResult.Succeeded ? new List<IdentityError>()
                : baseResult.Errors.ToList();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                erros.Add(new IdentityError
                {
                    Code = "",
                    Description = "کلمه عبور نباید شامل نام کاربری باشد."
                });
            }

            // inja vadilate ahto minevisi!


            return await Task.FromResult(erros.Count == 0 ? IdentityResult.Success :
                IdentityResult.Failed(erros.ToArray()));
        }
    }
}
