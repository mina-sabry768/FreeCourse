using static Domin.Entity.Helper;
using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Constants;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Infarstuructre.Seeds
{
    public static class DefaultUser
    {
        

        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = UserNameBasic,
                Email = EmailBasic,
                Name = NameBasic,
                ImageUser = "user1.jpg",
                ActiveUser = true,
                EmailConfirmed = true
            };
            var User = userManager.FindByEmailAsync(DefaultUser.Email);
            if (User.Result == null)
            {
                await userManager.CreateAsync(DefaultUser, PasswordBasic);
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { Roles.Basic.ToString() });

            }
        }


        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = UserName,
                Email = Email,
                Name = Name,
                ImageUser = "user1.jpg",
                ActiveUser = true,
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, Password);
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { Roles.SuperAdmin.ToString() });

            }

            await roleManager.SeedClaimsAsync(); 
        }


        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClamis = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePerMissionsFromModule(module);
            
            foreach (var permission in allPermissions)
            {
                if (!allClamis.Any(x => x.Type == Permission && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(Permission, permission));
            }
        }
    }
}
