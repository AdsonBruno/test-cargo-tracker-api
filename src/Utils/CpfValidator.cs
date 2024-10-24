using System.Globalization;

namespace test_cargo_tracker_api.src.Utils
{
    public class CpfValidator
    {
        private bool ValidateCpf(String cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }


            for (int j = 0; j < 10; j++)
            {
                if (new string(j.ToString()[0], 11) == cpf)
                {
                    return false;
                }
            }

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            }

            int rest = sum % 11;

            if (rest < 2)
            {
                rest = 0;
            } else
            {
                rest = 11 - rest;
            }

            string digit = rest.ToString();
            tempCpf += digit;

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;

            if (rest < 2)
            {
                rest = 0;
            } else
            {
                rest = 11 - rest;
            }
            digit += rest.ToString();

            return cpf.EndsWith(digit);
        }

        public static bool IsValid(string cpf)
        {
            CpfValidator validator = new CpfValidator();
            
            return validator.ValidateCpf(cpf);
        }
    }

}
