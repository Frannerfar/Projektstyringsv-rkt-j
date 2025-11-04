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

namespace Projektstyring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======
            // Efter lidt research, så skal vi bruge Color fra System.Windows.Media, da det er til WPF.
            // Har lavet eksempler på de 3 stages, som alle tager imod colors på forskellige måder.
            // Vi kan gennemgå det sammen, hvis der er spørgsmål til color codes.

            List<Stage> stages = new List<Stage>();

            // RGBA Color
            Stage notdoing = new Stage("Not Doing", Color.FromArgb(100, 100, 100, 100));
        
            // HEX Color
            Stage doing = new Stage("Doing", (Color)ColorConverter.ConvertFromString("#FFB0B0B0"));

            // Pre-defineret colors i .NET WPF
            Stage done = new Stage("Done", Colors.Green);

            // Dinas tilføjelse af en ny stage, i HEX Color
            Stage dinaiseret = new Stage("Dinaiset", (Color)ColorConverter.ConvertFromString("#FFFF00FF"));

            stages.Add(notdoing);
            stages.Add(doing);
            stages.Add(done);
            stages.Add(dinaiseret);


            // Jeg har ændet Class navn fra Task til TaskItem, da Task er type til async operationer, som vi ikke har været igennem.
            // TODO: Vi mangler at lave constructor, så hver task bliver oprettet korrekt og derefter kan tilføjes til Stage liste.

            TaskItem test = new TaskItem(
<<<<<<< Updated upstream
                "Feje gulv", 
                "Gulvet skal fejes grundigt", 
                "Konrad", 
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                Colors.Red, 
                Colors.Blue);
=======
                "Feje gulv",
                "Gulvet skal fejes grundigt",
                "Konrad",
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                Colors.Green,
                Colors.Blue, 
                notdoing);
>>>>>>> Stashed changes

            TaskItem indkoeb = new TaskItem(
                "Indkøb",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
<<<<<<< Updated upstream
                Colors.Red,
                Colors.Black);

=======
                Colors.DarkMagenta,
                Colors.Black, 
                dinaiseret);

            TaskItem indkoeb1 = new TaskItem(
               "Indkøb",
               "Ja",
               "Dinasaur",
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
               Colors.Yellow,
               Colors.Black, 
               dinaiseret);
>>>>>>> Stashed changes

            TaskItem indkoeb2 = new TaskItem(
                "Indkøb",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
<<<<<<< Updated upstream
                Colors.Red,
                Colors.Black);
=======
                Colors.Blue,
                Colors.Black, 
                dinaiseret);
>>>>>>> Stashed changes

            TaskItem indkoeb3 = new TaskItem(
                "wfafafwfafwffaff",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black, 
                dinaiseret);


            TaskItem indkoeb4 = new TaskItem(
                "fwffwwfafffw",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black, 
                dinaiseret);


            TaskItem indkoeb5 = new TaskItem(
                "dwddaddwd",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Red,
                Colors.Black, 
                dinaiseret);

            TaskItem igang = new TaskItem(
                "Igang",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Yellow,
                Colors.Black, 
                doing);

            TaskItem igang2 = new TaskItem(
                "Underway",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Yellow,
                Colors.Black, 
                doing);

            TaskItem klaret = new TaskItem(
                "Færdig",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Green,
                Colors.Black, 
                done);

            TaskItem klaret2 = new TaskItem(
                "Klaret",
                "Ja",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 15)),
                Colors.Green,
                Colors.Black, 
                done);

<<<<<<< Updated upstream
=======
            TaskItem juleshoppetur = new TaskItem(
                "hohoho",
                "Nu er det snart jul igen",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White, 
                julehygge);

            TaskItem juleshoppetur2 = new TaskItem(
                "ho hoho",
                "Dinasaur",
                "Hvad du ønsker skal du få",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White, 
                julehygge);

            TaskItem juleshoppetur3 = new TaskItem(
                "ho ho ho",
                "Julegaveindkøb: Kul",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White, 
                julehygge);

            TaskItem juleshoppetur4 = new TaskItem(
                "ho  ho  ho",
                "Indkøbsliste: Glögg, mandler, æbleskiver, grødris",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White,
                julehygge);

            TaskItem juleshoppetur5 = new TaskItem(
                "ho   ho   ho",
                "Huhuuuu.. Nu er det snart jul",
                "Dinasaur",
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White,
                julehygge);

>>>>>>> Stashed changes



            notdoing.tasks.Add(test);

<<<<<<< Updated upstream
            for(int i = 0; i < stages.Count; i++)
=======
            doing.tasks.Add(igang);
            doing.tasks.Add(igang2);

            done.tasks.Add(klaret);
            done.tasks.Add(klaret);

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
            ViewGrid.Children.Clear();

            Grid KanbanBoard = new Grid
>>>>>>> Stashed changes
            {
                ListBox listbox = new ListBox();
                listbox.Width = 200;

                StackOfLists.Children.Add(listbox);

                for(int j = 0; j < stages[i].tasks.Count; j++)
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Margin = new Thickness(10);

                    TextBlock title = new TextBlock();
                    TextBlock text = new TextBlock();
                    TextBlock responsible = new TextBlock();
                    TextBlock startDate = new TextBlock();
                    TextBlock endDate = new TextBlock();

                    title.Text = stages[i].tasks[j].title;
                    text.Text = stages[i].tasks[j].text;
                    responsible.Text = stages[i].tasks[j].responsibleName;
                    startDate.Text = $"{stages[i].tasks[j].startDateTime}";
                    endDate.Text = $"{stages[i].tasks[j].endDateTime}";

                    stackPanel.Children.Add(title);
                    stackPanel.Children.Add(text);
                    stackPanel.Children.Add(responsible);
                    stackPanel.Children.Add(startDate);
                    stackPanel.Children.Add(endDate);

                    ListBoxItem item = new ListBoxItem();
                    item.Content = stackPanel;
                    item.BorderBrush = new SolidColorBrush(stages[i].tasks[j].borderColor);
                    item.BorderThickness = new Thickness(2);

                    item.Background = new SolidColorBrush(stages[i].tasks[j].backgroundColor);
                    listbox.Items.Add(item);
<<<<<<< Updated upstream
                }
            }

=======

                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Vi deleter en ting eller et eller andet");

            Button button = (Button)sender;
            TaskItem task = (TaskItem)button.Tag;
            
            task.stage.tasks.Remove(task);
            task.stage = null;
            DrawKanban();
        }
>>>>>>> Stashed changes

            doing.tasks.Add(igang);
            doing.tasks.Add(igang2);

            //for (int i = 0; i < doing.tasks.Count; i++)
            //{
            //    StackPanel panel = new StackPanel();
            //    panel.Margin = new Thickness(10);

            //    TextBlock title = new TextBlock();
            //    TextBlock text = new TextBlock();
            //    TextBlock responsible = new TextBlock();
            //    TextBlock startDate = new TextBlock();
            //    TextBlock endDate = new TextBlock();

            //    title.Text = doing.tasks[i].title;
            //    text.Text = doing.tasks[i].text;
            //    responsible.Text = doing.tasks[i].responsibleName;
            //    startDate.Text = $"{doing.tasks[i].startDateTime}";
            //    endDate.Text = $"{doing.tasks[i].endDateTime}";

            //    panel.Children.Add(title);
            //    panel.Children.Add(text);
            //    panel.Children.Add(responsible);
            //    panel.Children.Add(startDate);
            //    panel.Children.Add(endDate);

            //    ListBoxItem item = new ListBoxItem();
            //    item.Content = panel;
            //    DoingList.Items.Add(item);

            //    item.Background = new SolidColorBrush(doing.backgroundColor);
            //}

            done.tasks.Add(klaret);
            done.tasks.Add(klaret2);

            //for(int i = 0; i < done.tasks.Count; i++)
            //{
            //    StackPanel stackPanel = new StackPanel();
            //    stackPanel.Margin = new Thickness(10);

            //    TextBlock title = new TextBlock();
            //    TextBlock text = new TextBlock();
            //    TextBlock responsible = new TextBlock();
            //    TextBlock startDate = new TextBlock();
            //    TextBlock endDate = new TextBlock();

            //    title.Text = done.tasks[i].title;
            //    text.Text = done.tasks[i].text;
            //    responsible.Text = done.tasks[i].responsibleName;
            //    startDate.Text = $"{done.tasks[i].startDateTime}";
            //    endDate.Text = $"{done.tasks[i].endDateTime}";

            //    stackPanel.Children.Add(title);
            //    stackPanel.Children.Add(text);
            //    stackPanel.Children.Add(responsible);
            //    stackPanel.Children.Add(startDate);
            //    stackPanel.Children.Add(endDate);

            //    ListBoxItem item = new ListBoxItem();
            //    item.Content = stackPanel;
            //    DoneList.Items.Add(item);

            //    item.Background = new SolidColorBrush(done.backgroundColor);
            //}
>>>>>>> Stashed changes
        }
    }
}