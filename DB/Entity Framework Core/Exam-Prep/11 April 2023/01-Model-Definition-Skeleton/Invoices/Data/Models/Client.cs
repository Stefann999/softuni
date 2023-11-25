using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            Invoices = new HashSet<Invoice>();
            ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string NumberVat { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
