using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConfigServer.Extensions
{
    public static class YamlConfigurationExtensions
    {
        public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, string path, bool optional = false, bool reloadOnChange = false)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            if (!File.Exists(path) && !optional)
            {
                throw new FileNotFoundException($"The file '{path}' was not found.", path);
            }

            if (File.Exists(path))
            {
                var yamlText = File.ReadAllText(path);
                var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(yamlText);

                // Convert Dictionary<string, object> to IEnumerable<KeyValuePair<string, string?>>
                var inMemoryCollection = ConvertToKeyValuePair(yamlObject);
                builder.AddInMemoryCollection(inMemoryCollection);
            }

            return builder;
        }

        private static IEnumerable<KeyValuePair<string, string?>> ConvertToKeyValuePair(Dictionary<string, object> dictionary)
        {
            var keyValuePairs = new List<KeyValuePair<string, string?>>();

            foreach (var kvp in dictionary)
            {
                keyValuePairs.Add(new KeyValuePair<string, string?>(kvp.Key, kvp.Value?.ToString()));
            }

            return keyValuePairs;
        }
    }
}
