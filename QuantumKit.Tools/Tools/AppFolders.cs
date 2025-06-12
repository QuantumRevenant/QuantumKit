using System.Runtime.InteropServices;

namespace QuantumKit.Tools.IO
{
    /// <summary>
    /// Provides platform-agnostic folder paths for user data, logs, cache, and config files.
    /// Automatically resolves locations based on the operating system.
    /// </summary>
    public static class AppFolders
    {
        /// <summary>
        /// The base name used for organization or developer folder nesting.
        /// Can be changed at runtime to reflect different branding or environments.
        /// </summary>
        public static string CompanyName { get; set; } = "QuantumRevenant";

        /// <summary>
        /// Returns the standard path for storing persistent user data for the given application.
        /// - Windows: %AppData%\CompanyName\AppName
        /// - Linux:   ~/.config/CompanyName/AppName
        /// - macOS:   ~/Library/Application Support/CompanyName/AppName
        /// </summary>
        public static string GetAppDataFolder(string appName)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(basePath, CompanyName, appName);
        }

        /// <summary>
        /// Returns the standard path for storing local (non-roaming) application data.
        /// - Windows: %LocalAppData%\CompanyName\AppName
        /// - Linux/macOS: ~/.local/share/CompanyName/AppName
        /// </summary>
        public static string GetLocalAppDataFolder(string appName)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, CompanyName, appName);
        }

        /// <summary>
        /// Returns the path used for storing log files.
        /// Default location: AppData\CompanyName\AppName\logs
        /// </summary>
        public static string GetLogsFolder(string appName)
        {
            return Path.Combine(GetAppDataFolder(appName), "logs");
        }

        /// <summary>
        /// Returns the path used for configuration files.
        /// Default location: AppData\CompanyName\AppName\config
        /// </summary>
        public static string GetConfigFolder(string appName)
        {
            return Path.Combine(GetAppDataFolder(appName), "config");
        }

        /// <summary>
        /// Returns the path used for temporary or cached files.
        /// Default location: LocalAppData\CompanyName\AppName\cache
        /// </summary>
        public static string GetCacheFolder(string appName)
        {
            return Path.Combine(GetLocalAppDataFolder(appName), "cache");
        }

        /// <summary>
        /// Ensures the specified directory exists by creating it if necessary.
        /// </summary>
        /// <param name="path">The directory path to validate or create.</param>
        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Determines if the current OS is Linux.
        /// </summary>
        public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// Determines if the current OS is macOS.
        /// </summary>
        public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// Determines if the current OS is Windows.
        /// </summary>
        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
