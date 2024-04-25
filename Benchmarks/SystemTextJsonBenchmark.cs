using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;
using System.Text.Json;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[HideColumns(Column.RatioSD, Column.AllocRatio)]
[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]
public class SystemTextJsonBenchmark
{
    private SampleModel model;
    private string json;

    [GlobalSetup]
    public void GlobalSetup()
    {
        model = new SampleModel();
        json = "{\"Id\":1,\"UniqueId\":\"fcd03978-0562-4166-bad9-55605e9d5ace\",\"Name\":\"test_name\",\"CreatedAt\":\"2024-04-25T09:39:10.6768869Z\"}";
    }

    [Benchmark]
    public void Serialize() => JsonSerializer.Serialize(model);

    [Benchmark]
    public void Deserialize() => JsonSerializer.Deserialize<SampleModel>(json);
}


public class SampleModel
{
    public int Id { get; set; } = 1;

    public Guid UniqueId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "test_name";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
