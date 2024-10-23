using System.ComponentModel.DataAnnotations;

namespace test_cargo_tracker_api.src.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
