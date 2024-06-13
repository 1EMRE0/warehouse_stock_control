using System.ComponentModel.DataAnnotations;

namespace stok_takip.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="kategori adı boş bırakılamaz !")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public bool Status {  get; set; }

        public List<Food> Foods { get; set;}
    }
}
