using System;

namespace WolvenKit.StringEncoder
{
    public class W3EncodedString
    {
        public W3EncodedString(int id, string hexKey, string stringKey, string localization)
        {
            Id = id;
            HexKey = hexKey;
            StringKey = stringKey;
            Localization = localization;
        }

        public static W3EncodedString GenerateW3String(int id, string hexKey, string stringKey, string localization)
        {
            return new W3EncodedString(id, hexKey, stringKey, localization);
        }

        public static W3EncodedString ConvertStringArrayToW3EncodedString(string[] array)
        {
            if (array == null) throw new ArgumentNullException("Cannot convert a null string array to a W3Encoded string.\n Please provide a string array with 4 elements.");
            return new W3EncodedString(Convert.ToInt32(array[0]), array[1], array[2], array[3]);
        }

        public int Id { get; set; }
        public string HexKey { get; set; }
        public string StringKey { get; set; }
        public string Localization { get; set; }


    }
}
