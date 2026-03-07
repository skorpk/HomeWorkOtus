using System.Diagnostics;
using System.Text.Json;
using Reflection.Models;
using Reflection.Serialization;

namespace Reflection.Benchmarks;

public static class BenchmarkRunner
{
    private const int Iterations = 10_000;

    private static readonly JsonSerializerOptions JsonOptions = new() { IncludeFields = true };

    public static void Run()
    {
        var instance = ClassF.Get();
        string csvResult = string.Empty;
        string jsonResult = string.Empty;
        ClassF? csvDeserialized = null;
        ClassF? jsonDeserialized = null;
        /*сериализация CSV*/
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < Iterations; i++)
            csvResult = CsvSerializer.Serialize(instance);
        sw.Stop();
        long csvSerMs = sw.ElapsedMilliseconds;

        /*JSON сериализация*/
        sw.Restart();
        for (int i = 0; i < Iterations; i++)
            jsonResult = JsonSerializer.Serialize(instance, JsonOptions);
        sw.Stop();
        long jsonSerMs = sw.ElapsedMilliseconds;

        /*десериализация csv*/
        sw.Restart();
        for (int i = 0; i < Iterations; i++)
            csvDeserialized = CsvDeserializer.Deserialize<ClassF>(csvResult);
        sw.Stop();
        long csvDeserMs = sw.ElapsedMilliseconds;

        /*JSON десериализация*/
        sw.Restart();
        for (int i = 0; i < Iterations; i++)
            jsonDeserialized = JsonSerializer.Deserialize<ClassF>(jsonResult, JsonOptions);
        sw.Stop();
        long jsonDeserMs = sw.ElapsedMilliseconds;

        // --- Вывод результатов ---
        Console.WriteLine($"CSV-строка:  {csvResult}");
        Console.WriteLine($"JSON-строка: {jsonResult}");
        Console.WriteLine();
        Console.WriteLine($"Сериализуемый класс: class F {{ int i1, i2, i3, i4, i5; }}");
        Console.WriteLine($"Количество замеров: {Iterations:N0} итераций");
        Console.WriteLine();
        Console.WriteLine($"[Мой Reflection CSV]");
        Console.WriteLine($"  Сериализация:   {csvSerMs} мс");
        Console.WriteLine($"  Десериализация: {csvDeserMs} мс");
        Console.WriteLine();
        Console.WriteLine($"[System.Text.Json]");
        Console.WriteLine($"  Сериализация:   {jsonSerMs} мс");
        Console.WriteLine($"  Десериализация: {jsonDeserMs} мс");
        Console.WriteLine();
        
        sw.Restart();
        Console.Write(csvResult);
        sw.Stop();
        Console.WriteLine();
        Console.WriteLine($"[Console.Write] Время вывода строки: {sw.ElapsedMilliseconds} мс");

        // Чтобы компилятор не выбросил переменные как unused
        _ = csvDeserialized;
        _ = jsonDeserialized;
    }
}
