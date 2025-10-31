using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    class Stage
    {
        public string title;
        public List<TaskItem> tasks = new List<TaskItem>();
        public Color backgroundColor;

        public Stage(string titleInput, Color colorInput)
        {
            title = titleInput;
            backgroundColor = colorInput;
            
        }
    }
}
