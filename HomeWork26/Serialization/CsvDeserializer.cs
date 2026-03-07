using System.Reflection;

namespace Reflection.Serialization;

public static class CsvDeserializer
{
    public static T Deserialize<T>(string csv) where T : new()
    {
        var lines = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            throw new ArgumentException("CSV должен содержать заголовок и строку данных.");

        var headers = lines[0].Split(',');
        var values  = lines[1].Split(',');

        var type = typeof(T);
        var obj  = new T();

        for (int i = 0; i < headers.Length; i++)
        {
            var field = type.GetField(headers[i].Trim(), BindingFlags.Public | BindingFlags.Instance);
            if (field is null) continue;

            var converted = Convert.ChangeType(values[i].Trim(), field.FieldType);
            field.SetValue(obj, converted);
        }

        return obj;
    }
}
