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
        public ContainerTypeEnum typeContainer {  get; set; }
        public ContainerStatusEnum containerStatus { get; set; }
        public ContainerCategoryEnum containerCategory { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DateOfLastUpdate { get; set; } = DateTime.Now.ToLocalTime();
    }
}
