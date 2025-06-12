using System.Text.RegularExpressions;

namespace QuantumKit.Tools.TextUtils
{
    public static class TextUtils
    {
        public static bool MatchAnyRegex(string input, IEnumerable<string> regexList, bool caseSensitive)
        {
            var options = caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;

            foreach (var pattern in regexList)
            {
                if (string.IsNullOrWhiteSpace(pattern)) continue;

                if (Regex.IsMatch(input, pattern, options))
                    return true;
            }

            return false;
        }

        public static bool IsValidPathFormat(string path)
        {
            try
            {
                var fullPath = Path.GetFullPath(path);
                var root = Path.GetPathRoot(path);
                return !string.IsNullOrEmpty(root);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidFileNameFormat(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            return fileName.All(c => !invalidChars.Contains(c));
        }
    }
}
