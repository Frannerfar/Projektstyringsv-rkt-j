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
        string title;
        List<TaskItem> tasks = new List<TaskItem>();
        Color backgroundColor;

        public Stage(string titleInput, Color colorInput)
        {
            title = titleInput;
            backgroundColor = colorInput;
        }
    }
}
