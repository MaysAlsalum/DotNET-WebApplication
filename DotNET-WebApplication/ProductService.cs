namespace DotNET_WebApplication
{
    public interface IProductService
    {
        string GetProductName();
    }

    public class ProductService : IProductService
    {
        public string GetProductName() => "Example Product";
    }
}