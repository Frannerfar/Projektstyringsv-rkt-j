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
    /// 

    //public accessmodifier
    //ModalStageEdit nedarver fra Window og vises ved at der vises " : Window ". Window kommer fra WPF.
    //Class navn er ModalStageEdit

    public partial class ModalStageEdit : Window
    {
        //Attributes, den hvide "stage" er variabelnavnet, den grønne er datatypen "Stage"
        Stage stage;

        //Constructoren, "ModalStafeEdit"
        //Den har et parameter, der er datatypen (grøn) "Stage"
        //Vi laver en variabel der navngives (lyseblå) "stage"
        public ModalStageEdit(Stage stage)
        {
            InitializeComponent(); //Metodekald.
                                   //InitializeComponent kommer fra Window, som er en class i WPF, 
                                   //som tager xaml og laver vinduet, og viser UI'en

            this.stage = stage; //Vi tager "stage" og lægger over i "this.stage"  
            ModalTitle.Text = $"Edit Stage '{stage.title}'"; //Tekstblokken ModalTitle.Text får værdien af den string vi laver
                                                            // Vi bruger string "" og sætter et $ foran, da vi vil bruge {variabler} i string
            Title.Text = stage.title; //Vi tager "stage.title" og sætter det over i tektsboksen Title.Text
        }

        //Denne funktion kører når der trykkes på "Save Stage"-knappen
        private void ModalEditStage(object sender, RoutedEventArgs e)
        {
            stage.title = Title.Text; //Vi tager "Title.text" og sætter over i "stage.title", dermed har vi opdateret stagens title

            this.DialogResult = true; //Her sættes vinduets DialogResult variablen til at være "true", det bruges i MainWindow når dette vindue lukkes
            this.Close(); //Lukker vinduet
        }

        //Denne funktion kører når der trykkes på "Cancel"-knappen
        private void ModalCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; //Her sættes vinduets DialogResult variablen til at være "false", det bruges i MainWindow når dette vindue lukkes
            this.Close(); //Lukker vinduet
        }
    }
}
