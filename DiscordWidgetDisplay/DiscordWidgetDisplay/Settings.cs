using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWidgetDisplay;
internal class Settings
{
    [JsonIgnore]
    internal static string DataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"PinguApps\\DiscordWidgetDisplay\\");
    
    [JsonIgnore]
    internal static string AppSettingsPath = $"{DataFilePath}Settings\\";

    [JsonIgnore]
    internal static string AppSettingsFileName => $"{AppSettingsPath}Application.settings";

    public void Save()
    {
        if(!Directory.Exists(AppSettingsPath))
        {
            Directory.CreateDirectory(AppSettingsPath);
        }

        var options = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        var json = JsonConvert.SerializeObject(this, options);

        File.WriteAllText(AppSettingsFileName, json);
    }

    public static Settings Load()
    {
        if (File.Exists(AppSettingsFileName))
        {
            var json = File.ReadAllText(AppSettingsFileName);

            var tempSettings = JsonConvert.DeserializeObject<Settings>(json);

            if(tempSettings is null)
            {
                return new Settings();
            }

            return tempSettings;
        }
        else
        {
            return new Settings();
        }
    }

    public string? LastVoiceLocation { get; set; } = null;

    public string? LastChatLocation { get; set; } = null;

    public double? Top { get; set; } = null;

    public double? Left { get; set; } = null;

    public bool VoiceVisible { get; set; } = true;

    public bool ChatVisible { get; set; } = false;

    public bool Topmost { get; set; } = true;
}
