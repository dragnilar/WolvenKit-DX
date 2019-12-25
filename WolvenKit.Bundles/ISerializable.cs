using System.IO;

namespace WolvenKit.Bundles
{
    internal interface ISerializable
    {
        void Deserialize(BinaryReader reader);
        void Serialize(BinaryWriter writer);
    }
}