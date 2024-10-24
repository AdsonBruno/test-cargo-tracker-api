using System.ComponentModel.DataAnnotations;
using test_cargo_tracker_api.src.Utils;

namespace test_cargo_tracker_api.src.Models
{
    [CpfOrCnpjRequired]
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string? cpf { get; set; }
        public string? cnpj { get; set; }
        public DateTime CreatedTimestamp { get; set; } 
    }
}
