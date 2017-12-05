using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class RowWithExpertMarks : Row
    {
        public ObservableCollection<double> ExpertCoefficients { get; set; }

        public string Level { get; set; }
    }
}
