namespace DesafioAutoglass.Core.Domain.DesafioAutoglass.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("products")]
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Status { get; set; }

        [Column("Manufacturing_Date")]
        public DateTimeOffset? ManufacturingDate { get; set; }

        [Column("Expiration_Date")]
        public DateTimeOffset? ExpirationDate { get; set; }

        [Required]
        [Column("Provider_Code")]
        public long ProviderCode { get; set; }
    }
}
