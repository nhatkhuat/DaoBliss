
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DaoBlissWebApp.Areas.Admin.Pages.Role
{
	[Authorize(Roles = "Admin")]
	public class DeleteModel : RolePageModel
	{
		public DeleteModel(RoleManager<IdentityRole> roleManager) : base(roleManager)
		{
		}

		[BindProperty]
		public IdentityRole Role { get; set; }

		public async Task<IActionResult> OnGetAsync(string roleid)
		{
			if (string.IsNullOrEmpty(roleid))
			{
				return NotFound("Role not found");
			}
			 Role = await _roleManager.FindByIdAsync(roleid);
			
			if (Role == null)
			{
				return NotFound("Role not found");
			}
			return Page();

		}

		public async Task<IActionResult> OnPostAsync(string roleid)
		{
			if (roleid == null) return NotFound("Role not found");
			Role = await _roleManager.FindByIdAsync(roleid);
			if (Role == null) return NotFound("Role not found");


			var result = await _roleManager.DeleteAsync(Role);

			if (result.Succeeded)
			{
				StatusMessage = $"Role '{Role.Name}' deleted successfully.";
				return RedirectToPage("./Index");
			}
			else
			{
				result.Errors.ToList().ForEach(error =>
						ModelState.AddModelError(string.Empty, error.Description)
				);
			}
			return Page();
		}
	}
}
