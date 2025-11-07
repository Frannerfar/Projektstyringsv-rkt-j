using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Projektstyring.Models;

namespace Projektstyring
{
    /// <summary>
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        // Attributes
        List<Stage> stages;
        Color selectedColor;

        // Constructor der tager List<Stage> som parameter
        public Modal(List<Stage> stages)
        {
            InitializeComponent();

            // Vi opdaterer border elementet til at have farven, som de tre sliders i UI har af værdi
            // R, G og B værdier.
            UpdateColorPreview();

            // constructorens parameter indsættes i klassens attribute stages, som den kan accesses fra andre funktioner
            this.stages = stages;

            // Vi populater dropdown menu med alle mulige stages (kun deres titler)
            for (int i = 0; i < stages.Count; i++) 
            {
                Dropdown.Items.Add(stages[i].title);
                // Sætter standard valget til at være den første
                Dropdown.SelectedIndex = 0;
            }

            // Vi populater selve dropdown menuer med tid, af 30 minutters increments. 24 timer * 2 = 48 elementer
            // Så vi looper 24 forskellige timer
            for (int h = 0; h < 24; h++)
            {
                // Derefter looper vi for hver time, igennem minutter.
                // Minutter er enten 0 eller 30. Ved 60 stopper loopet og vi går videre til næste time
                for (int m = 0; m < 60; m += 30)
                {
                    // Vi sætter time formatet.
                    // :D2 er en måde at enforce et specifikt tal format, når vi laver tal til strings
                    string time = $"{h:D2}:{m:D2}";
                    // tiden tilføjes til starttids dropdown og deadline dropdown
                    StartTimeCombo.Items.Add(time);
                    DeadlineTimeCombo.Items.Add(time);
                }
            }

            // Alle 3 color sliders får funktionen de skal kalde, når deres slider value er ændret
            RedSlider.ValueChanged += ColorSliderChanged;
            GreenSlider.ValueChanged += ColorSliderChanged;
            BlueSlider.ValueChanged += ColorSliderChanged;

            // Vi sætter starttid og deadline dropdowns til at have en standard værdi.
            // Pga. at der er 30 minutters increments, kan vi ved at sætte tallet 2, vælge en time senere for deadline
            StartTimeCombo.SelectedItem = StartTimeCombo.Items[0];
            DeadlineTimeCombo.SelectedItem = StartTimeCombo.Items[2];

            // Vi sætter variabel now, af datatypen DateTime, så vi kan bruge dagens nuværende dato,
            // som startpunkt for vores DatePicker funktion
            // udgangspunktet er at deadline altid er mindst en dag senere end starttidspunkt
            DateTime now = DateTime.Now;
            StartDatePicker.SelectedDate = now.Date;
            DeadlineDatePicker.SelectedDate = now.Date.AddDays(1);
        }

        // funktion der kaldes for at opdatere Color Preview element UIet med ny farve
        private void UpdateColorPreview()
        {
            // vi bruger bytes, fordi det kræver Color.FromRgb
            // derfor konverterer vi fra double til byte, i R, G og B
            byte r = Convert.ToByte(RedSlider.Value);
            byte g = Convert.ToByte(GreenSlider.Value);
            byte b = Convert.ToByte(BlueSlider.Value); 
            // ny farve laves og gemmes i klassens attribute i toppen, som allerede er defineret.
            selectedColor = Color.FromRgb(r, g, b);
            // vi laver ny baggrund og bruger farven. Dermed opdaterer vi UI
            ColorPreview.Background = new SolidColorBrush(selectedColor);
        }

        // Color sliders kalder denne funktion ved ValueChange
        private void ColorSliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // kalder vores funktion der opdaterer color og UI
            // Dette er lavet til sin egen funktion, for at vi kunne bruge den i constructoren også -
            // Altså ved opstart af vinduet.
            UpdateColorPreview();
        }

        
        private DateTime MergeDateAndTime(DateTime? date, string timeString)
        {
            // Vi tjekker om den DateTime vi har fået som argument er null eller ikke indeholder noget.
            if (date == null || string.IsNullOrEmpty(timeString))
            {
                // hvis den er null eller ikke indeholder noget, så laver vi bare en DateTime.Now
                // som er tidspunktet lige nu - bare for at systemet ikke fejler, og for at vi får en DateTime.
                return DateTime.Now;
            }
           
            // Her opdeler vi den string af tid vi har fået, som kommer fra dropdown tidsbokse
            // vi opdeler ved :
            // derfor skulle vi gerne få 2 items. første item vil være hours, næste item vil være minutes
            string[] parts = timeString.Split(':');
            // her sættes det første string item over i hour variablen, efter det er konverteret fra string til int
            int hour = int.Parse(parts[0]);
            // her sættes det anden string item over i minute variablen, efter det er konverteret fra string til int
            int minute = int.Parse(parts[1]);
            // Til sidst returnerer vi date, som vi ændrer til at have den nye tid med. Altså hour og minute
            return date.Value.Date.AddHours(hour).AddMinutes(minute);
        }

        // Når knappen "tilføj task" bliver trykket, så kører denne funktion
        private void ModalAddTask(object sender, RoutedEventArgs e)
        {
            // først laver vi validering. Hvis der ikke er valgt et validt stage, så giver vi besked om at vælge stage.
            if (Dropdown.SelectedItem == null)
            {
                MessageBox.Show("No valid stage selected for new task");
                // funktionen stopper efter at MessageBox er blevet vist og lukket.
                return;
            }

            // Nu da vi er sikker på at stage er valgt, sætter vi nogle hjælpe variabler.
            // Disse variabler får input af de forskellige textbox.text værdier
            string titleInput = Title.Text;
            string textInput = Text.Text;
            string responsibleInput = Responsible.Text;
            // det valgte stage vil være baseret ud fra det valgte i dropdown menu.
            Stage selectedStage = stages[Dropdown.SelectedIndex];

            // Vi laver start og deadline variabler, som bruger vores funktion til at merge en dato og en tid
            // fra dropdown og datepicker, så vi får et komplet DateTime objekt der kan bruges til instantiering
            // nyt taskitem objekt.
            DateTime start = MergeDateAndTime(StartDatePicker.SelectedDate, StartTimeCombo.SelectedItem?.ToString());
            DateTime deadline = MergeDateAndTime(DeadlineDatePicker.SelectedDate, DeadlineTimeCombo.SelectedItem?.ToString());

            // her instantierer vi så nyt taskitem objekt og lægger i variablen task, af typen TaskItem.
            TaskItem task = new TaskItem(titleInput,
                                        textInput,
                                        responsibleInput,
                                        start,
                                        deadline,
                                        selectedColor,
                                        Colors.Black,
                                        selectedStage);

            // Dernæst der tilføjer vi det nye instantieret task til det valgte stage.
            // her er stagets liste af tasks valgt og adder tasken
            selectedStage.tasks.Add(task);
            // Vi sætter vinduets DialogResult attribute til at være true, så det vil prompte en UI refresh
            // Når vi returnerer til MainWindow
            this.DialogResult = true;
            // Vi lukker vinduet
            this.Close();

        }

        // Hvis der trykkes på knappen "Cancel" kaldes denne funktion
        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            // Vi sætter vinduets DialogResult attribute til at være false, så der IKKE er en UI refresh
            // når vi returnerer til MainWindow
            this.DialogResult= false;
            // vi lukker vinduet
            this.Close();
        }
    }
}
