using System.Windows;
using System.Windows.Controls;
using Graphing.Data;

namespace FourSoulsGUI
{
    /// <summary>
    /// Interaction logic for ScottPlotGraphControl.xaml
    /// </summary>
    public partial class ScottPlotGraphControl : UserControl
    {
        // Define a dependency property for binding the graph data
        public static readonly DependencyProperty RenderGraphDataProperty =
            DependencyProperty.Register(
                "RenderGraphData",
                typeof(GraphData),
                typeof(ScottPlotGraphControl),
                new PropertyMetadata(null, OnRenderGraphDataChanged)
            );

        public GraphData RenderGraphData
        {
            get { return (GraphData)GetValue(RenderGraphDataProperty); }
            set { SetValue(RenderGraphDataProperty, value); }
        }

    

        //Constructor
        public ScottPlotGraphControl()
        {
            InitializeComponent();
        }

        // Callback method for when the RenderGraphData property changes
        private static void OnRenderGraphDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Retrieve the updated graph data
            var control = (ScottPlotGraphControl)d;
            var graphData = (GraphData)e.NewValue;
            var viewModel = (GraphViewModel)control.DataContext;

            // Call the method to render the graph based on the updated data
            control.RenderGraph(graphData, viewModel);
        }

        // Method to render the graph based on the graph data
        private void RenderGraph(GraphData graphData, GraphViewModel viewModel)
        {
            // Implement the logic to render the graph using the provided data
            // This could involve interacting with your graphing library or control
            viewModel.Plot.RenderGraph(graphData, WpfPlot);
        }
    }
}
