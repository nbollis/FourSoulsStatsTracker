using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FourSoulsGUI.Util;
using ScottPlot;
using Graphing.Interfaces;
using Graphing.Data;
using LegendItem = Graphing.LegendItem;

namespace FourSoulsGUI
{


    public class GraphViewModel : BaseViewModel
    {

        #region Legend

        private bool _legendVisibility = true;
        public bool LegendVisibility 
        { get => _legendVisibility; set => SetProperty(ref _legendVisibility, value); }

        private ObservableCollection<LegendItem> legendItems;
        public ObservableCollection<LegendItem> LegendItems
        { get => legendItems; set => SetProperty(ref legendItems, value); }

        private int legendRows = 6;
        public int LegendRows
        { get => legendRows; set => SetProperty(ref legendRows, value); }
        private int legendColumns = 1;
        public int LegendColumns
        { get => legendColumns; set => SetProperty(ref legendColumns, value); }

        public ICommand AddLegendColumnCommand { get; set; }
        public ICommand RemoveLegendColumnCommand { get; set; }
        public ICommand AddLegendRowCommand { get; set; }
        public ICommand RemoveLegendRowCommand { get; set; }

        public ICommand ToggleLegendCommand { get; set; }

        private void ToggleLegend()
        {
            LegendVisibility = !LegendVisibility;
        }

        private void AddLegendRow()
        {
            LegendRows++;
        }

        private void RemoveLegendRow()
        {
            // ensure it does not go below one 
            if (LegendRows <= 1)
            {
                return;
            }
            LegendRows--;
        }

        private void AddLegendColumn()
        {
            LegendColumns++;
        }

        private void RemoveLegendColumn()
        {
            // ensure it does not go below one 
            if (LegendColumns <= 1)
            {
                return;
            }
            LegendColumns--;
        }

        #endregion




        private GraphData graphData = null!;

        private IGraph plot = null!;

        public IGraph Plot
        {
            get => plot;
            set => SetProperty(ref plot, value);
        }

        public GraphData GraphData
        {
            get => graphData;
            set
            {
                if (graphData != value)
                {
                    SetProperty(ref graphData, value);
                    LegendItems.Clear();
                    LegendItems.AddRange<LegendItem>(graphData.GetLegendItems());
                }
            }
        }

        public GraphViewModel()
        {



            // legend
            LegendItems = new ObservableCollection<LegendItem>();
            AddLegendColumnCommand = new RelayCommand(AddLegendColumn);
            RemoveLegendColumnCommand = new RelayCommand(RemoveLegendColumn);
            AddLegendRowCommand = new RelayCommand(AddLegendRow);
            RemoveLegendRowCommand = new RelayCommand(RemoveLegendRow);
        }
    }
}
