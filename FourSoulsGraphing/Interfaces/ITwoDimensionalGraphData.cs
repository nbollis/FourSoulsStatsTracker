namespace Graphing.Interfaces;

internal interface ITwoDimensionalGraphData<T>
{
    public string Title { get; }
    public T[] XValues { get; }
    public T[] YValues { get; }
    public string[] SeriesNames { get; }
    public string[] SeriesColors { get; }
}