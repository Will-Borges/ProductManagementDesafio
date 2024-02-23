namespace DesafioAutoglass.Core.Domain.DesafioAutoglass.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("providers")]
    public class ProviderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Code { get; set; }
        public string? Description { get; set; }
        public string? CNPJ { get; set; }
    }
}
