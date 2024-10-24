using System.ComponentModel.DataAnnotations;

namespace test_cargo_tracker_api.src.Utils
{
    public class CpfOrCnpjRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (test_cargo_tracker_api.src.Models.CustomerModel)validationContext.ObjectInstance;

            if (string.IsNullOrEmpty(customer.cpf) && string.IsNullOrEmpty(customer.cnpj))
            {
                return new ValidationResult("Either CPF or CNPJ must be provided.");
            }

            return ValidationResult.Success;
        }
    }
}
