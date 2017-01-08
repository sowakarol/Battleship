using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Shot
    {
        int columnNumber;
        int rowNumber;

        public Shot(String name)
        {
            String tmp = name.Replace("button1_Copy", "");
            if (tmp == "00")
            {
                columnNumber = 0;
                rowNumber = 0;
            }
            else {
                int tmp2 = Int32.Parse(tmp);
                tmp2++;
                int tens = tmp2 & 10; //zmienna przechowująca ile dziesiątek się mieści 
                tmp2 = tmp2 - tens;
                columnNumber = tmp2;
                rowNumber = tens;
            }
        }
    
        public int hit(Field field) // zwraca 1 jeśli strzelił w statek, 0 jeśli strzelił w wodę
        {
            if (field.CurrentState == State.SHIP_UNDAMAGED)
            {
                field.CurrentState = State.SHIP_DAMAGED;
                return 1;
            }
            return 0;
        }

    }
}
