using Projektstyring.Models;
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

namespace Projektstyring
{
    /// <summary>
    /// Interaction logic for ModalTaskEdit.xaml
    /// </summary>
    public partial class ModalTaskEdit : Window
    {
        TaskItem task;
        List<Stage> stages;
        Color selectedColor;

        public ModalTaskEdit(TaskItem task, List<Stage> stages)
        {
            InitializeComponent();

            this.stages = stages;
            this.task = task;

            ModalEditTaskTitle.Text = $"Edit Task '{task.title}'";

            Title.Text = task.title;
            Text.Text = task.text;
            Responsible.Text = task.responsibleName;

            for (int i = 0; i < stages.Count; i++)
            {
                Dropdown.Items.Add(stages[i].title);
            }

            Stage? taskStage = task.stage;
            if (taskStage != null)
            {
                for (int i = 0; i < Dropdown.Items.Count; i++)
                {
                    if (Dropdown.Items[i].ToString() == taskStage.title)
                    {
                        Dropdown.SelectedIndex = i;
                        break;
                    }

                }
            }
            else
            {
                Dropdown.SelectedIndex = 0;
            }

            RedSlider.Value = task.backgroundColor.R;
            GreenSlider.Value = task.backgroundColor.G;
            BlueSlider.Value = task.backgroundColor.B;
            ColorPreview.Background = new SolidColorBrush(task.backgroundColor);

            RedSlider.ValueChanged += ColorSliderChanged;
            GreenSlider.ValueChanged += ColorSliderChanged;
            BlueSlider.ValueChanged += ColorSliderChanged;

            UpdateColorPreview();

            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m += 30)
                {
                    string time = $"{h:D2}:{m:D2}";
                    StartTimeCombo.Items.Add(time);
                    DeadlineTimeCombo.Items.Add(time);
                }
            }

            string startTimeString = $"{task.startDateTime.Hour:D2}:{task.startDateTime.Minute:D2}";
            string deadlineTimeString = $"{task.deadlineDateTime.Hour:D2}:{task.deadlineDateTime.Minute:D2}";

            StartDatePicker.SelectedDate = task.startDateTime.Date;
            DeadlineDatePicker.SelectedDate = task.deadlineDateTime.Date;

            if (StartTimeCombo.Items.Contains(startTimeString))
            {
                StartTimeCombo.SelectedItem = startTimeString;
            }
            else
            {
                StartTimeCombo.SelectedIndex = 0;
            }

            if (DeadlineTimeCombo.Items.Contains(deadlineTimeString))
            {
                DeadlineTimeCombo.SelectedItem = deadlineTimeString;
            }
            else
            {
                DeadlineTimeCombo.SelectedIndex = 0;
            }
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

        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ModalEditTask(object sender, RoutedEventArgs e)
        {

            DateTime start = MergeDateAndTime(StartDatePicker.SelectedDate, StartTimeCombo.SelectedItem?.ToString());
            DateTime deadline = MergeDateAndTime(DeadlineDatePicker.SelectedDate, DeadlineTimeCombo.SelectedItem?.ToString());

            task.title = Title.Text;
            task.text = Text.Text;
            task.responsibleName = Responsible.Text;
            task.startDateTime = start;
            task.deadlineDateTime = deadline;
            task.backgroundColor = selectedColor;

            if(task.stage != null)
            {
                task.stage.tasks.Remove(task);
            }
            stages[Dropdown.SelectedIndex].tasks.Add(task);
            task.stage = stages[Dropdown.SelectedIndex];

            this.DialogResult = true;
            this.Close();
        }
    }
}
