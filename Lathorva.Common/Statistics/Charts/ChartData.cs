using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Statistics.Charts
{
    public class ChartData
    {
        public List<string> Labels { get; set; }

        public List<ChartDataset> Datasets { get; set; }
    }
}
