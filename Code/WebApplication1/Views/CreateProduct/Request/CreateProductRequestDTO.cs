namespace DesafioAutoglass.Views.CreateProduct.Request
{
    public class CreateProductRequestDTO
    {
        public string Description { get; set; }
        public DateTimeOffset ManufacturingDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public long ProviderCode { get; set; }
    }
}
