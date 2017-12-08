using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class RowWithPercent:Row
    {
        //row percent
        private double percent;

        //row percent (property)
        public double Percent
        {
            get
            {
                return percent;
            }

            set
            {
                percent = value;
                OnPropertyChanged(nameof(Percent));
            }
        }
    }
}
