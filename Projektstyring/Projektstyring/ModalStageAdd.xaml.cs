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
    /// Interaction logic for ModalStageAdd.xaml
    /// </summary>
    public partial class ModalStageAdd : Window
    {
        List<Stage> stages;

        public ModalStageAdd(List<Stage> stages)
        {
            InitializeComponent();

            this.stages = stages;
        }

        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ModalAddStage(object sender, RoutedEventArgs e)
        {
            string titleInput = Title.Text;

            Stage stage = new Stage(titleInput, Colors.White);

            stages.Add(stage);
            this.DialogResult = true;
            this.Close();

        }
    }
}
