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

    //Public klasse der nedarver fra window, samtidig med at det er en partial  
    //(Den har 2 dele, en xaml og cs fil).
    //Atrribute med en liste over eksisterende stages. 
    public partial class ModalStageAdd : Window
    {
        List<Stage> stages;
    //Constructor der tager listen af eksisterende stage ind som parameter. 
    // InitializeComponent = Henter layoutet fra xaml-filen.
    // this.stages = stages = er en referance hvor vi gemmer listen af stages, som tilføjes senere.
        public ModalStageAdd(List<Stage> stages)
        {
            InitializeComponent();

            this.stages = stages;
        }
        //Når brugeren trykker på "cancel" kaldes denne metode.
        // Dialog giver MainWindow besked om at der ikke er oprettet noget, derefter lukkes vinduet.
        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        //Når brugeren trykker på "addstage" kaldes denne metode
        // Den henter dataen, fra den box brugen har skrevet i hvorefter den opretter et nyt
        // stage objekt, med en titel og hvidbaggrund. Det nye stage tilføjes til listen af
        // allerede eksisterende stages. Dialog fortæller MainWindow der er oprettet noget nyt,
        // vinduet lukkes herefter.

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
