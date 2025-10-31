using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projektstyring.Models;

namespace Projektstyring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Efter lidt research, så skal vi bruge Color fra System.Windows.Media, da det er til WPF.
        // Har lavet eksempler på de 3 stages, som alle tager imod colors på forskellige måder.
        // Vi kan gennemgå det sammen, hvis der er spørgsmål til color codes.

        // RGBA Color
        Stage notdoing = new Stage("Not Doing", Color.FromArgb(100, 100, 100, 100));
        
        // HEX Color
        Stage doing = new Stage("Doing", (Color)ColorConverter.ConvertFromString("#FFB0B0B0"));

        // Pre-defineret colors i .NET WPF
        Stage done = new Stage("Done", Colors.Green);



        // Jeg har ændet Class navn fra Task til TaskItem, da Task er type til async operationer, som vi ikke har været igennem.
        // TODO: Vi mangler at lave constructor, så hver task bliver oprettet korrekt og derefter kan tilføjes til Stage liste.
        
        TaskItem test = new TaskItem("Feje gulv", 
                                        "Gulvet skal fejes grundigt", 
                                        "Konrad", 
                                        new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                                        new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)), 
                                        new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                                        new DateTime(new DateOnly(2025, 11, 6), new TimeOnly(9, 45)),
                                        Colors.Green, 
                                        Colors.Blue);
    }

}