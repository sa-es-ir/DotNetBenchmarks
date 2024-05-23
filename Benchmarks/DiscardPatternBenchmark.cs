using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[HideColumns(Column.RatioSD, Column.AllocRatio)]
[SimpleJob(RuntimeMoniker.Net80)]
public class DiscardPatternBenchmark
{
    [Benchmark]
    public void NoDiscard()
    {
        DoSomething();
    }

    [Benchmark]
    public void Discard()
    {
        _ = DoSomething();
    }

    private List<string> DoSomething()
    {
        return ["one", "two", "three", "4", "5"];
    }
}
