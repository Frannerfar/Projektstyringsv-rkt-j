using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    public class Stage
    {
        public string title; // attribute, af typen title - bruges til at vise titel over vores stage
        public List<TaskItem> tasks = new List<TaskItem>(); // attribute, af typen list<TaskItem>,
        // bruges til at det specifikke stage ved hvilke tasks, stage skal lave
        public Color backgroundColor; // attribute, bruges ikke som det er nu, men kunne bruges til at sætte hvilken farve
        // tasks skulle have, i det her stage - dermed gøre tasks' farve afhængig af hvilket stage det er i.

        // Constructor der tager imod en string til titel og en Color som reprænsenterer R,G,B
        public Stage(string titleInput, Color colorInput)
        {
            // Begge attributes sættes til at være parameter inputs
            title = titleInput;
            backgroundColor = colorInput;
            
        }
    }
}
