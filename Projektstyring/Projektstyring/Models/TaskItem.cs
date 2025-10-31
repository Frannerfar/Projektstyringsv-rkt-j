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
        string title;
        string text;
        string responsibleName;
        DateTime startDateTime;
        DateTime endDateTime;
        DateTime modifiedDateTime;
        DateTime deadlineDateTime;
        Color backgroundColor;
        Color borderColor;

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
