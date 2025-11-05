using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
<<<<<<< Updated upstream
    internal class TaskItem : CardUI
=======
    public class TaskItem : CardUI //Vi vil gerne nedarve fra : CardUI. Har samtidig slettet bordercolor og backgroundcolor i attributes og constructoren, da vi ikke har brug for dem der. 
>>>>>>> Stashed changes
    {
        public string title;
        public string text;
        public string responsibleName;
        public DateTime startDateTime;
        public DateTime endDateTime;
        public DateTime modifiedDateTime;
        public DateTime deadlineDateTime;
        public Stage? stage;

        public TaskItem(string titleInput, 
                        string textInput, 
                        string responsibleNameInput, 
                        DateTime startDateTimeInput, 
                        DateTime endDateTimeInput, 
                        DateTime modifiedDateTimeInput, 
                        DateTime deadlineDateTimeInput, 
                        Color backgroundColerInput, 
                        Color borderColorInput, 
                        Stage stageInput) 
                        : base(backgroundColerInput, borderColorInput)
        {
            title = titleInput;
            text = textInput;
            responsibleName = responsibleNameInput;
            startDateTime = startDateTimeInput;
            endDateTime = endDateTimeInput;
            modifiedDateTime = modifiedDateTimeInput;
            deadlineDateTime = deadlineDateTimeInput;
            stage = stageInput;
        }

        public void AddText()
        {

        }
        public void AddStage()
        {

        }
    }
}
