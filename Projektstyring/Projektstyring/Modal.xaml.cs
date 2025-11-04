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
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : Window
       
    {

        List<Stage> stages;
        public Modal(List<Stage> stages)
        {
            InitializeComponent();

            this.stages = stages;

            for (int i = 0; i < stages.Count; i++)
            {
                Dropdown.Items.Add(stages[i].title);
                Dropdown.SelectedIndex = 0;
            }

                

        }

        private void ModalAddTask(object sender, RoutedEventArgs e)
        {
            string titleInput = Title.Text;
            string textInput = Text.Text;
            string responsible = Responsible.Text;
            Stage selectedStage = stages[Dropdown.SelectedIndex];

            TaskItem task = new TaskItem(
                titleInput,
                textInput,
                responsible,
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                new DateTime(new DateOnly(2025, 12, 18), new TimeOnly(15, 30)),
                Colors.Magenta,
                Colors.White,
                selectedStage);

            selectedStage.tasks.Add(task);
            this.DialogResult = true;
            this.Close();

        }
    }
}
