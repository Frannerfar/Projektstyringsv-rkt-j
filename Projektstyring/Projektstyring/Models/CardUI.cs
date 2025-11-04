using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media; //Tilføjer Windows.Media for at kunne tilgå prædefinerede colors
using System.Threading.Tasks;

namespace Projektstyring.Models
{
    internal class CardUI
    {
        public Color backgroundColor; //attributes
        public Color borderColor;

        public CardUI(Color backgroundColorInput, Color borderColorInput) //Constructoren: Vi sætter reglerne for de ting vi kræver, der skal defineres ved oprettelse
        {
            //Referer til klassens attributes
            backgroundColor = backgroundColorInput; //Her gemmer jeg det input og valg af farve i backgroundColorInput, ind i backgroundColor
            borderColor = borderColorInput; //Det samme sker her - borderColorInput gemmes ind i borderColor
        }
    }
}
