using Nhom15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
	public class MenuTopViewComponent : ViewComponent
	{
		private readonly Nhom15Context _context;
		public MenuTopViewComponent(Nhom15Context context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = _context.TbMenus.Where(m => (bool)m.IsActive).
				OrderBy(m => m.Position).ToList();
			return await Task.FromResult<IViewComponentResult>(View(items));
		}
	}
}
