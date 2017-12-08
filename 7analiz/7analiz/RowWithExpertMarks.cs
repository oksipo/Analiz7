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
        //level of row
        private string level;

        //collection of expert coeficients
        public ObservableCollection<double> ExpertCoefficients { get; set; }

        //level of row (property)
        public string Level
        {
            get => level;
            set
            {
                this.level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
    }
}
