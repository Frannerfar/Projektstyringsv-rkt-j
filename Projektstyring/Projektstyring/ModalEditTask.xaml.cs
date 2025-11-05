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
    /// Interaction logic for ModalEditTask.xaml
    /// </summary>
    public partial class ModalEditTask : Window
    {
        TaskItem task;
        public ModalEditTask(TaskItem task)
        {
            InitializeComponent();
            this.task = task;
            Title.Text = task.title;
            Text.Text = task.text;
            Responsible.Text = task.responsibleName;
        }
    }
}
