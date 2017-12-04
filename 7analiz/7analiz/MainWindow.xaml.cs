﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace _7analiz
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        Random rand = new Random();
        public ObservableCollection<Row> FirstTableRows { get; set; }
        public ObservableCollection<Row> SecondTableRows { get; set; }
        public ObservableCollection<RowWithExpertMarks> ExpertCoefs { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
            InitializeFirstTable();
            InitializeSecondTable();
            InitializeExpertCoefsTable();
            this.DataContext = this;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void InitializeFirstTable()
        {
            FirstTableRows = new ObservableCollection<Row>
            {
                new RowWithPercent() { Name = "Множина джерел появи технічних ризиків", Value = 0, IsHeader=true, Number = "1"},
                new Row() { Name = "Функціональні характеристики ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.1"},
                new Row() { Name = "Характеристики якості ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.2"},
                new Row() { Name = "Характеристики надійності ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.3"},
                new Row() { Name = "Застосовність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.4"},
                new Row() { Name = "Часова продуктивність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.5"},
                new Row() { Name = "Супроводжуваність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.6"},
                new Row() { Name = "Повторне використання компонент ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.7"},

                new RowWithPercent() { Name = "Множина джерел появи вартісних ризиків", Value = Randomize(), IsHeader=true, Number = "2"},
                new Row() { Name = "Обмеження сумарного бюджету на програмний проект,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.1"},
                new Row() { Name = "Недоступна вартість реалізації програмного проекту,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.2"},
                new Row() { Name = "Низька ступінь реалізму при оцінюванні витрат на програмний проект", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.3"},

                new RowWithPercent() { Name = "Множина джерел появи планових ризиків", Value = Randomize(), IsHeader=true, Number = "3"},
                new Row() { Name = "Властивості та можливості гнучкості внесення змін до планів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.1"},
                new Row() { Name = "Можливості порушення встановлених термінів реалізації етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.2"},
                new Row() { Name = "Низька ступінь реалізму при встановленні планів і етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.3"},

                new RowWithPercent() { Name = "Множина джерел появи ризиків реалізації процесу управління програмним проектом", Value = Randomize(), IsHeader=true, Number = "4"},
                new Row() { Name = "Хибна стратегія реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.1"},
                new Row() { Name = "Неефективне планування проекту розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.2"},
                new Row() { Name = "Неякісне оцінювання програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.3"},
                new Row() { Name = "Прогалини в документуванні етапів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.4"},
                new Row() { Name = "Промахи в прогнозуванні результатів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.5"},

                new RowWithTotal() { Name = "Сума", Value = Randomize(), IsHeader = true, GroupName="", Number = ""},
            };

            RecalculateFirstTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void InitializeSecondTable()
        {
            SecondTableRows = new ObservableCollection<Row>
            {
                new RowWithPercent() { Name = "Множина настання технічних ризикових подій", Value = 0, IsHeader=true, Number = "1"},
                new Row() { Name = "Затримки у постачанні обладнання, необхідного для підтримки процесу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.1"},
                new Row() { Name = "Затримки у постачанні інструментальних засобів, необхідних для підтримки процесу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.2"},
                new Row() { Name = "Небажання команди виконавців використовувати інструментальні засоби для підтримки процесу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.3"},
                new Row() { Name = "Формування запитів на більш потужні інструментальні засоби розроблення ПЗ;", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.4"},
                new Row() { Name = "Відмова команди виконавців від CASE-засобів розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.5"},
                new Row() { Name = "Неефективність програмного коду, згенерованого CASE-засобами розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.6"},
                new Row() { Name = "Неможливість інтеграції CASE-засобів з іншими інструментальними засобами для підтримки процесу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.7"},
                new Row() { Name = "Недостатня продуктивність баз(и) даних для підтримки процесу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.8"},
                new Row() { Name = "Програмні компоненти, які використовують повторно в ПЗ, мають дефекти та обмежені функціональні можливості", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.9"},
                new Row() { Name = "Швидкість виявлення дефектів у програмному коді є нижчою від раніше запланованих термінів", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.10"},
                new Row() { Name = "Поява дефектних системних компонент, які використовують для розроблення ПЗ", Value = Randomize(), GroupName="Множина настання технічних ризикових подій", Number = "1.11"},

                new RowWithPercent() { Name = "Множина настання вартісних ризикових подій", Value = 0, IsHeader = true, Number = "2"},
                new Row() { Name = "Недо(пере)оцінювання витрат на реалізацію програмного проекту (надмірно низька вартість)", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.1"},
                new Row() { Name = "Фінансові ускладнення у компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.2"},
                new Row() { Name = "Фінансові ускладнення у компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.3"},
                new Row() { Name = "Змен(збіль)шення бюджету програмного проекта з ініціативи компанії-замовника ПЗ під час його реалізації", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.4"},
                new Row() { Name = "Висока вартість виконання повторних робіт, необхідних для зміни вимог до ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.5"},
                new Row() { Name = "Реорганізація структурних підрозділів у компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.6"},
                new Row() { Name = "Реорганізація команди виконавців у компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.7"},

                new RowWithPercent() { Name = "Множина настання планових ризикових подій", Value = 0, IsHeader = true, Number = "3"},
                new Row() { Name = "Зміни графіка виконання робіт з боку замовника чи розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.1"},
                new Row() { Name = "Порушення графіка виконання робіт з боку компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.2"},
                new Row() { Name = "Потреба зміни користувацьких вимог до ПЗ з боку компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.3"},
                new Row() { Name = "Потреба зміни функціональних вимог до ПЗ з боку компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.4"},
                new Row() { Name = "Потреба виконання великої кількості повторних робіт, необхідних для зміни вимог до ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.5"},
                new Row() { Name = "Недо(пере)оцінювання тривалості етапів реалізації програмного проекту з боку компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.6"},
                new Row() { Name = "Остаточний розмір ПЗ значно перевищує (менший від) заплановані(их) його характеристики", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.7"},
                new Row() { Name = "Поява на ринку аналогічного ПЗ до виходу замовленого", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.8"},
                new Row() { Name = "Поява на ринку більш конкурентоздатного ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.9"},

                new RowWithPercent() { Name = "Множина настання ризикових подій реалізації процесу управління програмним проектом", Value = 0, IsHeader = true, Number = "4"},
                new Row() { Name = "Низький моральний стан персоналу команди виконавців ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.1"},
                new Row() { Name = "Низька взаємодія між членами команди виконавців ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.2"},
                new Row() { Name = "Пасивність керівника (менеджера) програмного проекту", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.3"},
                new Row() { Name = "Недостатня компетентність керівника (менеджера) програмного проекту", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.4"},
                new Row() { Name = "Незадоволеність замовника результатами етапів реалізації програмного проекту", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.5"},
                new Row() { Name = "Недостатня кількість фахівців у команді виконавців ПЗ з необхідним професійним рівнем", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.6"},
                new Row() { Name = "Хвороба провідного виконавця в найкритичніший момент розроблення ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.7"},
                new Row() { Name = "Одночасна хвороба декількох виконавців підчас розроблення ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.8"},
                new Row() { Name = "Неможливість організації необхідного навчання персоналу команди виконавців ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.9"},
                new Row() { Name = "Зміна пріоритетів у процесі управління програмним проектом", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.10"},
                new Row() { Name = "Недо(пере)оцінювання необхідної кількості розробників (підрядників і субпідрядників) на етапах життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.11"},
                new Row() { Name = "Недостатнє (надмірне) документування результатів на етапах реалізації програмного проекту", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.12"},
                new Row() { Name = "Нереалістичне прогнозування результатів на етапах реалізації програмного проекту", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.13"},
                new Row() { Name = "Недостатній професійний рівень представників від компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання ризикових подій реалізації процесу управління програмним проектом", Number = "4.14"},

                new RowWithTotal() { Name = "Сума", Value = Randomize(), IsHeader = true, GroupName="", Number = ""},
            };

            RecalculateSecondTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //TODO IMPORTANT!!! FIX VALUE AFTER CREATING SECOND TAB!!!!
        void InitializeExpertCoefsTable()
        {
            ExpertCoefs = new ObservableCollection<RowWithExpertMarks>
            {
                new RowWithExpertMarks
                {
                    Name = "Множина настання технічних ризикових подій",
                    IsHeader = true,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання технічних ризикових подій"),
                    Number = "1",
                    ExpertCoefficients = new ObservableCollection<double>(Enumerable.Repeat(0d,10)),
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання вартісних ризикових подій",
                    IsHeader = true,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання вартісних ризикових подій"),
                    Number = "2",
                    ExpertCoefficients = new ObservableCollection<double>(Enumerable.Repeat(0d,10)),
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання планових ризикових подій",
                    IsHeader = true,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання планових ризикових подій"),
                    Number = "3",
                    ExpertCoefficients = new ObservableCollection<double>(Enumerable.Repeat(0d,10)),
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання ризикових подій реалізації процесу управління програмним проектом",
                    IsHeader = true,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання ризикових подій реалізації процесу управління програмним проектом"),
                    Number = "4",
                    ExpertCoefficients = new ObservableCollection<double>(Enumerable.Repeat(0d,10)),
                }
            };

            this.RandomizeExpertCoefs();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void RecalculateFirstTableRows()
        {
            int forCount = FirstTableRows.Count() -
                           FirstTableRows.Count(x => x is RowWithPercent || x is RowWithTotal);

            foreach (var item in FirstTableRows.Where(x => x is RowWithPercent))
            {
                item.Value = FirstTableRows.Where(x => x.GroupName == item.Name).Sum(x => x.Value);
            }

            var sum = FirstTableRows.Where(x => x is RowWithPercent).Sum(x => x.Value);
            double sumOfPercent = 0;

            foreach (var item in FirstTableRows.Where(x => x is RowWithPercent))
            {
                var temp = item as RowWithPercent;
                temp.Percent = (temp.Value / forCount);
                sumOfPercent += temp.Percent;
            }

            foreach (var item in FirstTableRows.Where(x => x is RowWithTotal))
            {
                item.Value = sum;

                var temp = item as RowWithTotal;
                temp.Percent = sumOfPercent;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void GenerateFirstTableRows()
        {
            foreach(var item in FirstTableRows)
            {
                item.Value = Randomize();
            }

            RecalculateFirstTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void RecalculateSecondTableRows()
        {
            int forCount = SecondTableRows.Count() -
                           SecondTableRows.Count(x => x is RowWithPercent || x is RowWithTotal);

            foreach (var item in SecondTableRows.Where(x => x is RowWithPercent))
            {
                item.Value = SecondTableRows.Where(x => x.GroupName == item.Name).Sum(x => x.Value);
            }

            var sum = SecondTableRows.Where(x => x is RowWithPercent).Sum(x => x.Value);
            double sumOfPercent = 0;

            foreach (var item in SecondTableRows.Where(x => x is RowWithPercent))
            {
                var temp = item as RowWithPercent;
                temp.Percent = (temp.Value / forCount);
                sumOfPercent += temp.Percent;
            }

            foreach (var item in SecondTableRows.Where(x => x is RowWithTotal))
            {
                item.Value = sum;

                var temp = item as RowWithTotal;
                temp.Percent = sumOfPercent;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void GenerateSecondTableRows()
        {
            foreach (var item in SecondTableRows)
            {
                item.Value = Randomize();
            }

            RecalculateSecondTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        void RandomizeExpertCoefs()
        {
            foreach (var row in ExpertCoefs)
            {
                for (var i = 0; i < row.ExpertCoefficients.Count; i++)
                {
                    row.ExpertCoefficients[i] = rand.Next(0, 11);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        double Randomize()
        {
            return rand.NextDouble();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GenerateFirstTableRows();
            GenerateSecondTableRows();
            RandomizeExpertCoefs();
            OnPropertyChanged("FirstTableRows");
            OnPropertyChanged("SecondTableRows");
            OnPropertyChanged(nameof(ExpertCoefs));
        }
        private void FirstTable_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            RecalculateFirstTableRows();
            OnPropertyChanged("FirstTableRows");
        }

        private void SecondTable_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            RecalculateSecondTableRows();
            OnPropertyChanged("SecondTableRows");
        }
    }
}
