// Decompiled with JetBrains decompiler
// Type: W3Edit.ImportExportUtility
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using Ionic.Zlib;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace W3Edit
{
  public static class ImportExportUtility
  {
    public static bool StartsWith(this byte[] bytes, string str)
    {
      if (str.Length > bytes.Length)
        return false;
      for (int index = 0; index < str.Length; ++index)
      {
        if ((int) bytes[index] != (int) str[index])
          return false;
      }
      return true;
    }

    public static List<string> GetPossibleExtensions(byte[] bytes)
    {
      List<string> stringList = new List<string>();
      if (bytes == null || !bytes.StartsWith("CFX") && !bytes.StartsWith("CWS") && (!bytes.StartsWith("FWS") && !bytes.StartsWith("GFX")))
        return stringList;
      stringList.Add("Decompressed flash file|*.swf");
      stringList.Add("Unknown file|*.*");
      return stringList;
    }

    public static byte[] GetExportBytes(byte[] bytes, string type)
    {
      switch (type)
      {
        case ".swf":
          if (bytes.StartsWith("CFX") || bytes.StartsWith("CWS"))
            return ImportExportUtility.uncompressToFWS(bytes);
          break;
      }
      return bytes;
    }

    public static byte[] GetImportBytes(BinaryReader reader)
    {
      long position = reader.BaseStream.Position;
      byte[] bytes = reader.ReadBytes(3);
      if ((bytes.StartsWith("FWS") || bytes.StartsWith("GFX")) && MessageBox.Show("Imported file type detected as FWS or GFX, do you want to compress it? \n\n Import as is if not.", "Import", MessageBoxButtons.YesNo) == DialogResult.Yes)
        return ImportExportUtility.compressToCFX(reader);
      reader.BaseStream.Seek(0L, SeekOrigin.Begin);
      return reader.ReadBytes((int) reader.BaseStream.Length);
    }

    private static byte[] uncompressToFWS(byte[] bytes)
    {
      MemoryStream memoryStream1 = new MemoryStream(bytes);
      BinaryReader binaryReader = new BinaryReader((Stream) memoryStream1);
      binaryReader.ReadBytes(3);
      byte num1 = binaryReader.ReadByte();
      uint num2 = binaryReader.ReadUInt32();
      MemoryStream memoryStream2 = new MemoryStream();
      BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream2);
      binaryWriter.Write((byte) 70);
      binaryWriter.Write((byte) 87);
      binaryWriter.Write((byte) 83);
      binaryWriter.Write(num1);
      binaryWriter.Write(num2);
      new ZlibStream((Stream) memoryStream1, CompressionMode.Decompress).CopyTo((Stream) memoryStream2);
      return memoryStream2.ToArray();
    }

    private static byte[] compressToCFX(BinaryReader reader)
    {
      MemoryStream memoryStream = new MemoryStream();
      BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream);
      byte num1 = reader.ReadByte();
      uint num2 = reader.ReadUInt32();
      binaryWriter.Write((byte) 67);
      binaryWriter.Write((byte) 70);
      binaryWriter.Write((byte) 88);
      binaryWriter.Write(num1);
      binaryWriter.Write(num2);
      new ZlibStream(reader.BaseStream, CompressionMode.Compress, true).CopyTo((Stream) memoryStream);
      return memoryStream.ToArray();
    }
  }
}
