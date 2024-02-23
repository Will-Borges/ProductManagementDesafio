namespace DesafioAutoglass.Core.Domain.Entities.Providers
{
    public class Provider
    {
        public long Code { get; }
        public string? Description { get; }
        public string? CNPJ { get; }


        public Provider() { }

        public Provider(long code)
        {
            Code = code;
        }

        public Provider(string? description, string? cnpj)
        {
            Code = 0;
            Description = description;
            CNPJ = cnpj;
        }

        public Provider(long code, string? description, string? cnpj)
        {
            Code = code;
            Description = description;
            CNPJ = cnpj;
        }
    }
}
