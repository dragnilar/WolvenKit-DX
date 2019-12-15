// Decompiled with JetBrains decompiler
// Type: W3Edit.Configuration
// Assembly: W3Edit, Version=0.0.24.0, Culture=neutral, PublicKeyToken=null
// MVID: 1F6A929A-65EC-45F5-ADD8-06AA68753D55
// Assembly location: F:\dragn\Documents\Misc Applications\W3Edit\W3Edit.exe

using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace W3Edit
{
  public class Configuration
  {
    ~Configuration()
    {
      this.Save();
    }

    public static string ConfigurationPath
    {
      get
      {
        string executablePath = Application.ExecutablePath;
        string withoutExtension = Path.GetFileNameWithoutExtension(executablePath);
        return Path.Combine(Path.GetDirectoryName(executablePath), withoutExtension + "_config.xml");
      }
    }

    public void Save()
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (Configuration));
      FileStream fileStream = new FileStream(Configuration.ConfigurationPath, FileMode.Create, FileAccess.Write);
      xmlSerializer.Serialize((Stream) fileStream, (object) this);
      fileStream.Close();
    }

    public static Configuration Load()
    {
      if (File.Exists(Configuration.ConfigurationPath))
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (Configuration));
        FileStream fileStream = new FileStream(Configuration.ConfigurationPath, FileMode.Open, FileAccess.Read);
        Configuration configuration = (Configuration) xmlSerializer.Deserialize((Stream) fileStream);
        fileStream.Close();
        return configuration;
      }
      return new Configuration()
      {
        TextLanguage = "en",
        VoiceLanguage = "en",
        EnableFlowTreeEditor = false
      };
    }

    public string ExecutablePath { get; set; }

    public string TextLanguage { get; set; }

    public string VoiceLanguage { get; set; }

    public string WCC_Lite { get; set; }

    public Size MainSize { get; set; }

    public string InitialModDirectory { get; set; }

    public string InitialFileDirectory { get; set; }

    public bool EnableFlowTreeEditor { get; set; }

    public Point MainLocation { get; set; }

    public FormWindowState MainState { get; set; }

    public string InitialExportDirectory { get; set; }
  }
}
