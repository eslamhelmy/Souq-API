using System;

namespace Souq.ViewModels
{
    public class ProductCreateViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
    }
}
