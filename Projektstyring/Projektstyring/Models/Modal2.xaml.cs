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

namespace Projektstyring.Models
{
    /// <summary>
    /// Interaction logic for Modal2.xaml
    /// </summary>
    public partial class Modal2 : Window
    {
        List<Stage> stages;

        public Modal2(List<Stage> stages)
        {
            InitializeComponent();
            this.stages = stages;
        }

        private void AddStageButton_Click(object sender, RoutedEventArgs e)
        {
            string title = StageTitle.Text;

            Stage stage = new Stage(title, Colors.Green);

            stages.Add(stage);
            this.DialogResult = true;
            this.Close();
        }
    }
}
