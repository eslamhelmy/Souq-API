using System;

namespace Souq.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public string Image { get; set; }
    }
}
