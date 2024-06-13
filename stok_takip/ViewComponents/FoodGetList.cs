using Microsoft.AspNetCore.Mvc;
using stok_takip.Repositories;

namespace stok_takip.ViewComponents
{
	public class FoodGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodlist = foodRepository.TList();
			return View(foodlist);
		}


	}
}
