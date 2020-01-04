using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WolvenKit.StringEncoder.Properties;

namespace WolvenKit.StringEncoder
{
    public class W3EncodedString : INotifyPropertyChanged
    {
        private string _hexKey;

        private int _id;

        private string _localization;

        private string _stringKey;

        public W3EncodedString(int id, string hexKey, string stringKey, string localization)
        {
            Id = id;
            HexKey = hexKey;
            StringKey = stringKey;
            Localization = localization;
        }

        public W3EncodedString()
        {

        }

        public int Id
        {
            get => _id;

            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string HexKey
        {
            get => _hexKey;

            set
            {
                _hexKey = value;
                OnPropertyChanged(nameof(HexKey));
            }
        }

        public string StringKey
        {
            get => _stringKey;

            set
            {
                _stringKey = value;
                OnPropertyChanged(nameof(StringKey));
            }
        }

        public string Localization
        {
            get => _localization;

            set
            {
                _localization = value;
                OnPropertyChanged(nameof(Localization));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static W3EncodedString GenerateW3String(int id, string hexKey, string stringKey, string localization)
        {
            return new W3EncodedString(id, hexKey, stringKey, localization);
        }

        public static W3EncodedString ConvertStringArrayToW3EncodedString(string[] array)
        {
            if (array == null)
                throw new ArgumentNullException(
                    "Cannot convert a null string array to a W3Encoded string.\n Please provide a string array with 4 elements.");
            return new W3EncodedString(Convert.ToInt32(array[0]), array[1], array[2], array[3]);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}