namespace ShoppingList.ViewModel
{
    public class UserProductViewModel
    {
        public int UserId { get; set; }
        public int ListId { get; set; }

        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string ProductBrand { get; set; }

        public string ProductQuantity { get; set; }

        public string ProductDetail1 { get; set; }

        public string CategoryName { get; set;}
    }
}
