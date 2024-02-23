namespace DesafioAutoglass.Core.Domain.Entities.Products
{
    using DesafioAutoglass.Core.Domain.Entities.Providers;

    public class Product
    {
        public long Code { get; }
        public string Description { get; }
        public ProductStatus Status { get; private set; }
        public DateTimeOffset? ManufacturingDate { get; }
        public DateTimeOffset? ExpirationDate { get; }
        public Provider? Provider { get; set; }


        public Product() { }

        public Product(
            long code, 
            string description,
            int status,
            DateTimeOffset? manufacturingDate,
            DateTimeOffset? expirationDate,
            long providerCode)
        {
            Code = code;
            Description = description;
            Status = (ProductStatus)status;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
        }

        public Product(
                    string description,
                    DateTimeOffset? manufacturingDate,
                    DateTimeOffset? expirationDate)
        {
            Code = 0;
            Description = description;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            Status = ProductStatus.Ativo; 
        }


        public bool ManufacturingDateIsValid(DateTimeOffset? manufacturingDate, DateTimeOffset? expirationDate)
        {
            if (manufacturingDate != null && expirationDate != null)
                return manufacturingDate < expirationDate;

            return true;
        }

        public void InsertProvider(Provider provider)
        {
            Provider = provider;
        }
    }
}