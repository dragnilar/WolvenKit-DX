using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WolvenKit.CR2W.Types;

namespace WolvenKit.CR2W
{
    public class CR2WFile
    {
        public static readonly byte[] IDString = {
            67,
            82,
            50,
            87
        };

        private uint headerOffset;
        public List<CLocalizedString> LocalizedStrings = new List<CLocalizedString>();
        public List<string> UnknownTypes = new List<string>();

        public CR2WFile()
        {
            headers = new List<CR2WHeaderData>();
            for (var index = 0; index < 10; ++index)
                headers.Add(new CR2WHeaderData());
            strings = new List<CR2WHeaderString>();
            strings.Add(new CR2WHeaderString());
            handles = new List<CR2WHeaderHandle>();
            chunks = new List<CR2WChunk>();
            block4 = new List<CR2WHeaderBlock4>();
            block6 = new List<CR2WHeaderBlock6>();
            block7 = new List<CR2WHeaderBlock7>();
            FileVersion = 162U;
        }

        public CR2WFile(BinaryReader file)
        {
            Read(file);
        }

        public uint FileVersion { get; set; }

        public uint unk2 { get; set; }

        public uint unk3 { get; set; }

        public uint unk4 { get; set; }

        public uint unk5 { get; set; }

        public uint cr2wsize { get; set; }

        public uint buffersize { get; set; }

        public uint unk6 { get; set; }

        public uint unk7 { get; set; }

        public List<CR2WHeaderData> headers { get; set; }

        public List<CR2WHeaderString> strings { get; set; }

        public List<CR2WHeaderHandle> handles { get; set; }

        public List<CR2WHeaderBlock4> block4 { get; set; }

        public List<CR2WChunk> chunks { get; set; }

        public List<CR2WHeaderBlock6> block6 { get; set; }

        public List<CR2WHeaderBlock7> block7 { get; set; }

        public byte[] bufferdata { get; set; }

        public string FileName { get; set; }

        public ILocalizedStringSource LocalizedStringSource { get; set; }

        public IVariableEditor EditorController { get; set; }

        public string GetLocalizedString(uint val)
        {
            return LocalizedStringSource != null ? LocalizedStringSource.GetLocalizedString(val) : null;
        }

        public void CreateVariableEditor(CVariable editvar, EVariableEditorAction action)
        {
            if (EditorController == null)
                return;
            EditorController.CreateVariableEditor(editvar, action);
        }

        public void Read(BinaryReader file)
        {
            var numArray = file.ReadBytes(4);
            if (!IDString.SequenceEqual(numArray))
                throw new InvalidFileTypeException("Invalid file type");
            FileVersion = file.ReadUInt32();
            unk2 = file.ReadUInt32();
            unk3 = file.ReadUInt32();
            unk4 = file.ReadUInt32();
            unk5 = file.ReadUInt32();
            cr2wsize = file.ReadUInt32();
            buffersize = file.ReadUInt32();
            unk6 = file.ReadUInt32();
            unk7 = file.ReadUInt32();
            headers = new List<CR2WHeaderData>();
            for (var index = 0; index < 10; ++index)
            {
                var cr2WheaderData = new CR2WHeaderData(file);
                headers.Add(cr2WheaderData);
                if (cr2WheaderData.size > 0U && index > 6)
                    Debugger.Break();
            }

            var offset1 = headers[0].offset;
            strings = new List<CR2WHeaderString>();
            var offset2 = headers[1].offset;
            var size1 = headers[1].size;
            file.BaseStream.Seek(offset2, SeekOrigin.Begin);
            for (var index = 0; (long) index < (long) size1; ++index)
            {
                var cr2WheaderString = new CR2WHeaderString(file);
                cr2WheaderString.ReadString(file, offset1);
                strings.Add(cr2WheaderString);
            }

            handles = new List<CR2WHeaderHandle>();
            var offset3 = headers[2].offset;
            var size2 = headers[2].size;
            file.BaseStream.Seek(offset3, SeekOrigin.Begin);
            for (var index = 0; (long) index < (long) size2; ++index)
            {
                var cr2WheaderHandle = new CR2WHeaderHandle(file);
                cr2WheaderHandle.ReadString(file, offset1);
                handles.Add(cr2WheaderHandle);
            }

            block4 = new List<CR2WHeaderBlock4>();
            var offset4 = headers[3].offset;
            var size3 = headers[3].size;
            file.BaseStream.Seek(offset4, SeekOrigin.Begin);
            for (var index = 0; index < size3; ++index)
                block4.Add(new CR2WHeaderBlock4(file));
            chunks = new List<CR2WChunk>();
            var offset5 = headers[4].offset;
            var size4 = headers[4].size;
            file.BaseStream.Seek(offset5, SeekOrigin.Begin);
            for (var index = 0; index < size4; ++index)
            {
                var num = file.ReadUInt16();
                var cr2Wchunk = new CR2WChunk(this);
                cr2Wchunk.typeId = num;
                cr2Wchunk.Read(file);
                chunks.Add(cr2Wchunk);
            }

            block6 = new List<CR2WHeaderBlock6>();
            var offset6 = headers[5].offset;
            var size5 = headers[5].size;
            file.BaseStream.Seek(offset6, SeekOrigin.Begin);
            for (var index = 0; index < size5; ++index)
                block6.Add(new CR2WHeaderBlock6(file));
            block7 = new List<CR2WHeaderBlock7>();
            var offset7 = headers[6].offset;
            var size6 = headers[6].size;
            file.BaseStream.Seek(offset7, SeekOrigin.Begin);
            for (var index = 0; index < size6; ++index)
                block7.Add(new CR2WHeaderBlock7(file));
            for (var index = 0; index < chunks.Count; ++index)
                chunks[index].ReadData(file);
            for (var index = 0; index < block7.Count; ++index)
            {
                block7[index].ReadString(file, offset1);
                block7[index].ReadData(file);
            }

            file.BaseStream.Seek(cr2wsize, SeekOrigin.Begin);
            var count = (int) buffersize - (int) cr2wsize;
            if (count <= 0)
                return;
            bufferdata = new byte[count];
            file.BaseStream.Read(bufferdata, 0, count);
        }

        public CVariable ReadVariable(BinaryReader file)
        {
            var num1 = file.ReadUInt16();
            if (num1 == (ushort)0)
                return (CVariable) null;
            var position = file.BaseStream.Position;
            var num2 = file.ReadUInt16();
            var size = file.ReadUInt32() - 4U;
            var byName = CR2WTypeManager.Get().GetByName(strings[num2].str, strings[num1].str, this, true);
            byName.Read(file, size);
            byName.nameId = num1;
            byName.typeId = num2;
            return byName;
        }

        public void WriteVariable(BinaryWriter file, CVariable var)
        {
            file.Write(var.nameId);
            file.Write(var.typeId);
            var position1 = file.BaseStream.Position;
            file.Write(0U);
            var.Write(file);
            var position2 = file.BaseStream.Position;
            file.Seek((int) position1, SeekOrigin.Begin);
            var num = (uint) (position2 - position1);
            file.Write(num);
            file.Seek((int) position2, SeekOrigin.Begin);
        }

        public void Write(BinaryWriter file)
        {
            foreach (var chunk in chunks)
                GetStringIndex(chunk.Type, true);
            headerOffset = 0U;
            var memoryStream = new MemoryStream();
            WriteBuffers(new BinaryWriter(memoryStream));
            WriteHeader(file);
            headerOffset = (uint) file.BaseStream.Position;
            memoryStream.Seek(0L, SeekOrigin.Begin);
            memoryStream.WriteTo(file.BaseStream);
            cr2wsize += headerOffset;
            buffersize += headerOffset;
            WriteHeader(file);
        }

        private void WriteHeader(BinaryWriter file)
        {
            file.BaseStream.Seek(0L, SeekOrigin.Begin);
            file.Write(IDString);
            file.Write(FileVersion);
            file.Write(unk2);
            file.Write(unk3);
            file.Write(unk4);
            file.Write(unk5);
            file.Write(cr2wsize);
            file.Write(buffersize);
            file.Write(unk6);
            file.Write(unk7);
            for (var index = 0; index < 10; ++index)
                headers[index].Write(file);
            var position = (uint) file.BaseStream.Position;
            headers[0].offset = position;
            var dic1 = new Dictionary<string, uint>();
            var dic2 = new Dictionary<string, uint>();
            for (var index = 0; index < strings.Count; ++index)
                dic1.AddUnique(strings[index].str, strings[index].offset);
            for (var index = 0; index < handles.Count; ++index)
                dic1.AddUnique(handles[index].str, handles[index].offset);
            for (var index = 0; index < block7.Count; ++index)
                foreach (var handle in block7[index].handles)
                    dic1.AddUnique(handle, block7[index].handle_name_offset);
            foreach (var keyValuePair in dic1)
            {
                var num = (uint) file.BaseStream.Position - position;
                dic2.Add(keyValuePair.Key, num);
                file.WriteCR2WString(keyValuePair.Key);
            }

            headers[0].size = (uint) file.BaseStream.Position - position;
            for (var index = 0; index < strings.Count; ++index)
            {
                var num = dic2.Get(strings[index].str);
                if ((int) strings[index].offset != (int) num)
                    strings[index].offset = num;
            }

            for (var index = 0; index < handles.Count; ++index)
            {
                var num = dic2.Get(handles[index].str);
                if ((int) num != (int) handles[index].offset)
                    handles[index].offset = num;
            }

            for (var index1 = 0; index1 < block7.Count; ++index1)
            for (var index2 = 0; index2 < block7[index1].handles.Count; ++index2)
            {
                var num = dic2.Get(block7[index1].handles[index2]);
                if ((int) num != (int) block7[index1].handle_name_offset)
                    block7[index1].handle_name_offset = num;
            }

            headers[1].size = (uint) strings.Count;
            headers[1].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < strings.Count; ++index)
                strings[index].Write(file);
            headers[2].size = (uint) handles.Count;
            headers[2].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < handles.Count; ++index)
                handles[index].Write(file);
            headers[3].size = (uint) block4.Count;
            headers[3].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < block4.Count; ++index)
                block4[index].Write(file);
            headers[4].size = (uint) chunks.Count;
            headers[4].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < chunks.Count; ++index)
            {
                chunks[index].offset += headerOffset;
                chunks[index].Write(file);
            }

            headers[5].size = (uint) block6.Count;
            headers[5].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < block6.Count; ++index)
                block6[index].Write(file);
            headers[6].size = (uint) block7.Count;
            headers[6].offset = (uint) file.BaseStream.Position;
            for (var index = 0; index < block7.Count; ++index)
            {
                block7[index].offset += headerOffset;
                block7[index].Write(file);
            }
        }

        private void WriteBuffers(BinaryWriter file)
        {
            var position = file.BaseStream.Position;
            for (var index = 0; index < chunks.Count; ++index)
                chunks[index].WriteData(file);
            for (var index = 0; index < block7.Count; ++index)
                block7[index].WriteData(file);
            cr2wsize = (uint) file.BaseStream.Position;
            if (bufferdata != null)
                file.Write(bufferdata);
            buffersize = (uint) file.BaseStream.Position;
        }

        public CR2WChunk CreateChunk(string type, CR2WChunk parent = null)
        {
            var cr2Wchunk = new CR2WChunk(this);
            cr2Wchunk.Type = type;
            cr2Wchunk.CreateDefaultData();
            if (parent != null)
                cr2Wchunk.ParentChunkId = (uint) (chunks.IndexOf(parent) + 1);
            chunks.Add(cr2Wchunk);
            return cr2Wchunk;
        }

        public int GetStringIndex(string name, bool addnew = false)
        {
            for (var index = 0; index < strings.Count; ++index)
                if (strings[index].str == name ||
                    string.IsNullOrEmpty(name) && string.IsNullOrEmpty(strings[index].str))
                    return index;
            if (!addnew)
                return -1;
            strings.Add(new CR2WHeaderString {str = name});
            return strings.Count - 1;
        }

        public int GetHandleIndex(string name, ushort filetype, ushort flags, bool addnew = false)
        {
            for (var index = 0; index < handles.Count; ++index)
                if (handles[index].filetype == filetype && handles[index].flags == flags &&
                    (handles[index].str == name ||
                     string.IsNullOrEmpty(name) && string.IsNullOrEmpty(handles[index].str)))
                    return index;
            if (!addnew)
                return -1;
            handles.Add(new CR2WHeaderHandle
            {
                str = name,
                filetype = filetype,
                flags = flags
            });
            return handles.Count - 1;
        }

        public CR2WChunk GetChunkByType(string type)
        {
            for (var index = 0; index < chunks.Count; ++index)
                if (chunks[index].Type == type)
                    return chunks[index];
            return null;
        }

        public CVector CreateVector(CR2WChunk in_chunk, string type, string varname = "")
        {
            var vector = CreateVector(type, varname);
            in_chunk.data.AddVariable(vector);
            return vector;
        }

        public CVector CreateVector(CArray in_array, string varname = "")
        {
            var vector = CreateVector("", varname);
            in_array.AddVariable(vector);
            return vector;
        }

        public CVector CreateVector(string type, string varname = "")
        {
            var cvector = new CVector(this);
            cvector.Type = type;
            cvector.Name = varname;
            return cvector;
        }

        public CVariable CreateVariable(CVector in_vector, string type, string varname = "")
        {
            var variable = CreateVariable(type, varname);
            in_vector.AddVariable(variable);
            return variable;
        }

        public CVariable CreateVariable(CR2WChunk in_chunk, string type, string varname = "")
        {
            var variable = CreateVariable(type, varname);
            in_chunk.data.AddVariable(variable);
            return variable;
        }

        public CVariable CreateVariable(string type, string varname = "")
        {
            var byName = CR2WTypeManager.Get().GetByName(type, varname, this, false);
            byName.Type = type;
            byName.Name = varname;
            return byName;
        }

        public CVariable CreateVariable(CArray in_array, string type)
        {
            var variable = CreateVariable(type);
            in_array.AddVariable(variable);
            return variable;
        }

        public CHandle CreateHandle(
            CArray in_array,
            string type,
            string handle,
            string varname = "")
        {
            var handle1 = CreateHandle(type, handle, varname);
            in_array.AddVariable(handle1);
            return handle1;
        }

        public CHandle CreateHandle(
            CVector in_vector,
            string type,
            string handle,
            string varname = "")
        {
            var handle1 = CreateHandle(type, handle, varname);
            in_vector.AddVariable(handle1);
            return handle1;
        }

        public CHandle CreateHandle(
            CR2WChunk in_chunk,
            string type,
            string handle,
            string varname = "")
        {
            var handle1 = CreateHandle(type, handle, varname);
            in_chunk.data.AddVariable(handle1);
            return handle1;
        }

        public CHandle CreateHandle(string type, string handle, string varname = "")
        {
            var match = new Regex("(\\w+):(.+)").Match(type);
            var str = type;
            if (match.Success)
                str = match.Groups[2].Value;
            if (handle != null)
                handle = handle.Replace('/', '\\');
            var chandle = new CHandle(this);
            chandle.Name = varname;
            chandle.Type = type;
            chandle.Handle = handle;
            chandle.FileType = str;
            return chandle;
        }

        public CSoft CreateSoft(CArray in_array, string type, string handle, string varname = "")
        {
            var soft = CreateSoft(type, handle, varname);
            in_array.AddVariable(soft);
            return soft;
        }

        public CSoft CreateSoft(CVector in_vector, string type, string handle, string varname = "")
        {
            var soft = CreateSoft(type, handle, varname);
            in_vector.AddVariable(soft);
            return soft;
        }

        public CSoft CreateSoft(CR2WChunk in_chunk, string type, string handle, string varname = "")
        {
            var soft = CreateSoft(type, handle, varname);
            in_chunk.data.AddVariable(soft);
            return soft;
        }

        public CSoft CreateSoft(string type, string handle, string varname = "")
        {
            var match = new Regex("(\\w+):(.+)").Match(type);
            var str = type;
            if (match.Success)
                str = match.Groups[2].Value;
            handle = handle.Replace('/', '\\');
            var csoft = new CSoft(this);
            csoft.Name = varname;
            csoft.Type = type;
            csoft.FileType = str;
            csoft.Flags = 4;
            csoft.Handle = handle;
            return csoft;
        }

        public CPtr CreatePtr(CArray in_array, CR2WChunk to_chunk, string varname = "")
        {
            var ptr = CreatePtr("", to_chunk, varname);
            in_array.AddVariable(ptr);
            return ptr;
        }

        public CPtr CreatePtr(CVector in_vector, string type, CR2WChunk to_chunk, string varname = "")
        {
            var ptr = CreatePtr(type, to_chunk, varname);
            in_vector.AddVariable(ptr);
            return ptr;
        }

        public CPtr CreatePtr(CR2WChunk in_chunk, string type, CR2WChunk to_chunk, string varname = "")
        {
            var ptr = CreatePtr(type, to_chunk, varname);
            in_chunk.data.AddVariable(ptr);
            return ptr;
        }

        public CPtr CreatePtr(string type, CR2WChunk tochunk, string varname = "")
        {
            var cptr = new CPtr(this);
            cptr.Name = varname;
            cptr.Type = type;
            if (tochunk != null)
                cptr.val = chunks.IndexOf(tochunk) + 1;
            return cptr;
        }

        public bool RemoveChunk(CR2WChunk chunk)
        {
            return chunks.Remove(chunk);
        }
    }
}