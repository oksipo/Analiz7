using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class RowWithPercent:Row
    {
        private double percent;

        public double Percent
        {
            get
            {
                return percent;
            }

            set
            {
                percent = value;
                OnPropertyChanged("Percent");
            }
        }
    }
}
