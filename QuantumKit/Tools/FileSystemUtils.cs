namespace QuantumKit.Tools.IO
{
    public class FileSystemUtils
    {
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
