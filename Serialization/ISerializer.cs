using System;

namespace Serialization
{
    public interface ISerializer
    {
        string ContentType { get; }

        object Deserialize(Type returnType, byte[] bytes);

        byte[] Serialize(object objectRoot, Type objectType);
    }
}