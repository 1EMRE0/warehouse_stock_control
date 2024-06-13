using System.ComponentModel.DataAnnotations;

namespace stok_takip.Data.Models
{
	public class Admin
	{
		[Key]
        public int AdminId { get; set; }

        [StringLength(30)]  
        public string UserName { get; set; }

		[StringLength(30)]
		public string Password { get; set; }

		[StringLength(2)]
		public string AdminRole { get; set; }
    }
}
