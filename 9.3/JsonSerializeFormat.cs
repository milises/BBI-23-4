using System.IO;
using Newtonsoft.Json;

public abstract class MySerializeFormat
{
    public abstract void Serialize(object obj, string filePath);
    public abstract T Deserialize<T>(string filePath);
}

public class JsonSerializeFormat : MySerializeFormat
{
    public override void Serialize(object obj, string filePath)
    {
        string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public override T Deserialize<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }
}
