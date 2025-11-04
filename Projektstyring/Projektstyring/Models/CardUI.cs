using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    internal class CardUI
    {
        public Color backgroundColor;
        public Color borderColor;

        public CardUI(Color backgroundcolorInput, Color bordercolorInput)
        {
            backgroundColor = backgroundcolorInput;
            borderColor = bordercolorInput;
        }
    }
}
