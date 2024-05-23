using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser(false)]
[HideColumns("RatioSD", "Median", "StdDev", "Error", "Job", "Alloc Ratio")]
public class LinqAggregateBenchmark
{
    [Params(10000)]
    public int Length { get; set; }

    private IEnumerable<int> _source;

    [GlobalSetup]
    public void Setup() => _source = Enumerable.Range(1, Length);

    [Benchmark]
    public int Min() => _source.Min();

    [Benchmark]
    public int Max() => _source.Max();

    [Benchmark]
    public double Average() => _source.Average();

    [Benchmark]
    public int Sum() => _source.Sum();
}