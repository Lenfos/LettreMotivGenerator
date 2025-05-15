using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LettreMotivGenerator.MVVM.Model;

public class Serialization
{
    
    private readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LettreMotivGenerator", "save.json");
    
    public void WriteToFile<T>(T objectToWrite)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath)!))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        }
        string json = JsonSerializer.Serialize(objectToWrite, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public DataRoot? ReadFromFile<T>()
    {
        if (Directory.Exists(Path.GetDirectoryName(filePath)!) && File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<DataRoot>(json);
        }
        
        return new DataRoot();
    }
    
}