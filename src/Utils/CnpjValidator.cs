﻿namespace test_cargo_tracker_api.src.Utils
{
    public struct CnpjValidator
    {
        private readonly string _value;

        public readonly bool IsValid;
        static readonly int[] Multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] Multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public CnpjValidator(string value)
        {
            _value = value;

            if (value == null)
            {
                IsValid = false;
                return;
            }

            var identicalDigits = true;
            var lastDigit = -1;
            var position = 0;
            var totalDigit1 = 0;
            var totalDigit2 = 0;

            foreach (var c in _value)
            {
                if (char.IsDigit(c))
                {
                    var digit = c - '0';
                    if (position != 0 && lastDigit != digit)
                    {
                        identicalDigits = false;
                    }

                    lastDigit = digit;
                    if (position < 12)
                    {
                        totalDigit1 += digit * Multiplier1[position];
                        totalDigit2 += digit * Multiplier2[position];
                    }
                    else if (position == 12)
                    {
                        var dv1 = (totalDigit1 % 11);
                        dv1 = dv1 < 2
                            ? 0
                            : 11 - dv1;

                        if ( digit != dv1)
                        {
                            IsValid = false;
                            return;
                        }

                        totalDigit2 += dv1 * Multiplier2[12];
                    }
                    else if (position == 13)
                    {
                        var dv2 = (totalDigit2 % 11);

                        dv2 = dv2 < 2
                            ? 0
                            : 11 - dv2;

                        if (digit != dv2) 
                        {
                            IsValid = false;
                            return;
                        }
                    }
                    position++;
                }
            }
            IsValid = (position == 14) && !identicalDigits;
        }

        public static implicit operator CnpjValidator(string value) => new CnpjValidator(value);

        public override string ToString() => _value;
        public static bool CnpjValidate(CnpjValidator cnpj) => cnpj.IsValid;
    }

}
