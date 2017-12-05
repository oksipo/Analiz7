using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class SolutionRow : INotifyPropertyChanged
    {
        public int Number { get; set; }

        public string Name { get; set; }
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
