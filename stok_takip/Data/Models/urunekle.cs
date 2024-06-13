﻿namespace stok_takip.Data.Models
{
    public class urunekle
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }
    }
}
