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
        public string title;
        public string text;
        public string responsibleName;
        public DateTime startDateTime;
        public DateTime deadlineDateTime;
        //public DateTime endDateTime;
        //public DateTime modifiedDateTime;
        public Stage? stage;

        public TaskItem(string titleInput, 
                        string textInput, 
                        string responsibleNameInput, 
                        DateTime startDateTimeInput,
                        DateTime deadlineDateTimeInput,
                        //DateTime endDateTimeInput, 
                        //DateTime modifiedDateTimeInput, 
                        Color backgroundColerInput, 
                        Color borderColorInput, 
                        Stage stageInput) 
            : base(backgroundColerInput, borderColorInput) //: base referer til parenten CardUI
        {
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
