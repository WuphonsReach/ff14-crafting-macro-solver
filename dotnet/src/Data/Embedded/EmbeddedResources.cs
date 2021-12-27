using System;
using System.IO;
using Newtonsoft.Json;

namespace Data.Embedded
{
    public static class EmbeddedResources
    {
        public static Stream ReadAsStream<TResourceLocation>(
            string filename
            ) where TResourceLocation : class
        {
            var resourceAssembly = typeof(TResourceLocation).Assembly;
            var namespaceLocation = typeof(TResourceLocation).Namespace;
            var manifestResourceFilename = $"{namespaceLocation}.{filename}";
            var stream = resourceAssembly.GetManifestResourceStream(manifestResourceFilename);
            if (stream is null)
                throw new Exception(
                    $"Failed to read embedded resource at '{manifestResourceFilename}'."
                );
            return stream;
        }

        public static T ReadJson<TResourceLocation, T>(
            string filename,
            JsonSerializer jsonSerializer = null
            ) where TResourceLocation : class
        {
            jsonSerializer ??= new JsonSerializer();
            using var stream = ReadAsStream<TResourceLocation>(filename);
            using var reader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(reader);
            return jsonSerializer.Deserialize<T>(jsonReader);
        }
    }
}