
namespace WalkingWithStyle.Mvc.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string PName { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }

        //public static implicit operator ProductsViewModel(ProductsViewModel v) => throw new NotImplementedException();
    }

}
