using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[HideColumns(Column.RatioSD, Column.AllocRatio)]
[SimpleJob(RuntimeMoniker.Net80)]
public class ListCountBenchmark
{
    private List<int> _list;

    [Params(1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        IEnumerable<int> range = Enumerable.Range(0, Count);

        _list = range.ToList();
    }

    [Benchmark]
    public int ListCountMethod() => _list.Count();

    [Benchmark]
    public int ListCountProperty() => _list.Count;

}
