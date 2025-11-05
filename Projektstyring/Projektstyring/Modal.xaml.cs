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
        List<Stage> stages;
        Color selectedColor;

        public Modal(List<Stage> stages)
        {
            InitializeComponent();

            UpdateColorPreview();

            this.stages = stages;

            for (int i = 0; i < stages.Count; i++) 
            {
                Dropdown.Items.Add(stages[i].title);
                Dropdown.SelectedIndex = 0;
            }

            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m += 30)
                {
                    string time = $"{h:D2}:{m:D2}";
                    StartTimeCombo.Items.Add(time);
                    DeadlineTimeCombo.Items.Add(time);
                }
            }

            RedSlider.ValueChanged += ColorSliderChanged;
            GreenSlider.ValueChanged += ColorSliderChanged;
            BlueSlider.ValueChanged += ColorSliderChanged;

            StartTimeCombo.SelectedItem = StartTimeCombo.Items[0];
            DeadlineTimeCombo.SelectedItem = StartTimeCombo.Items[2];

            DateTime now = DateTime.Now;
            StartDatePicker.SelectedDate = now.Date;
            DeadlineDatePicker.SelectedDate = now.Date.AddDays(1);
        }

        private void UpdateColorPreview()
        {
            byte r = Convert.ToByte(RedSlider.Value);
            byte g = Convert.ToByte(GreenSlider.Value);
            byte b = Convert.ToByte(BlueSlider.Value);
            selectedColor = Color.FromRgb(r, g, b);
            ColorPreview.Background = new SolidColorBrush(selectedColor);
        }

        private void ColorSliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorPreview();
        }

        private DateTime MergeDateAndTime(DateTime? date, string timeString)
        {
            if (date == null || string.IsNullOrEmpty(timeString))
            {
                return DateTime.Now;
            }

            var parts = timeString.Split(':');
            int hour = int.Parse(parts[0]);
            int minute = int.Parse(parts[1]);
            return date.Value.Date.AddHours(hour).AddMinutes(minute);
        }


        private void ModalAddTask(object sender, RoutedEventArgs e)
        {
            if (Dropdown.SelectedItem == null)
            {
                MessageBox.Show("No valid stage selected for new task");
                return;
            }

            string titleInput = Title.Text;
            string textInput = Text.Text;
            string responsibleInput = Responsible.Text;
            Stage selectedStage = stages[Dropdown.SelectedIndex];

            DateTime start = MergeDateAndTime(StartDatePicker.SelectedDate, StartTimeCombo.SelectedItem?.ToString());
            DateTime deadline = MergeDateAndTime(DeadlineDatePicker.SelectedDate, DeadlineTimeCombo.SelectedItem?.ToString());


            TaskItem task = new TaskItem(titleInput,
                                        textInput,
                                        responsibleInput,
                                        start,
                                        deadline,
                                        //new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                                        //new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                                        selectedColor,
                                        Colors.Black,
                                        selectedStage);

            selectedStage.tasks.Add(task);
            this.DialogResult = true;
            this.Close();

        }

        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
            this.Close();
        }
    }
}
