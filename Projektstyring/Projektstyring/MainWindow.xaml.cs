using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
        //Dictionary<Stage, ListBox> stageListBoxes = new();

        public MainWindow()
        {
            InitializeComponent();

            // RGBA Color
            Stage toDo = new Stage("To-Do", Color.FromArgb(100, 100, 100, 100));

            // HEX Color
            Stage inProgress = new Stage("In Progress", (Color)ColorConverter.ConvertFromString("#FFB0B0B0"));

            // Pre-defineret colors i .NET WPF
            Stage done = new Stage("Done", Colors.Green);

            stages.Add(toDo);
            stages.Add(inProgress);
            stages.Add(done);

            TaskItem test = new TaskItem(
                "Feje gulv",
                "Gulvet skal fejes grundigt",
                "Konrad",
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                Colors.Green,
                Colors.Blue,
                toDo);

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
                inProgress);

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
                inProgress);

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


            toDo.tasks.Add(test);

            inProgress.tasks.Add(igang);
            inProgress.tasks.Add(igang2);

            done.tasks.Add(klaret);
            done.tasks.Add(klaret2);

            DrawKanban();

        } 
        private void DrawKanban()
        {
            ViewGrid.Children.Clear();

            Grid KanbanBoard = new Grid
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            ViewGrid.Children.Add(KanbanBoard);

            KanbanBoard.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            KanbanBoard.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < stages.Count; i++)
            {
                KanbanBoard.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star), MinWidth = 200 });
                
                TextBlock stageLabel = new TextBlock();
                stageLabel.Text = stages[i].title;
                stageLabel.FontSize = 20;
                stageLabel.TextAlignment = TextAlignment.Center;
                stageLabel.Margin = new Thickness(0, 20, 0, 20);
                stageLabel.FontWeight = FontWeights.Bold;
                Grid.SetRow(stageLabel, 0);
                Grid.SetColumn(stageLabel, i);
                
                ListBox listbox = new ListBox();
                listbox.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                listbox.IsHitTestVisible = true;
                listbox.SelectionMode = SelectionMode.Single;
                listbox.Focusable = false;
                listbox.Drop += ListBox_Drop;
                listbox.DragEnter += ListBox_DragEnter;
                listbox.DragLeave += ListBox_DragLeave;
                listbox.Tag = stages[i];
                listbox.AllowDrop = true;
                //listbox.Width = 200;
                
                Grid.SetColumn(listbox, i);
                Grid.SetRow(listbox, 1);

                KanbanBoard.Children.Add(stageLabel);
                KanbanBoard.Children.Add(listbox);

                for (int j = 0; j < stages[i].tasks.Count; j++)
                {
                    ListBoxItem item = new ListBoxItem();

                    Grid cardGrid = new Grid();
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    StackPanel upperButtonPanel = new StackPanel();
                    upperButtonPanel.Orientation = Orientation.Horizontal;
                    upperButtonPanel.HorizontalAlignment = HorizontalAlignment.Right;
                    upperButtonPanel.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetRow(upperButtonPanel, 0);
                    Grid.SetColumn(upperButtonPanel, 0);

                    Button editButton = new Button();
                    //deleteButton.Width = 100;
                    editButton.Content = "Edit";
                    editButton.FontSize = 14;
                    editButton.FontWeight = FontWeights.Regular;
                    editButton.Background = new SolidColorBrush(Colors.GreenYellow);
                    editButton.Padding = new Thickness(8, 3, 8, 3);
                    editButton.Click += EditButton_Click;
                    editButton.Tag = stages[i].tasks[j];

                    Button deleteButton = new Button();
                    //deleteButton.Width = 100;
                    deleteButton.Content = "X";
                    deleteButton.FontSize = 14;
                    deleteButton.FontWeight = FontWeights.Regular;
                    deleteButton.Margin = new Thickness(10, 0, 0, 0);
                    deleteButton.Background = new SolidColorBrush(Colors.Red);
                    deleteButton.Padding = new Thickness(8, 3, 8, 3);
                    deleteButton.Click += DeleteButton_Click;
                    deleteButton.Tag = stages[i].tasks[j];


                    upperButtonPanel.Children.Add(editButton);
                    upperButtonPanel.Children.Add(deleteButton);



                    TextBlock title = new TextBlock();
                    title.Text = stages[i].tasks[j].title;
                    title.FontSize = 16;
                    title.FontWeight = FontWeights.Bold;
                    Grid.SetRow(title, 1);

                    TextBlock text = new TextBlock();
                    text.Text = stages[i].tasks[j].text;
                    text.TextWrapping = TextWrapping.Wrap;
                    text.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(text, 2);

                    TextBlock responsible = new TextBlock();
                    responsible.Text = $"Responsible: {stages[i].tasks[j].responsibleName}";
                    responsible.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(responsible, 3);


                    TextBlock startDateTime = new TextBlock();
                    startDateTime.Text = $"Start Date: {stages[i].tasks[j].startDateTime}";
                    startDateTime.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(startDateTime, 4);

                    TextBlock deadlineDateTime = new TextBlock();
                    deadlineDateTime.Text = $"Deadline Date: {stages[i].tasks[j].deadlineDateTime}";
                    deadlineDateTime.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(deadlineDateTime, 5);

                    TextBlock modifiedDateTime = new TextBlock();
                    modifiedDateTime.Text = $"Modified Date: {stages[i].tasks[j].modifiedDateTime}";
                    modifiedDateTime.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(modifiedDateTime, 6);

                    TextBlock endDateTime = new TextBlock();
                    endDateTime.Text = $"End Date: {stages[i].tasks[j].endDateTime}";
                    endDateTime.Margin = new Thickness(0, 10, 0, 0);
                    Grid.SetRow(endDateTime, 7);

                    cardGrid.Children.Add(upperButtonPanel);
                    cardGrid.Children.Add(title);
                    cardGrid.Children.Add(text);
                    cardGrid.Children.Add(responsible);
                    cardGrid.Children.Add(startDateTime);
                    cardGrid.Children.Add(deadlineDateTime);
                    cardGrid.Children.Add(modifiedDateTime);
                    cardGrid.Children.Add(endDateTime);

                    Border roundedBorder = new Border
                    {
                        CornerRadius = new CornerRadius(10),
                        BorderThickness = new Thickness(1),
                        BorderBrush = new SolidColorBrush(stages[i].tasks[j].borderColor),
                        Background = new SolidColorBrush(stages[i].tasks[j].backgroundColor),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        //Margin = new Thickness(10),
                        Padding = new Thickness(10),
                        Child = cardGrid
                    };

                    //item.Background = new SolidColorBrush(stages[i].tasks[j].backgroundColor);
                    item.Margin = new Thickness(10);
                    //item.BorderBrush = new SolidColorBrush(stages[i].tasks[j].borderColor);
                    //item.BorderThickness = new Thickness(2);
                    item.Content = roundedBorder;
                    item.Focusable = false;
                    item.IsHitTestVisible = true;
                    item.PreviewMouseMove += ListBoxItem_PreviewMouseMove;
                    item.Tag = stages[i].tasks[j];
                    listbox.Items.Add(item);

                    //item.Content = cardGrid;
                    //listbox.Items.Add(item);
                }
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TaskItem task = (TaskItem)button.Tag;
            ModalEditTask window = new ModalEditTask(task);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TaskItem task = (TaskItem)button.Tag;

            task.stage.tasks.Remove(task);
            task.stage = null;
            DrawKanban();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Modal window = new Modal(stages);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }
        }

        private void AddStageButton_Click(object sender, RoutedEventArgs e)
        {
            ModalAddStage window = new ModalAddStage(stages);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }
        }

        private void ListBoxItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if(e.OriginalSource is Button)
            {
                return;
            }

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem draggedItem = (ListBoxItem)sender;
                TaskItem taskItem = (TaskItem)draggedItem.Tag;
                DragDrop.DoDragDrop(draggedItem, taskItem, DragDropEffects.Move);

            }

        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TaskItem)))
            {
                e.Effects = DragDropEffects.Move;
                ListBox listbox = (ListBox)sender;
                listbox.Background = new SolidColorBrush(Colors.Red);

            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

        }

        private void ListBox_DragLeave(object sender, DragEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            listbox.ClearValue(ListBox.BackgroundProperty);
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TaskItem)))
            {
                TaskItem task = (TaskItem)e.Data.GetData(typeof(TaskItem));
                ListBox targetListBox = (ListBox) sender;
                Stage targetStage = (Stage)targetListBox.Tag;

                if(task.stage != targetStage)
                {
                    task.stage.tasks.Remove(task);
                    targetStage.tasks.Add(task);
                    task.stage = targetStage;
                    DrawKanban();
                }
            }

        }
    }
}