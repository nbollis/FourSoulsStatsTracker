namespace Graphing.Data
{
    /// <summary>
    /// Abstract class for all graph data to inherit from
    /// </summary>
    public abstract class GraphData
    {
        public string Title { get; }

        protected GraphData(string title)
        {
            Title = title;
        }

        protected GraphData()
        {
            Title = "Untitled Graph";
        }
    }
}