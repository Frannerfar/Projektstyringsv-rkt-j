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
    /// Interaction logic for ModalStageEdit.xaml
    /// </summary>
    public partial class ModalStageEdit : Window
    {
        Stage stage;

        public ModalStageEdit(Stage stage)
        {
            InitializeComponent();

            this.stage = stage;
            ModalTitle.Text = $"Edit Stage '{stage.title}'";
            Title.Text = stage.title;
        }

        private void ModalEditStage(object sender, RoutedEventArgs e)
        {
            stage.title = Title.Text;

            this.DialogResult = true;
            this.Close();
        }

        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
