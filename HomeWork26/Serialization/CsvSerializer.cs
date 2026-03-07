using System.Reflection;
using System.Text;

namespace Reflection.Serialization;

public static class CsvSerializer
{
    public static string Serialize<T>(T obj)
    {
        var type = typeof(T);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        var sb = new StringBuilder();
        
        sb.AppendJoin(',', fields.Select(f => f.Name));
        sb.AppendLine();
        sb.AppendJoin(',', fields.Select(f => f.GetValue(obj)?.ToString() ?? ""));

        return sb.ToString();
    }
}
