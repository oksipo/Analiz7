using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _7analiz
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Row> FirstTableRows { get; set; }
        Random rand = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFirstTable();
            this.DataContext = this;
        }

        void InitializeFirstTable()
        {
            FirstTableRows = new ObservableCollection<Row>
            {
                new RowWithPercent() { Name = "Множина джерел появи технічних ризиків", Value = 0, IsHeader=true, Number = 1},
                new Row() { Name = "Функціональні характеристики ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.1},
                new Row() { Name = "Характеристики якості ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.2},
                new Row() { Name = "Характеристики надійності ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.3},
                new Row() { Name = "Застосовність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.4},
                new Row() { Name = "Часова продуктивність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.5},
                new Row() { Name = "Супроводжуваність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.6},
                new Row() { Name = "Повторне використання компонент ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = 1.7},

                new RowWithPercent() { Name = "Множина джерел появи вартісних ризиків", Value = Randomize(), IsHeader=true, Number = 2},
                new Row() { Name = "Обмеження сумарного бюджету на програмний проект,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = 2.1},
                new Row() { Name = "Недоступна вартість реалізації програмного проекту,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = 2.2},
                new Row() { Name = "Низька ступінь реалізму при оцінюванні витрат на програмний проект", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = 2.3},

                new RowWithPercent() { Name = "Множина джерел появи планових ризиків", Value = Randomize(), IsHeader=true, Number = 3},
                new Row() { Name = "Властивості та можливості гнучкості внесення змін до планів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = 3.1},
                new Row() { Name = "Можливості порушення встановлених термінів реалізації етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = 3.2},
                new Row() { Name = "Низька ступінь реалізму при встановленні планів і етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = 3.3},

                new RowWithPercent() { Name = "Множина джерел появи ризиків реалізації процесу управління програмним проектом", Value = Randomize(), IsHeader=true, Number = 4},
                new Row() { Name = "Хибна стратегія реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = 4.1},
                new Row() { Name = "Неефективне планування проекту розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = 4.2},
                new Row() { Name = "Неякісне оцінювання програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = 4.3},
                new Row() { Name = "Прогалини в документуванні етапів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = 4.4},
                new Row() { Name = "Промахи в прогнозуванні результатів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = 4.5}
            };

            RecalculateFirstTableRows();
        }

        void RecalculateFirstTableRows()
        {
            foreach (var item in FirstTableRows.Where(x => x is RowWithPercent))
            {
                item.Value = FirstTableRows.Where(x => x.GroupName == item.Name).Sum(x => x.Value);
            }

            var sum = FirstTableRows.Where(x => x is RowWithPercent).Sum(x => x.Value);

            foreach (var item in FirstTableRows.Where(x => x is RowWithPercent))
            {
                var temp = item as RowWithPercent;
                temp.Percent = (temp.Value / sum);
            }
        }

        void GenerateFirstTableRows()
        {
            foreach(var item in FirstTableRows)
            {
                item.Value = Randomize();
            }

            RecalculateFirstTableRows();
        }

        double Randomize()
        {
            return rand.NextDouble();
        }

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GenerateFirstTableRows();
            OnPropertyChanged("FirstTableRows");
        }
        private void FirstTable_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            RecalculateFirstTableRows();
            OnPropertyChanged("FirstTableRows");
        }
    }
}
