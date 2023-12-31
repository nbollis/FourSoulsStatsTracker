namespace FourSoulsDataConnection;

public class PropertyStatistics
{
    public string PropertyName { get; set; }
    public double Value { get; set; }
    public double Mean { get; set; }
    public double Median { get; set; }
    public double StandardDeviation { get; set; }

    public PropertyStatistics(string propertyName, double value, double mean, double median, double stdDev)
    {
        PropertyName = propertyName;
        Value = value;
        Mean = mean;
        Median = median;
        StandardDeviation = stdDev;
    }
}