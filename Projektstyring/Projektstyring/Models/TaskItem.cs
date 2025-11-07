using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    public class TaskItem : CardUI 
    // Vi vil gerne nedarve fra : CardUI fordi det var en god idé at have med i opgaven, og vise at vi kan det.
    // Har samtidig slettet bordercolor og backgroundcolor i attributes og constructoren, da vi ikke har brug for dem der.
    // Da det nu ligger på CardUI class, som vi nedarver fra
    {
        public string title; // attribute af typen string - er public
        public string text; // attribute af typen string - er public
        public string responsibleName; // attribute af typen string - er public
        public DateTime startDateTime; // attribute af typen DateTime - er public
        public DateTime deadlineDateTime; // attribute af typen DateTime - er public
        //public DateTime endDateTime;
        //public DateTime modifiedDateTime;
        public Stage? stage; // attribute af typen Stage - er public - refererrer det stage tasken er i.

        // Constructor der tager imod 3 strings, 2 DateTime, 2 Color og 1 stage.
        public TaskItem(string titleInput, 
                        string textInput, 
                        string responsibleNameInput, 
                        DateTime startDateTimeInput,
                        DateTime deadlineDateTimeInput,
                        Color backgroundColerInput, 
                        Color borderColorInput, 
                        Stage stageInput) 
            : base(backgroundColerInput, borderColorInput) //: base referer til parenten CardUI
            // vi bruger parametre lavet i constructoren til at videregive til CardUI
        {
            // Vi sætter attributes til at være parametrene
            title = titleInput;
            text = textInput;
            responsibleName = responsibleNameInput;
            startDateTime = startDateTimeInput;
            deadlineDateTime = deadlineDateTimeInput;
            //endDateTime = endDateTimeInput;
            //modifiedDateTime = modifiedDateTimeInput;
            stage = stageInput;
          
        }
    }
}
