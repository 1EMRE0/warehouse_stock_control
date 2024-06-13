using Microsoft.AspNetCore.Mvc;
using stok_takip.Repositories;

namespace stok_takip.ViewComponents
{
	public class CategoryGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepository categoryRepository = new CategoryRepository();
			var categorlist = categoryRepository.TList();
			return View(categorlist);
		}
	}
}
