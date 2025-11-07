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
        // Samling af alle stages, som bruges til at loope alle stages ud i UI og til Dropdown i Add Task og Edit Task
        List<Stage> stages = new List<Stage>();

        // Constructor
        public MainWindow()
        {
            // Method fra window der starter vinduet og sætter komponenter
            InitializeComponent();

            // Vi opretter 3 standard stages; "To-Do", "In Progress" og "Done", for at følge normalt Kanban layout.
            // Hver af dem er oprettet med forskellige måder at lave farver på; Hex code, RGB(A) og predefineret WPF Colors.
            // RGBA Color
            Stage toDo = new Stage("To-Do", Color.FromArgb(100, 100, 100, 100));
            // HEX Color
            Stage inProgress = new Stage("In Progress", (Color)ColorConverter.ConvertFromString("#FFB0B0B0"));
            // Pre-defineret colors i .NET WPF
            Stage done = new Stage("Done", Colors.Green);

            // Vi tilføjer de 3 stages vi lige har lavet, til vores liste "stages" der holder styr på alle stages oprettet.
            stages.Add(toDo);
            stages.Add(inProgress);
            stages.Add(done);


            // variabel af typen DateTime til brug i TaskItem, til at lave dynamisk Test eksempel opgave.
            DateTime now = DateTime.Now;

            // instantiering af TaskItem, som Test eksempel til Kanban boardet.
            TaskItem test = new TaskItem(
                "Feje gulv",
                "Gulvet skal fejes grundigt",
                "Konrad",
                // Her bruges reference til variablen now, for at bruge den nuværende dag som udgangspunkt
                new DateTime(new DateOnly(now.Year, now.Month, now.Day), new TimeOnly(9, 30)),
                // Her bruges reference til variablen now, for at bruge den nuværende dag + 1 dag
                new DateTime(new DateOnly(now.Year, now.Month, now.AddDays(1).Day), new TimeOnly(12, 00)),
                Colors.Green,
                Colors.Blue,
                toDo);

            // Efter instantiering af nyt TaskItem, indsættes test eksemplet ind i "To-Do" staget,
            // ved at lægge det i stagets liste af tasks.
            toDo.tasks.Add(test);

            // Metode kald til at Redraw Kanban Board UI.
            // Vi kunne have lavet det i MVVM design, med data bindings, ObservableCollections i stedet for List
            // Og opdelt UI, Data og Logik mere (MVVM stil).
            // Men i stedet så kalder vi vores egen UI Draw funktion. Mere proceduralt end deklarativ.
            DrawKanban();
        } 

        // Vores Kanban Board UI Draw funktion
        // Vi opbygger proceduralt, så alt UI bliver lavet i kode og indsat gennem "Content" og "Children".
        // Fordelen ved det, er at vi kan de præcist hvad der foregår, modsat MVVM med databindings og commands
        // som kan virke mere som sort magi.
        // Ikke særligt performant i forhold til databindings der opdaterer de individuelle elementer,
        // men for at få forståelsen, så er denne måde mere logisk.
        private void DrawKanban()
        {
            // Vi fjerner alt UI i Grid på forhånd, så vi nu kan populate UI med nye elementer
            ViewGrid.Children.Clear();

            // Små hjælpe variabler sat til senere brug i listboxitem margin og Kanban Board column MinWidth
            // for at sikre UI designet
            int minBoardWidth = 380;
            int boardItemMargin = 10;

            // instantiering af ScrollViewer element, så der automatisk kan scrolles horizontalt,
            // hvis mængden af stages overstiger størrelsen på kanban boardets grid
            ScrollViewer scrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                CanContentScroll = true
            };

            // instantiering af nyt Grid
            Grid KanbanBoard = new Grid
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            // nye grid indsættes under scrollviewer, så der netop automatisk tilføjes side scroll (horizontalt)
            // hvis gridet udvides til mere end vinduets størrelse.
            scrollViewer.Content = KanbanBoard;
            // scroll viewer tilføjes til vores statiske ViewGrid grid, som er defineret i XAML delen.
            ViewGrid.Children.Add(scrollViewer);

            // Oprettelse af 3 rows.
            // Øverste skal tilpasse sig content
            KanbanBoard.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            // midterste skal bruge så meget plads som muligt
            KanbanBoard.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            // kun bruge 30 pixels, bare for at skabe lidt luft i bunden af vinduet til kanban boardet.
            KanbanBoard.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

            // Boardet / grid skal centrere stages
            KanbanBoard.HorizontalAlignment = HorizontalAlignment.Center;

            // Her begynder vores primære process på at loope alle stages ud
            for (int i = 0; i < stages.Count; i++)
            {
                // Hvert stage skal have sin egen kolonne i gridet, derfor tilføjer vi her et grid.
                // Vi tilføjer en minwidth som bruger variablen minBoardWidth og sætter max width til at være 600
                // Dette er kun for bedre UI design niceness.
                KanbanBoard.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star), MinWidth = minBoardWidth, MaxWidth = 600 });
                

                // instantiering af Text, samt sættelse af tekst og attributes som tekst størrelse, 
                // margin, skrifttykkelse, centrering osv.
                TextBlock stageLabel = new TextBlock();
                stageLabel.Text = stages[i].title;
                stageLabel.FontSize = 20;
                stageLabel.TextAlignment = TextAlignment.Center;
                // Margin kræver et objekt af typen Thickness, så derfor instantieres nyt objekt
                stageLabel.Margin = new Thickness(0, 20, 0, 20);
                stageLabel.FontWeight = FontWeights.Bold;

                // Vi instantierer en stack panel box der kan lægge elementer ved siden af hinanden
                StackPanel stageUpperButtonPanel = new StackPanel();
                // vi sætter stackpanel til at sætte elementer ved siden af hinanden, horizontalt og ikke vertikalt.
                stageUpperButtonPanel.Orientation = Orientation.Horizontal;

                // instantiering af delete button med forskellige attributes, som før.
                Button deleteStageButton = new Button();
                deleteStageButton.Content = "X";
                deleteStageButton.FontSize = 14;
                deleteStageButton.FontWeight = FontWeights.Regular;
                // Margin kræver et objekt af typen Thickness, så derfor instantieres nyt objekt
                deleteStageButton.Margin = new Thickness(5, 5, 5, 5);
                // Background kræver et objekt af typen SolidColorBrush, så derfor instantieres nyt objekt
                // med farven vi gerne vil have som baggrundsfarve (brugt WPF predefineret farve)
                deleteStageButton.Background = new SolidColorBrush(Colors.Red);
                // Samme som margin, bare padding her.
                deleteStageButton.Padding = new Thickness(8, 3, 8, 3);
                // Vi sætter bredden på delete button til at være auto. lille som muligt og udvider sig til indholdet
                deleteStageButton.Width = double.NaN;
                // attributet tag kan indeholde reference til objekter, så her sætter vi reference til delete knappens
                // associeret stage, så når at vi trykker på denne specifikke knap, så ved funktionen 
                // hvilket specifikke stage der skal slettes
                deleteStageButton.Tag = stages[i];
                // Her tilføjer vi funktion der skal køres, når Click event på denne button bliver triggeret
                deleteStageButton.Click += DeleteStageButton_Click;
                // Vi sætter cursor til at vise en hånd, når der hovers over button
                deleteStageButton.Cursor = Cursors.Hand;

                // Meget en gentagelse her. Instantiering af button. Sætter attributes.
                Button editStageButton = new Button();
                editStageButton.Content = "Edit Stage";
                editStageButton.FontSize = 14;
                editStageButton.FontWeight = FontWeights.Regular;
                editStageButton.Margin = new Thickness(5, 5, 5, 5);
                editStageButton.Background = new SolidColorBrush(Colors.GreenYellow);
                editStageButton.Padding = new Thickness(8, 3, 8, 3);
                // igen auto width
                editStageButton.Width = double.NaN;
                // tilføjelse af funktioon der skal køre ved Click event fra denne button
                editStageButton.Click += EditStageButton_Click;
                // Attribute tag som indeholder reference til vores stage, så EditStageButton ved
                // hvilket stage vi vil edit.
                editStageButton.Tag = stages[i];
                editStageButton.Cursor = Cursors.Hand;

                // Både edit stage button og delete stage button tilføjes til stackpanel, så de kommer til at lægge ved siden af hinanden
                stageUpperButtonPanel.Children.Add(editStageButton);
                stageUpperButtonPanel.Children.Add(deleteStageButton);
                // centrering af knapperne
                stageUpperButtonPanel.HorizontalAlignment = HorizontalAlignment.Center;

                // instantiering af nyt stackpanel, som vi kan smide titel i og som vi kan smide
                // stageUpperButtonPanel Stackpanel i.
                // så gør så at items ligger vertikalt og giver os dermed stage title først
                // og næste linje giver os både edit stage button og edit delete button
                StackPanel stageUpperPanel = new StackPanel();
                stageUpperPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                stageUpperPanel.Orientation = Orientation.Vertical;
                stageUpperPanel.Children.Add(stageLabel);
                stageUpperPanel.Children.Add(stageUpperButtonPanel);
                // Vi sætter hvor i KanbanBoard grid listbox skal være.
                // altid row 0
                Grid.SetRow(stageUpperPanel, 0);
                // altså at listbox bliver sat i kolonnen der matcher den kolonne der er lavet med det nye stage
                Grid.SetColumn(stageUpperPanel, i);

                // Instantiering af listbox.
                ListBox listbox = new ListBox();
                listbox.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                // Vi gør at elementet at rammes ved click
                listbox.IsHitTestVisible = true;
                // Vi forcer til at kun, at kunne vælge enkelt item;
                listbox.SelectionMode = SelectionMode.Single;
                // fjerner visuel indikation for at elementet er valgt
                listbox.Focusable = false;
                // tilføjer funktion der skal køre ved Drop trigger event i listbox
                listbox.Drop += ListBox_Drop;
                // tilføjer funktion der skal køre ved DragEnter trigger event i listbox
                listbox.DragEnter += ListBox_DragEnter;
                // tilføjer funktion der skal køre ved DropLeave trigger event i listbox
                listbox.DragLeave += ListBox_DragLeave;
                // tilføjer reference til hvilket stage listbox tilhører
                listbox.Tag = stages[i];
                // Vi giver lov til at elementer kan droppes i listbox
                listbox.AllowDrop = true;

                // rent UI niceness, at vi kun tilføjer left margin 10 på første listbox der bliver tilføjet
                // ellers har alle andre listboxes margin right 10
                if (i == 0)
                {
                    listbox.Margin = new Thickness(10, 0, 10, 0);
                }
                else
                {
                    listbox.Margin = new Thickness(0, 0, 10, 0);
                }

                // Vi sætter hvor i KanbanBoard grid listbox skal være.
                // altså at listbox bliver sat i kolonnen der matcher den kolonne der er lavet med det nye stage
                Grid.SetColumn(listbox, i);
                // altid i row 1
                Grid.SetRow(listbox, 1);

                // tilføjer title og buttons (edit og delete) i grid.
                KanbanBoard.Children.Add(stageUpperPanel);
                //derefter tilføjer vi listbox nedenunder
                KanbanBoard.Children.Add(listbox);


                // nu begynder vi at indsætte tasks i stage.
                // for hvert stage vi looper igennem, looper vi også igennem alle tasks til det specifikke stage
                // i stage brugte vi variablen "i", og i tasks bruger vi nu "j".
                for (int j = 0; j < stages[i].tasks.Count; j++)
                {
                    // for hver task, instantierer vi et nyt ListBoxItem
                    ListBoxItem item = new ListBoxItem();

                    // Vi instantierer et nyt grid
                    Grid cardGrid = new Grid();
                    // Vi definerer alle de forskellige rows vi skal bruge til at vise vores data fra task.
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    cardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    // kun 1 kolonne som makser sig selv ud - dog med minimum 200 pixel width/bredde.
                    cardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star), MinWidth = 200});

                    // instantierer nyt Stackpanel
                    StackPanel upperButtonPanel = new StackPanel();
                    // stackpanel skal være horizontalt. Lægge sig til højre og være centreret vertikalt.
                    upperButtonPanel.Orientation = Orientation.Horizontal;
                    upperButtonPanel.HorizontalAlignment = HorizontalAlignment.Right;
                    upperButtonPanel.VerticalAlignment = VerticalAlignment.Center;
                    // sætter det nye stack panel i det nye grid for tasken.
                    Grid.SetRow(upperButtonPanel, 0);
                    Grid.SetColumn(upperButtonPanel, 0);


                    // instantierer ny button og sætter attributes. Vi har allerede gennemgået det her flere gange
                    Button editButton = new Button();
                    editButton.Content = "Edit";
                    editButton.FontSize = 14;
                    editButton.FontWeight = FontWeights.Regular;
                    editButton.Background = new SolidColorBrush(Colors.GreenYellow);
                    editButton.Padding = new Thickness(8, 3, 8, 3);
                    // tilføjer funktion der skal køre ved trigger af knappen click event.
                    editButton.Click += EditTaskButton_Click;
                    // vi tilføjer en reference til tasken, i buttons Tag attribute.
                    editButton.Tag = stages[i].tasks[j];
                    // sætter cursor til at indikere et klik ved hover over button
                    editButton.Cursor = Cursors.Hand;


                    // instantierer ny button og sætter attributes. Vi har allerede gennemgået det her flere gange
                    Button deleteButton = new Button();
                    deleteButton.Content = "X";
                    deleteButton.FontSize = 14;
                    deleteButton.FontWeight = FontWeights.Regular;
                    deleteButton.Margin = new Thickness(10, 0, 0, 0);
                    deleteButton.Background = new SolidColorBrush(Colors.Red);
                    deleteButton.Padding = new Thickness(8, 3, 8, 3);
                    // tilføjer funktion der skal køre ved trigger af knappen click event.
                    deleteButton.Click += DeleteTaskButton_Click;
                    // vi tilføjer en reference til tasken, i buttons Tag attribute.
                    deleteButton.Tag = stages[i].tasks[j];
                    // sætter cursor til at indikere et klik ved hover over button
                    deleteButton.Cursor = Cursors.Hand;


                    // Begge buttons tilføjes til stackpanel, der blev oprettet ovenover buttons instantieringskode.
                    upperButtonPanel.Children.Add(editButton);
                    upperButtonPanel.Children.Add(deleteButton);

                    // instantierer ny tekst blok og sætter attributes. Vi har allerede gennemgået det her flere gange
                    TextBlock title = new TextBlock();
                    // Text block tekst sættes til at være taskens titel.
                    title.Text = stages[i].tasks[j].title;
                    title.FontSize = 16;
                    title.FontWeight = FontWeights.Bold;
                    // Vi tilføjer wrap for at få teksten til at automatisk gå til ny linje,
                    // hvis teksten fylder for meget.
                    title.TextWrapping = TextWrapping.Wrap;
                    // sætter teksten til at starte fra venstre side
                    title.TextAlignment = TextAlignment.Left;
                    // sætter title textblock til at være placeret på row 1, under knapper.
                    Grid.SetRow(title, 1);

                    // instantierer ny tekst blok og sætter attributes. Vi har allerede gennemgået det her flere gange
                    TextBlock text = new TextBlock();
                    // Text block tekst sættes til at være taskens text (beskrivelse).
                    text.Text = stages[i].tasks[j].text;
                    text.TextWrapping = TextWrapping.Wrap;
                    text.TextAlignment = TextAlignment.Left;
                    text.Margin = new Thickness(0, 10, 0, 0);
                    // sætter textblocken til at være på row 2
                    Grid.SetRow(text, 2);

                    // instantierer ny tekst blok og sætter attributes. Vi har allerede gennemgået det her flere gange
                    TextBlock responsible = new TextBlock();
                    // Text block "ansvarlig" sættes til at være taskens responsibleName.
                    // Vi bruger $ foran string "", så vi kan bruge variabler i stringen. 
                    responsible.Text = $"Responsible: {stages[i].tasks[j].responsibleName}";
                    responsible.Margin = new Thickness(0, 10, 0, 0);
                    responsible.TextWrapping = TextWrapping.Wrap;
                    responsible.TextAlignment = TextAlignment.Left;
                    // Sætter textblocken til row til 3
                    Grid.SetRow(responsible, 3);

                    // instantierer ny tekst block og sætter attributes
                    TextBlock startDateTime = new TextBlock();
                    // vi bruger også $ tegn her for "", for at kunne bruge variabler i string.
                    startDateTime.Text = $"Start Date: {stages[i].tasks[j].startDateTime}";
                    startDateTime.Margin = new Thickness(0, 10, 0, 0);
                    // Sætter textblocken til row til 4
                    Grid.SetRow(startDateTime, 4);

                    // instantierer ny tekst block og sætter attributes
                    TextBlock deadlineDateTime = new TextBlock();
                    // vi bruger også $ tegn her for "", for at kunne bruge variabler i string.
                    deadlineDateTime.Text = $"Deadline Date: {stages[i].tasks[j].deadlineDateTime}";
                    deadlineDateTime.Margin = new Thickness(0, 10, 0, 0);
                    // Sætter textblocken til row til 5
                    Grid.SetRow(deadlineDateTime, 5);


                    // alle de TextBlocks vi har oprettet, tilføjes til Grid.
                    cardGrid.Children.Add(upperButtonPanel);
                    cardGrid.Children.Add(title);
                    cardGrid.Children.Add(text);
                    cardGrid.Children.Add(responsible);
                    cardGrid.Children.Add(startDateTime);
                    cardGrid.Children.Add(deadlineDateTime);
                    
                    // instantiering af Border element. Elementet bruger til at skabe runde borders.
                    // for at ikke gøre UIen mærkelig visuelt, så er det også her vi ender med at sætte
                    // taskens background color og taskens borderColor.
                    Border roundedBorder = new Border
                    {
                        CornerRadius = new CornerRadius(10),
                        BorderThickness = new Thickness(1),
                        // Det er her vi laver border med taskens border color
                        // Vi instantierer et nyt SolidColorBrush objekt og indsætter farven
                        // Derefter sættes Borderens BorderBrush til at være den nye SolidColorBrush
                        BorderBrush = new SolidColorBrush(stages[i].tasks[j].borderColor),
                        // Samme gør vi her, bare med background color
                        Background = new SolidColorBrush(stages[i].tasks[j].backgroundColor),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Padding = new Thickness(10),
                        // her sætter vi Border elements child til at være gridet som vi bruger til at håndtere
                        // textblocks som title, text, responsible, startdatetime og deadlinedatetime
                        Child = cardGrid
                    };

                    // ListBoxItem margin sættes til at være en fast margin i alle sider, og som bruger variablen
                    // boardItemMargin
                    item.Margin = new Thickness(boardItemMargin);
                    // ListBoxItem elementet får et child, som er vores Border element der indeholder farver og border,
                    // og som indeholder cardGrid
                    item.Content = roundedBorder;
                    // fjerner visuel indikator for at item er valgt
                    item.Focusable = false;
                    // vi sørger for at ListBoxItem elementet kan rammes med click
                    item.IsHitTestVisible = true;
                    // tilføjer funktion der kører ved PreviewMouseMove event (basically drag bevægelse)
                    item.PreviewMouseMove += ListBoxItem_PreviewMouseMove;
                    // Vi tilføjer reference til den specifikke task
                    item.Tag = stages[i].tasks[j];
                    // når der hovers over item, så ændres cursor til at vise
                    // en cursor som indikerer at elementet kan rykkes.
                    item.Cursor = Cursors.SizeAll;
                    // udregnet MaxWidth baseret på boardets minimum width og med indregnet margin.
                    item.MaxWidth = minBoardWidth - (boardItemMargin * 2);
                    // vi tilføjer ListBoxItem (der indeholder alt grafisk og alt tekst i sine children, grandchildren osv.
                    // til ListBox (visuel repræsentation af stage)
                    listbox.Items.Add(item);

                }
            }
        }


        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TaskItem task = (TaskItem)button.Tag;
            ModalTaskEdit window = new ModalTaskEdit(task, stages);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // her tager vi 'sender' som er den knap der bliver trykket på og trigger funktionen, og gemmer 'sender' i 'button' af typen Button 
            // her typecaster vi 'sender' til Button, fordi vi ved det kun er en knap der kan trigger denne funktion
            Button button = (Button)sender;
            // her tager vi så 'button' hvor vi ved at den skal have noget bestemt data med i .Tag attributen og gemmer den i 'task' af type TaskItem
            // her typecaster vi button.Tag til TaskItem, fordi vi ved at knappen har TaskItem på sig i .Tag
            TaskItem task = (TaskItem)button.Tag;

            // her køres der en if sætning.
            // hvis den valgte task ikke har null i stage, må vi forvente at tasken har et stage og opdatere staget og task
            if (task.stage != null) 
            {
                // først tager vi den valgte task, derefter tilgår vi det stage den har reference til
                // hvor vi så tilgår den liste i staget hvor tasks ligger
                // til slut fjerner vi så den valgte task fra den liste
                task.stage.tasks.Remove(task);
                // den valgte task har stadig en reference til det stage det tilhørte og det fjerner vi ved at sætte taskens stage lig med null
                task.stage = null;
                // til sidst kalder koden så DrawKanban() som opdaterer kanban UI
                DrawKanban();
            }
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
            ModalStageAdd window = new ModalStageAdd(stages);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }
        }

        private void EditStageButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Stage stage = (Stage)button.Tag;
            ModalStageEdit window = new ModalStageEdit(stage);
            bool? success = window.ShowDialog();

            if (success == true)
            {
                DrawKanban();
            }
        }

        private void DeleteStageButton_Click(object sender, RoutedEventArgs e)
        {
            // her tager vi 'sender' som er den knap der bliver trykket på og trigger funktionen, og gemmer 'sender' i 'button' af typen Button
            // her typecaster vi 'sender' til Button, fordi vi ved det kun er en knap der kan trigger funktionen
            Button button = (Button)sender;
            // her tager vi så 'button' hvor vi ved at den har noget bestemt data med i .Tag attributen og gemmer den i 'stage' af typen Stage
            // her typecaster vi button.Tag til Stage, fordi vi ved at knappen har Stage på sig i .Tag
            Stage stage = (Stage)button.Tag;

            // her køres der en if statement
            // hvis det valgte stage indeholder mere end 0 tasks, vil det altså sige at staget ikke kan slettes og MessageBox vises
            if(stage.tasks.Count > 0)
            {
                MessageBox.Show("Please remove all tasks from stage, before removing stage");
            }
            // her køres et else statement
            // hvis det valgte stage indeholder 0 tasks, vil det altså sige at staget kan slettes
            else
            {
                // her tilgår vi listen med stages og fjerner det valgte stage
                stages.Remove(stage);
                // til sidst kalder koden DrawKanban() som opdaterer kanban UI
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
                listbox.Background = new SolidColorBrush(Colors.Beige);

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

                if(task.stage != targetStage && task.stage != null)
                {
                    task.stage.tasks.Remove(task);
                    targetStage.tasks.Add(task);
                    task.stage = targetStage;
                    DrawKanban();
                }
                targetListBox.ClearValue(ListBox.BackgroundProperty);
            }
        }
    }
}