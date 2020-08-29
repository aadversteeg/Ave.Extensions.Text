namespace Ave.Extensions.Text
{
    /// <summary>
    /// Adaptation of luhns algorithm of using checksums for base 32.
    /// 
    /// Ported from https://github.com/syncthing/syncthing
    /// 
    /// </summary>
    public static class Luhn32
    {
        private const string digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public static char GetCheckSum(string base32)
        {
            var factor = 1;
            var sum = 0;
            var n = 32;

            for (var i = 0; i < base32.Length; i++)
            {
                var value = digits.IndexOf(base32[i]);

                var addend = factor * value;

                factor = factor == 1 ? 2 : 1;
                addend = (addend / n) + (addend % n);
                sum += addend;
            }

            var remainder = sum % n;
            var valueCode = (n - remainder) % n;
            return digits[valueCode];
        }

        public static bool IsValid(string base32)
        {
            var indexOfLast = base32.Length - 1;
            return GetCheckSum(base32.Substring(0, indexOfLast)) == base32[indexOfLast];
        }
    }
}
