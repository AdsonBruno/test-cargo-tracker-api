using System.ComponentModel.DataAnnotations;
using test_cargo_tracker_api.src.Enums.Container;

namespace test_cargo_tracker_api.src.Models.Container
{
    public class ContainerModel
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ContainerNumber { get; set; }
        public ContainerTypeEnum TypeContainer {  get; set; }
        public ContainerStatusEnum ContainerStatus { get; set; }
        public ContainerCategoryEnum ContainerCategory { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfLastUpdate { get; set; } = DateTime.UtcNow;
    }
}
