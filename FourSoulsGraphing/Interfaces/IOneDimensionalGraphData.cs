namespace Graphing.Interfaces
{
    internal interface IOneDimensionalGraphData<T>
    {
        public string Title { get; }
        public T[] Values { get; }
        public string[] SeriesNames { get; }
        public string[] SeriesColors { get; }
    }
}