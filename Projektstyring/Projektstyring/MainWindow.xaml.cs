using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projektstyring.Models;

namespace Projektstyring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Stage> stages = new List<Stage>();
        public MainWindow()
        {
            InitializeComponent();
            // Efter lidt research, så skal vi bruge Color fra System.Windows.Media, da det er til WPF.
            // Har lavet eksempler på de 3 stages, som alle tager imod colors på forskellige måder.
            // Vi kan gennemgå det sammen, hvis der er spørgsmål til color codes.

           

            // RGBA Color
            Stage notdoing = new Stage("Not Doing", Color.FromArgb(100, 100, 100, 100));

            // HEX Color
            Stage doing = new Stage("Doing", (Color)ColorConverter.ConvertFromString("#FFB0B0B0"));

            // Pre-defineret colors i .NET WPF
            Stage done = new Stage("Done", Colors.Green);

            // Dinas tilføjelse af en ny stage, i HEX Color
            Stage dinaiseret = new Stage("Dinaiset", (Color)ColorConverter.ConvertFromString("#FFFF00FF"));

            // Dinas tilføjelse af endnu en ny stage, i HEX Color
            Stage julehygge = new Stage("Julehygge", (Color)ColorConverter.ConvertFromString("#80FF00FF"));


            stages.Add(notdoing);
            stages.Add(doing);
            stages.Add(done);
            stages.Add(dinaiseret);
            stages.Add(julehygge);

            // Jeg har ændet Class navn fra Task til TaskItem, da Task er type til async operationer, som vi ikke har været igennem.
            // TODO: Vi mangler at lave constructor, så hver task bliver oprettet korrekt og derefter kan tilføjes til Stage liste.

            TaskItem test = new TaskItem(
                "Feje gulv",
                "Gulvet skal fejes grundigt",
                "Konrad",
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                Colors.Green,
                Colors.Blue);

            TaskItem indkoeb = new TaskItem(
                "Indkøb",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.DarkMagenta,
                Colors.Black);

            TaskItem indkoeb1 = new TaskItem(
               "Indkøb",
               "Ja",
               "Dinasaur",
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               Colors.Yellow,
               Colors.Black);

            TaskItem indkoeb2 = new TaskItem(
                "Indkøb",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Blue,
                Colors.Black);

            TaskItem indkoeb3 = new TaskItem(
                "wfafafwfafwffaff",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black);


            TaskItem indkoeb4 = new TaskItem(
                "fwffwwfafffw",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black);


            TaskItem indkoeb5 = new TaskItem(
                "dwddaddwd",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black);

            TaskItem igang = new TaskItem(
                "Igang",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Yellow,
                Colors.Black);

            TaskItem igang2 = new TaskItem(
                "Underway",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Yellow,
                Colors.Black);

            TaskItem klaret = new TaskItem(
                "Færdig",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Green,
                Colors.Black);

            TaskItem klaret2 = new TaskItem(
                "Klaret",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Green,
                Colors.Black);

            TaskItem juleshoppetur = new TaskItem(
                "hohoho",
                "Nu er det snart jul igen",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White);

                "ho hoho",
            TaskItem juleshoppetur2 = new TaskItem(
                "Dinasaur",
                "Hvad du ønsker skal du få",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White);

            TaskItem juleshoppetur3 = new TaskItem(
                "ho ho ho",
                "Julegaveindkøb: Kul",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White);

            TaskItem juleshoppetur4 = new TaskItem(
                "ho  ho  ho",
                "Indkøbsliste: Glögg, mandler, æbleskiver, grødris",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White);

            TaskItem juleshoppetur5 = new TaskItem(
                "ho   ho   ho",
                "Huhuuuu.. Nu er det snart jul",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White);




            notdoing.tasks.Add(test);
            notdoing.tasks.Add(indkoeb);
            notdoing.tasks.Add(indkoeb2);
            notdoing.tasks.Add(indkoeb3);
            notdoing.tasks.Add(indkoeb4);
            notdoing.tasks.Add(indkoeb5);


            dinaiseret.tasks.Add(indkoeb);
            dinaiseret.tasks.Add(indkoeb1);
            dinaiseret.tasks.Add(indkoeb2);
            dinaiseret.tasks.Add(indkoeb3);
            dinaiseret.tasks.Add(indkoeb4);

            julehygge.tasks.Add(juleshoppetur);
            julehygge.tasks.Add(juleshoppetur2);
            julehygge.tasks.Add(juleshoppetur3);
            julehygge.tasks.Add(juleshoppetur4);
            julehygge.tasks.Add(juleshoppetur5);

            DrawKanban();
            


            //for (int i = 0; i < notdoing.tasks.Count; i++)
            //{
            //    NotDoingList.Items.Add(notdoing.tasks[i].title);
            //}

            //for (int i = 0; i < julehygge.tasks.Count; i++)
            //{
            //    JulehyggeList.Items.Add(julehygge.tasks[i].title);
            //}



        } 
        private void DrawKanban()
        {
            KanbanBoard.Children.Clear();
            for (int i = 0; i < stages.Count; i++)
            {
                ListBox listbox = new ListBox();
                listbox.Width = 200;

                KanbanBoard.Children.Add(listbox);

                for (int j = 0; j < stages[i].tasks.Count; j++)
                {
                    //DinaiseretList.Items.Add(dinaiseret.tasks[i].title);

                    //Laver et variabel der hedder item af typen listboxitem

                    ListBoxItem item = new ListBoxItem();

                    StackPanel stackPanel = new StackPanel();

                    Button deleteButton = new Button();

                    deleteButton.Content = "Slet";
                    deleteButton.Click += DeleteButton_Click;
                    deleteButton.Tag = stages[i].tasks[j];

                    TextBlock title = new TextBlock();
                    title.Text = stages[i].tasks[j].title;

                    TextBlock responsible = new TextBlock();
                    responsible.Text = stages[i].tasks[j].responsibleName;

                    TextBlock text = new TextBlock();
                    text.Text = stages[i].tasks[j].text;

                    TextBlock datetime = new TextBlock();
                    datetime.Text = $"startdato {stages[i].tasks[j].startDateTime}";

                    stackPanel.Children.Add(deleteButton);
                    stackPanel.Children.Add(title);
                    stackPanel.Children.Add(responsible);
                    stackPanel.Children.Add(text);
                    stackPanel.Children.Add(datetime);
                    item.Background = new SolidColorBrush(stages[i].tasks[j].backgroundColor);
                    item.Margin = new Thickness(10);
                    item.BorderBrush = new SolidColorBrush(stages[i].tasks[j].borderColor);
                    item.BorderThickness = new Thickness(2);

                    item.Content = stackPanel;
                    listbox.Items.Add(item);

                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Vi deleter en ting eller et eller andet");

            Button button = (Button)sender;
            TaskItem task = (TaskItem)button.Tag;

            for(int i = 0; i < stages.Count; i++)
            {

                if(stages[i].tasks.Contains(task))
                {
                    stages[i].tasks.Remove(task);
                    DrawKanban();
                    break;
                }
            }

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Modal window = new Modal();
            window.ShowDialog();
        }
    }
}