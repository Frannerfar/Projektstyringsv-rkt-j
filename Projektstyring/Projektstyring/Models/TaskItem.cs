using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    internal class TaskItem
    {
        public string title;
        public string text;
        public string responsibleName;
        public DateTime startDateTime;
        public DateTime endDateTime;
        public DateTime modifiedDateTime;
        public DateTime deadlineDateTime;
        public Color backgroundColor;
        public Color borderColor;

        public TaskItem(string titleInput, string textInput, string responsibleNameInput, DateTime startDateTimeInput, DateTime endDateTimeInput, DateTime modifiedDateTimeInput, DateTime deadlineDateTimeInput, Color backgroundColerInput, Color borderColorInput)
        {
            title = titleInput;
            text = textInput;
            responsibleName = responsibleNameInput;
            startDateTime = startDateTimeInput;
            endDateTime = endDateTimeInput;
            modifiedDateTime = modifiedDateTimeInput;
            deadlineDateTime = deadlineDateTimeInput;
            backgroundColor = backgroundColerInput;
            borderColor = borderColorInput;
        }

        public void AddText()
        {

        }
        public void AddStage()
        {

        }
    }
}
