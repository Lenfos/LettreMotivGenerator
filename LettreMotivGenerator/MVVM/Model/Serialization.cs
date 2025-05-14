using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LettreMotivGenerator.MVVM.Model;

public class Serialization
{
    
    private readonly string filePath = "save.json";
    
    public void WriteToFile<T>(T objectToWrite)
    {
        string json = JsonSerializer.Serialize(objectToWrite, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public DataRoot? ReadFromFile<T>()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<DataRoot>(json);

    }
    
}