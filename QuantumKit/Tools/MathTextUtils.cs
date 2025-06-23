namespace QuantumKit.Tools.Number
{
    public static class MathTextUtils
    {
        public static int GetLastDigits(int number, int count = 1)
        {
            if (count <= 0) return 0;

            var str = number.ToString();
            var len = str.Length;

            var span = str.AsSpan(len >= count ? len - count : 0);
            return int.Parse(span);
        }

        public static int SumDigits(int number)
        {
            number = Math.Abs(number);
            int sum = 0;

            for (; number > 0; number /= 10)
                sum += number % 10;

            return sum;
        }

        public static string RepeatPatternElement(string[] pattern, int step, int groupSize = 1)
        {
            if (pattern == null || pattern.Length == 0 || groupSize <= 0)
                return string.Empty;

            int groupIndex = step / groupSize;
            int index = ((groupIndex % pattern.Length) + pattern.Length) % pattern.Length;
            return pattern[index];
        }
    }
}
