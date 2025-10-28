using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    class Stage
    {
        string title;
        List<Task> tasks = new List<Task>();
        Color backgroundColor;

        public Stage(string titleInput, Color colorInput)
        {
            title = titleInput;
            backgroundColor = colorInput;
        }
    }
}
