namespace DesafioAutoglass.Views.UpdateProduct.Request
{
    public class UpdateProductRequestDTO
    {
        public long Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTimeOffset ManufacturingDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public long ProviderCode { get; set; }
    }
}
