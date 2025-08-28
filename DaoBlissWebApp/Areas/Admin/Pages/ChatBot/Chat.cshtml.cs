using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DaoBlissWebApp.Areas.Admin.Pages.ChatBot
{
	[Authorize(Roles = "Admin")]
	public class ChatModel : PageModel
    {
		private readonly IWebHostEnvironment _env;
		private readonly string _filePath;

		public ChatModel(IWebHostEnvironment env)
		{
			_env = env;
			_filePath = Path.Combine(_env.WebRootPath, "chatbot", "data.txt");
		}

		[BindProperty]
		public string DataContent { get; set; }

		public void OnGet()
		{
			if (System.IO.File.Exists(_filePath))
			{
				DataContent = System.IO.File.ReadAllText(_filePath);
			}
			else
			{
				DataContent = "";
			}
		}

		public IActionResult OnPostSave()
		{
			System.IO.File.WriteAllText(_filePath, DataContent);
			TempData["Message"] = "Đã lưu dữ liệu thành công!";
			return RedirectToPage();
		}
	}
}
