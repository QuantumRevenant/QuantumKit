namespace QuantumKit.Tools
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

        public static bool TryDeleteDirectory(string path, string label, bool recursive = false)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, recursive);
                    return true;
                }
                else
                {
                    Console.WriteLine($"La carpeta de {label} '{path}' no fue encontrada.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al eliminar la carpeta de {label} '{path}': {ex.Message}");
                return false;
            }
        }
    }
}
