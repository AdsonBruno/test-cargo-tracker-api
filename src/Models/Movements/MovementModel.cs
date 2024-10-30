using Microsoft.AspNetCore.Components.Forms;
using test_cargo_tracker_api.src.Models.Container;

namespace test_cargo_tracker_api.src.Models.Movements
{
    public class MovementModel
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public string Type { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
