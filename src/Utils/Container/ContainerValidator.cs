using System.Text.RegularExpressions;

namespace test_cargo_tracker_api.src.Utils.Container
{
    public class ContainerValidator
    {
        public bool IsValidContainerNumber(string containerNumber)
        {
            string pattern = @"^[A-Z]{4}\d{7}$";

            return Regex.IsMatch(containerNumber, pattern);
        }
    }
}
