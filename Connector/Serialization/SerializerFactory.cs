using System;

namespace Serialization
{
    public static class SerializerFactory
    {
        public static ISerializer Default = new XmlSerializer();

        public static ISerializer GetSerializer(string contentType)
        {
            ISerializer result;
            if (contentType != null)
            {
                if (contentType.EndsWith("/xml", StringComparison.OrdinalIgnoreCase))
                {
                    result = new XmlSerializer();
                    return result;
                }
                if (contentType.EndsWith("/json", StringComparison.OrdinalIgnoreCase))
                {
                    result = new JsonSerializer();
                    return result;
                }
            }
            result = Default;
            return result;
        }
    }
}