using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace _7analiz
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //variable for randomizing list values
        Random rand = new Random();

        //lists of rows
        public ObservableCollection<Row> FirstTableRows { get; set; }                   //rows for first table
        public ObservableCollection<Row> SecondTableRows { get; set; }                  //rows for second table
        public ObservableCollection<RowWithExpertMarks> ExpertCoefs { get; set; }       //rows for table with expert coefs #1
        public ObservableCollection<RowWithExpertMarks> ExpertCoefs2 { get; set; }       //rows for table with expert coefs #1

        public ObservableCollection<RowWithExpertMarks> ExpertMarks { get; set; }       //rows for table with expert marks #1
        public ObservableCollection<RowWithExpertMarks> ExpertMarks2 { get; set; }       //rows for table with expert marks #1
        public ObservableCollection<SolutionRow> SolutionsTableRows { get; set; }

        public ObservableCollection<RowWithExpertMarks> StrangeTable { get; set; }//rows for table with solutions

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //event on property changing
        public event PropertyChangedEventHandler PropertyChanged;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //constructor
        public MainWindow()
        {
            //initializing form
            InitializeComponent();

            //initializing tables
            InitializeFirstTable();
            InitializeSecondTable();
            InitializeExpertCoefsTable();
            InitializeExpertCoefsTable2();
            InitializeExpertMarksTable();
            InitializeExpertMarksTable2();
            InitializeSolutionTableRows();
            InitializeStrangeTable();

            //setting data context
            this.DataContext = this;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //INITIALIZATION TABLES
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //initializing first table
        void InitializeFirstTable()
        {
            //creating rows
            FirstTableRows = new ObservableCollection<Row>
            {
                new RowWithPercent() { Name = "Множина джерел появи технічних ризиків", min =0, max=100, Value = 0, IsHeader=true, Number = "1"},
                new Row() { Name = "Функціональні характеристики ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.1"},
                new Row() { Name = "Характеристики якості ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.2"},
                new Row() { Name = "Характеристики надійності ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.3"},
                new Row() { Name = "Застосовність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.4"},
                new Row() { Name = "Часова продуктивність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.5"},
                new Row() { Name = "Супроводжуваність ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.6"},
                new Row() { Name = "Повторне використання компонент ПЗ", Value = Randomize(), GroupName="Множина джерел появи технічних ризиків", Number = "1.7"},

                new RowWithPercent() { Name = "Множина джерел появи вартісних ризиків", min =0, max=100, Value = Randomize(), IsHeader=true, Number = "2"},
                new Row() { Name = "Обмеження сумарного бюджету на програмний проект,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.1"},
                new Row() { Name = "Недоступна вартість реалізації програмного проекту,", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.2"},
                new Row() { Name = "Низька ступінь реалізму при оцінюванні витрат на програмний проект", Value = Randomize(), GroupName="Множина джерел появи вартісних ризиків", Number = "2.3"},

                new RowWithPercent() { Name = "Множина джерел появи планових ризиків", min =0, max=100, Value = Randomize(), IsHeader=true, Number = "3"},
                new Row() { Name = "Властивості та можливості гнучкості внесення змін до планів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.1"},
                new Row() { Name = "Можливості порушення встановлених термінів реалізації етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.2"},
                new Row() { Name = "Низька ступінь реалізму при встановленні планів і етапів життєвого циклу розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи планових ризиків", Number = "3.3"},

                new RowWithPercent() { Name = "Множина джерел появи ризиків реалізації процесу управління програмним проектом", min =0, max=100, Value = Randomize(), IsHeader=true, Number = "4"},
                new Row() { Name = "Хибна стратегія реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.1"},
                new Row() { Name = "Неефективне планування проекту розроблення ПЗ", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.2"},
                new Row() { Name = "Неякісне оцінювання програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.3"},
                new Row() { Name = "Прогалини в документуванні етапів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.4"},
                new Row() { Name = "Промахи в прогнозуванні результатів реалізації програмного проекту", Value = Randomize(), GroupName="Множина джерел появи ризиків реалізації процесу управління програмним проектом", Number = "4.5"},

                new RowWithTotal() { Name = "Сума", Value = Randomize(), min =0, max=100, IsHeader = true, GroupName="", Number = ""},
            };

            //recalculating values for first table
            RecalculateFirstTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //initializing second table
        void InitializeSecondTable()
        {
            //creating rows
            SecondTableRows = new ObservableCollection<Row>
            {
                new RowWithPercent() { Name = "Множина настання технічних ризикових подій", min =0, max=100, Value = 0, IsHeader=true, Number = "1"},
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

                new RowWithPercent() { Name = "Множина настання вартісних ризикових подій", min =0, max=100, Value = 0, IsHeader = true, Number = "2"},
                new Row() { Name = "Недо(пере)оцінювання витрат на реалізацію програмного проекту (надмірно низька вартість)", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.1"},
                new Row() { Name = "Фінансові ускладнення у компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.2"},
                new Row() { Name = "Фінансові ускладнення у компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.3"},
                new Row() { Name = "Змен(збіль)шення бюджету програмного проекта з ініціативи компанії-замовника ПЗ під час його реалізації", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.4"},
                new Row() { Name = "Висока вартість виконання повторних робіт, необхідних для зміни вимог до ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.5"},
                new Row() { Name = "Реорганізація структурних підрозділів у компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.6"},
                new Row() { Name = "Реорганізація команди виконавців у компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання вартісних ризикових подій", Number = "2.7"},

                new RowWithPercent() { Name = "Множина настання планових ризикових подій", min =0, max=100, Value = 0, IsHeader = true, Number = "3"},
                new Row() { Name = "Зміни графіка виконання робіт з боку замовника чи розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.1"},
                new Row() { Name = "Порушення графіка виконання робіт з боку компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.2"},
                new Row() { Name = "Потреба зміни користувацьких вимог до ПЗ з боку компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.3"},
                new Row() { Name = "Потреба зміни функціональних вимог до ПЗ з боку компанії-розробника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.4"},
                new Row() { Name = "Потреба виконання великої кількості повторних робіт, необхідних для зміни вимог до ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.5"},
                new Row() { Name = "Недо(пере)оцінювання тривалості етапів реалізації програмного проекту з боку компанії-замовника ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.6"},
                new Row() { Name = "Остаточний розмір ПЗ значно перевищує (менший від) заплановані(их) його характеристики", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.7"},
                new Row() { Name = "Поява на ринку аналогічного ПЗ до виходу замовленого", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.8"},
                new Row() { Name = "Поява на ринку більш конкурентоздатного ПЗ", Value = Randomize(), GroupName="Множина настання планових ризикових подій", Number = "3.9"},

                new RowWithPercent() { Name = "Множина настання ризикових подій реалізації процесу управління програмним проектом", min =0, max=100, Value = 0, IsHeader = true, Number = "4"},
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

                new RowWithTotal() { Name = "Сума", Value = Randomize(), min =0, max=100, IsHeader = true, GroupName="", Number = ""},
            };

            //recalculating values for second table
            RecalculateSecondTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //initializing table with expert coefs #1
        void InitializeExpertCoefsTable()
        {
            //creating rows
            ExpertCoefs = new ObservableCollection<RowWithExpertMarks>
            {
                new RowWithExpertMarks
                {
                    Name = "Множина настання технічних ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання технічних ризикових подій"),
                    Number = "1",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання вартісних ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання вартісних ризикових подій"),
                    Number = "2",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання планових ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання планових ризикових подій"),
                    Number = "3",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання ризикових подій реалізації процесу управління програмним проектом",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання ризикових подій реалізації процесу управління програмним проектом"),
                    Number = "4",
                },
                new RowWithExpertMarks
                {
                    Name = "Сума",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = 0,
                    Number = "Σ",
                    ExpertCoefficients = new ObservableCollection<double?>(Enumerable.Repeat((double?)null,10))
                }
            };

            //randomizing expert coefs
            this.RandomizeExpertCoefs();
        }

        void InitializeExpertCoefsTable2()
        {
            //creating rows
            ExpertCoefs2 = new ObservableCollection<RowWithExpertMarks>
            {
                new RowWithExpertMarks
                {
                    Name = "Множина настання технічних ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання технічних ризикових подій"),
                    Number = "1",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання вартісних ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання вартісних ризикових подій"),
                    Number = "2",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання планових ризикових подій",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання планових ризикових подій"),
                    Number = "3",
                },
                new RowWithExpertMarks
                {
                    Name = "Множина настання ризикових подій реалізації процесу управління програмним проектом",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = SecondTableRows.Count(x=>x.GroupName == "Множина настання ризикових подій реалізації процесу управління програмним проектом"),
                    Number = "4",
                },
                new RowWithExpertMarks
                {
                    Name = "Сума",
                    IsHeader = true,
                    min = 0,
                    max =100,
                    Value = 0,
                    Number = "Σ",
                    ExpertCoefficients = new ObservableCollection<double?>(Enumerable.Repeat((double?)null,10))
                }
            };

            //randomizing expert coefs
            this.RandomizeExpertCoefs2();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //initializing table with expert marks #1
        void InitializeExpertMarksTable()
        {
            //creating rows
            ExpertMarks = new ObservableCollection<RowWithExpertMarks>();

            ExpertMarks.Add(new RowWithExpertMarks()
            {
                ExpertCoefficients = new ObservableCollection<double?>(ExpertCoefs[0].ExpertCoefficients.ToList()),
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs[0].Name,
                Number = "1",
                Value = ExpertCoefs[0].Value,
                GroupName = ""
            });

            ExpertMarks = new ObservableCollection<RowWithExpertMarks>(ExpertMarks.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks[0].Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks.Add(new RowWithExpertMarks()
            {
                ExpertCoefficients = new ObservableCollection<double?>(ExpertCoefs[1].ExpertCoefficients.ToList()),
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs[1].Name,
                Number = "2",
                Value = ExpertCoefs[1].Value,
                GroupName = ""
            });

            ExpertMarks = new ObservableCollection<RowWithExpertMarks>(ExpertMarks.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks.Add(new RowWithExpertMarks()
            {
                ExpertCoefficients = new ObservableCollection<double?>(ExpertCoefs[2].ExpertCoefficients.ToList()),
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs[2].Name,
                Number = "3",
                Value = ExpertCoefs[2].Value,
                GroupName = ""
            });

            ExpertMarks = new ObservableCollection<RowWithExpertMarks>(ExpertMarks.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks.Add(new RowWithExpertMarks()
            {
                ExpertCoefficients = new ObservableCollection<double?>(ExpertCoefs[3].ExpertCoefficients.ToList()),
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs[3].Name,
                Number = "4",
                Value = ExpertCoefs[3].Value,
                GroupName = ""
            });

            ExpertMarks = new ObservableCollection<RowWithExpertMarks>(ExpertMarks.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks.Add(new RowWithExpertMarks()
            {
                ExpertCoefficients = new ObservableCollection<double?>(Enumerable.Repeat((double?)null, 100)),
                max = 100,
                min = 1,
                IsHeader = true,
                Name = "",
                Number = "Σ",
                Value = 0,
            });

            //randomizing expert marks
            RandomizeExpertMarks();
        }

        //initializing table with expert marks #1
        void InitializeExpertMarksTable2()
        {
            //creating rows
            ExpertMarks2 = new ObservableCollection<RowWithExpertMarks>();

            ExpertMarks2.Add(new RowWithExpertMarks()
            {
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs2[0].Name,
                Number = "1",
                Value = ExpertCoefs2[0].Value,
                GroupName = ""
            });

            ExpertMarks2 = new ObservableCollection<RowWithExpertMarks>(ExpertMarks2.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks2[0].Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks2.Add(new RowWithExpertMarks()
            {
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs2[1].Name,
                Number = "2",
                Value = ExpertCoefs2[1].Value,
                GroupName = ""
            });

            ExpertMarks2 = new ObservableCollection<RowWithExpertMarks>(ExpertMarks2.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks2.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks2.Add(new RowWithExpertMarks()
            {
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs2[2].Name,
                Number = "3",
                Value = ExpertCoefs2[2].Value,
                GroupName = ""
            });

            ExpertMarks2 = new ObservableCollection<RowWithExpertMarks>(ExpertMarks2.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks2.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            ExpertMarks2.Add(new RowWithExpertMarks()
            {
                max = 100,
                min = 1,
                IsHeader = true,
                Name = ExpertCoefs2[3].Name,
                Number = "4",
                Value = ExpertCoefs2[3].Value,
                GroupName = ""
            });

            ExpertMarks2 = new ObservableCollection<RowWithExpertMarks>(ExpertMarks2.Union(SecondTableRows.Where(x => x.GroupName == ExpertMarks2.Last().Name).Select(x => new RowWithExpertMarks()
            {
                GroupName = x.GroupName,
                Name = x.Name,
                Value = x.Value,
                IsHeader = false,
                Number = x.Number,
            })));

            //randomizing expert marks
            RandomizeExpertMarks2();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //initializing table with solutions
        void InitializeSolutionTableRows()
        {
            //creating rows
            SolutionsTableRows = new ObservableCollection<SolutionRow>
            {
                new SolutionRow(){ Number=1, Name = "Попереднє навчання членів проектного колективу", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=2, Name = "Узгодження детального переліку вимог до ПЗ із замовником", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=3, Name = "Внесення узгодженого переліку вимог до ПЗ замовника в договір", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=4, Name = "Точне слідування вимогам замовника з узгодженого переліку вимог до ПЗ", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=5, Name = "Попередні дослідження ринку", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=6, Name = "Експертна оцінка програмного проекту досвідченим стороннім консультантом", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=7, Name = "Консультації досвідченого стороннього консультанта", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=8, Name = "Тренінг з вивчення необхідних інструментів розроблення ПЗ", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=9, Name = "Укладання договору страхування", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=10, Name = "Використання 'шаблонних' рішень з вдалих попередніх проектів при управлінні програмним проектом", col1 = "", col2 = "", col3 = "", col4 = ""},

                new SolutionRow(){ Number=11, Name = "Підготовка документів, які показують важливість даного проекту для досягнення фінансових цілей компанії-розробника", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=12, Name = "Реорганізація роботи проектного колективу так, щоб обов'язки та робота членів колективу перекривали один одного", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=13, Name = "Придбання (замовлення) частини компонент розроблюваного ПЗ", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=14, Name = "Заміна потенційно дефектних компонент розроблюваного ПЗ придбаними компонентами, які гарантують якість виконання роботи", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=15, Name = "Придбання більш продуктивної бази даних", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=16, Name = "Використання генератора програмного коду", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=17, Name = "Реорганізація роботи проектного колективу залежно від рівня труднощів виконання завдань та професійних рівнів розробників", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=18, Name = "Повторне використання придатних компонент ПЗ, які були розроблені для інших програмних проектів", col1 = "", col2 = "", col3 = "", col4 = ""},
                new SolutionRow(){ Number=19, Name = "Аналіз доцільності розроблення даного ПЗ", col1 = "", col2 = "", col3 = "", col4 = ""},
            };
        }

        public void InitializeStrangeTable()
        {
            this.StrangeTable = new ObservableCollection<RowWithExpertMarks>(){
                new RowWithExpertMarks(),
                new RowWithExpertMarks() };
            this.CalculateStrangeTable();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //RANDOMIZATION VALUES
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //randomizing decimal values
        double Randomize()
        {
            return rand.NextDouble();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //randomizing expert coefs
        void RandomizeExpertCoefs()
        {
            foreach (var row in ExpertCoefs.Take(4))
            {
                for (var i = 0; i < row.ExpertCoefficients.Count; i++)
                {
                    row.ExpertCoefficients[i] = rand.Next(1, 11);
                }
            }
            ExpertCoefs.Last().Value = ExpertCoefs.Take(4).Sum(x => x.Value);
        }

        //randomizing expert coefs
        void RandomizeExpertCoefs2()
        {
            foreach (var row in ExpertCoefs2.Take(4))
            {
                for (var i = 0; i < row.ExpertCoefficients.Count; i++)
                {
                    row.ExpertCoefficients[i] = rand.Next(1, 11);
                }
            }
            ExpertCoefs2.Last().Value = ExpertCoefs.Take(4).Sum(x => x.Value);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //randomizing expert marks
        void RandomizeExpertMarks()
        {
            foreach (var row in ExpertMarks.Where(x => !x.IsHeader))
            {
                for (var i = 0; i < 10; i++)
                {
                    row.ExpertCoefficients[i] = rand.NextDouble();
                }
            }

            //calculating values for expert marks
            CalculateExpertMarksTable();
        }

        void RandomizeExpertMarks2()
        {
            foreach (var row in ExpertMarks2.Where(x => x.IsHeader))
            {
                row.ExpertCoefficients[0] = rand.Next(0, 10000);
            }
            foreach (var row in ExpertMarks2.Where(x => !x.IsHeader))
            {
                for (var i = 0; i < 11; i++)
                {
                    row.ExpertCoefficients[i] = rand.NextDouble();
                    if (i == 0)
                    {
                        row.ExpertCoefficients[i] *= ExpertMarks2.FirstOrDefault(x => x.Name == row.GroupName).ExpertCoefficients[0] * 0.15;
                    }
                }
            }

            //calculating values for expert marks
            CalculateExpertMarksTable2();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //RECALCULATING TABLE VALUES
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //recalculating values in first table after changes of random values
        void RecalculateFirstTableRows()
        {
            int forCount = FirstTableRows.Count() - FirstTableRows.Count(x => x is RowWithPercent || x is RowWithTotal);

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

        //recalculating values in second table after changes of random values
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

        //recalculating values in table with expert marks after changes of random values
        void CalculateExpertMarksTable()
        {
            for (int i = 0; i < 4; i++)
            {
                var row = ExpertMarks.Where(x => x.IsHeader).ElementAt(i);
                for (int j = 0; j < 10; j++)
                    row.ExpertCoefficients[j] =
                         ExpertCoefs[i].ExpertCoefficients[j];
                row.ExpertCoefficients[10] = row.ExpertCoefficients.Take(10).Sum();
            }
            foreach (var row in ExpertMarks.Where(x => !x.IsHeader))
            {
                row.ExpertCoefficients[10] = row.ExpertCoefficients.Take(10).Average();
                for (int i = 11; i < 21; i++)
                {
                    row.ExpertCoefficients[i] = row.ExpertCoefficients[i - 11] *
                                                ExpertMarks.First((x => x.Name == row.GroupName))
                                                    .ExpertCoefficients[i - 11];
                }
                row.ExpertCoefficients[21] = row.ExpertCoefficients.Skip(11).Take(10).Sum() / ExpertMarks
                                                 .First((x => x.Name == row.GroupName))
                                                 .ExpertCoefficients[10];
            }

            foreach (var row in ExpertMarks.Where(x => x.IsHeader))
            {
                for (int i = 11; i < 21; i++)
                {
                    row.ExpertCoefficients[i] =
                        ExpertMarks.Where(x => x.GroupName == row.Name).Average(x => x.ExpertCoefficients[i]) /
                        row.ExpertCoefficients[i - 11];
                }
                row.ExpertCoefficients[21] = row.ExpertCoefficients.Skip(11).Take(10).Average();
            }

            foreach (var row in ExpertMarks)
            {
                var last = row.ExpertCoefficients[21];
                if (last < 0.1)
                {
                    row.Level = "Дуже низькою";
                }
                else if (last < 0.25)
                {
                    row.Level = "Низькою";
                }
                else if (last < 0.5)
                {
                    row.Level = "Середньою";
                }
                else if (last < 0.75)
                {
                    row.Level = "Високою";
                }
                else
                {
                    row.Level = "Дуже високою";
                }
            }
            ExpertMarks.Last().Value = ExpertMarks.Where(x => !x.IsHeader).Sum(x => x.Value);
            ExpertMarks.Last().Level = "";
            ExpertMarks.Last().Name = "Сума";

        }

        void CalculateExpertMarksTable2()
        {
            for (int i = 0; i < 4; i++)
            {
                var row = ExpertMarks2.Where(x => x.IsHeader).ElementAt(i);
                for (int j = 0; j < 10; j++)
                    row.ExpertCoefficients[j + 1] =
                         ExpertCoefs2[i].ExpertCoefficients[j];
                row.ExpertCoefficients[11] = row.ExpertCoefficients.Skip(1).Take(10).Sum();
            }
            foreach (var row in ExpertMarks2.Where(x => !x.IsHeader))
            {
                row.ExpertCoefficients[11] = row.ExpertCoefficients.Skip(1).Take(10).Average() * row.ExpertCoefficients[0];
                for (int i = 12; i < 22; i++)
                {
                    row.ExpertCoefficients[i] = row.ExpertCoefficients[i - 11] *
                                                ExpertMarks2.First((x => x.Name == row.GroupName))
                                                    .ExpertCoefficients[i - 11];
                }
            }

            foreach (var row in ExpertMarks2.Where(x => x.IsHeader))
            {
                for (int i = 12; i < 22; i++)
                {
                    row.ExpertCoefficients[i] =
                        ExpertMarks2.Where(x => x.GroupName == row.Name).Average(x => x.ExpertCoefficients[i]) /
                        row.ExpertCoefficients[i - 11];
                }
            }
            foreach (var row in ExpertMarks2.Where(x => !x.IsHeader))
            {
                row.ExpertCoefficients[22] = row.ExpertCoefficients.Skip(12).Take(10).Sum() / ExpertMarks2.FirstOrDefault(x => x.Name == row.GroupName).ExpertCoefficients[11] * row.ExpertCoefficients[0];
                row.ExpertCoefficients[23] = row.ExpertCoefficients[0] + row.ExpertCoefficients[22];
            }

            foreach (var row in ExpertMarks2.Where(x => x.IsHeader))
            {
                row.ExpertCoefficients[22] = ExpertMarks2.Where(x => x.GroupName == row.Name).Sum(x => x.ExpertCoefficients[22]);
                row.ExpertCoefficients[23] = row.ExpertCoefficients[0] + row.ExpertCoefficients[22];
            }

            var min = ExpertMarks2.Where(x => !x.IsHeader).Min(x => x.ExpertCoefficients[22]);
            var max = ExpertMarks2.Where(x => !x.IsHeader).Max(x => x.ExpertCoefficients[22]);
            var step = max - min;
            step /= 3;
            foreach(var row in ExpertMarks2.Where(x => !x.IsHeader))
            {
                row.Level = row.ExpertCoefficients[22] <= min + step ? "Низький" :
                    row.ExpertCoefficients[22] <= min + step * 2 ? "Середній" :
                    "Високий";
            }

        }

        void CalculateStrangeTable()
        {
            StrangeTable[0] =
                new RowWithExpertMarks
                {
                    Name = "Початкова вартість реалізації проекту",
                    max=100000000000000,
                    ExpertCoefficients = new ObservableCollection<double?>
                    {
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(0).ExpertCoefficients[0],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(1).ExpertCoefficients[0],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(2).ExpertCoefficients[0],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(3).ExpertCoefficients[0]
                    }
                };
            StrangeTable[0].Value = StrangeTable[0].ExpertCoefficients.Sum().GetValueOrDefault();
            StrangeTable[1] = new RowWithExpertMarks
            {
                Name = "Кінцева вартість реалізації проекту",
                    max=100000000000000,
                ExpertCoefficients = new ObservableCollection<double?>
                    {
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(0).ExpertCoefficients[23],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(1).ExpertCoefficients[23],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(2).ExpertCoefficients[23],
                        ExpertMarks2.Where(x=>x.IsHeader).ElementAt(3).ExpertCoefficients[23],
                    }
            };
            StrangeTable[1].Value = StrangeTable[1].ExpertCoefficients.Sum().Value;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //GENERATING RANDOM VALUES FOR ALL TABLES
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //randomizing everything
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //generating random values for all tables
            GenerateFirstTableRows();
            GenerateSecondTableRows();
            RandomizeExpertCoefs();
            RandomizeExpertCoefs2();
            RandomizeExpertMarks();
            RandomizeExpertMarks2();
            CalculateStrangeTable();


            //indicating that tables were changed
            OnPropertyChanged(nameof(FirstTableRows));
            OnPropertyChanged(nameof(SecondTableRows));
            OnPropertyChanged(nameof(ExpertCoefs));
            OnPropertyChanged(nameof(ExpertCoefs2));
            OnPropertyChanged(nameof(ExpertMarks));
            OnPropertyChanged(nameof(ExpertMarks2));
            OnPropertyChanged(nameof(StrangeTable));
            OnPropertyChanged(nameof(RowWithExpertMarks.ExpertCoefficients));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //generating random values for whole first table
        void GenerateFirstTableRows()
        {
            foreach (var item in FirstTableRows)
            {
                item.Value = Randomize();
            }

            //recalculating values for first table
            RecalculateFirstTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //generating random values for whole second table
        void GenerateSecondTableRows()
        {
            foreach (var item in SecondTableRows)
            {
                item.Value = Randomize();
            }

            //recalculating values for second table
            RecalculateSecondTableRows();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //AFTER CHANGING SOMETHING
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //after updating first table
        private void FirstTable_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            RecalculateFirstTableRows();
            OnPropertyChanged(nameof(FirstTableRows));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //after updating second table
        private void SecondTable_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            RecalculateSecondTableRows();
            OnPropertyChanged(nameof(SecondTableRows));

            //randomizing expert marks
            RandomizeExpertMarks();
            OnPropertyChanged(nameof(ExpertMarks));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //after updating framewoork element
        private void FrameworkElement_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            foreach (var row in ExpertCoefs)
            {
                for(int i=0;i<row.ExpertCoefficients.Count;i++)
                    if (row.ExpertCoefficients[i] > 10) row.ExpertCoefficients[i] = 10;
            }
            this.CalculateExpertMarksTable();

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void DataGrid_SourceUpdated_1(object sender, DataTransferEventArgs e)
        {
            foreach (var row in ExpertCoefs2)
            {
                for (int i = 0; i < row.ExpertCoefficients.Count; i++)
                    if (row.ExpertCoefficients[i] > 10) row.ExpertCoefficients[i] = 10;
            }

            this.CalculateExpertMarksTable2();
            this.CalculateStrangeTable();
            OnPropertyChanged(nameof(FirstTableRows));
            OnPropertyChanged(nameof(SecondTableRows));
            OnPropertyChanged(nameof(ExpertCoefs));
            OnPropertyChanged(nameof(ExpertCoefs2));
            OnPropertyChanged(nameof(ExpertMarks));
            OnPropertyChanged(nameof(ExpertMarks2));
            OnPropertyChanged(nameof(RowWithExpertMarks.ExpertCoefficients));
            OnPropertyChanged(nameof(StrangeTable));
        }
    }
}