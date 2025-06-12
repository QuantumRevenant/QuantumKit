using System.Reflection;

namespace QuantumKit.Tools.IO
{
    public static class JsonUtils
    {
        public static string JsonFromEmbeddedResource(string embeddedPath)
        {
            using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedPath);
            if (stream == null)
                throw new InvalidOperationException($"No se encontró el recurso embebido: {embeddedPath}");

            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static string JsonFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo: {filePath}");

            return File.ReadAllText(filePath);
        }
    }
}
