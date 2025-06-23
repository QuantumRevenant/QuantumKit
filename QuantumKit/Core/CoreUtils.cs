namespace QuantumKit.Core
{
    public static class CoreUtils
    {
        public static string GetVersionString(int major, int minor, int patch, string? suffix = null)
        {
            var version = $"{major}.{minor}.{patch}";
            return string.IsNullOrEmpty(suffix) ? version : $"{version}-{suffix}";
        }
        public static string GetVersionStringFromTuple((int Major, int Minor, int Patch) version, string? suffix = null)
        {
            return GetVersionString(version.Major, version.Minor, version.Patch, suffix);
        }
        public static void Toggle(ref bool value)
        {
            value = !value;
        }
    }
}
