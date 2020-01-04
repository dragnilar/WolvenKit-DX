using System.Collections.Generic;
using ProtoBuf;

namespace WolvenKit.Interfaces
{
    [ProtoContract]
    public class ProtoList<T>
    {
        [ProtoMember(1)]
        public List<T> innerlist;
    }
}
