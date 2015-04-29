using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Jojatekok.XmrToAPI
{
        public static class ExtensionMethods
    {
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            if (value == null) return default(T);

            using (var stringReader = new StringReader(value)) {
                using (var jsonTextReader = new JsonTextReader(stringReader)) {
                    return (T)serializer.Deserialize(jsonTextReader, typeof(T));
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static string SerializeObject<T>(this JsonSerializer serializer, T value)
        {
            using (var stringWriter = new StringWriter(Utilities.InvariantCulture)) {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter)) {
                    serializer.Serialize(jsonTextWriter, value);
                }

                return stringWriter.ToString();
            }
        }
    }
}
