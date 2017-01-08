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
                ColumnNumber = 0;
                RowNumber = 0;
            }
            else {
                int tmp2 = Int32.Parse(tmp);
                tmp2++;
                int tens = tmp2 & 10; //zmienna przechowująca ile dziesiątek się mieści 
                tmp2 = tmp2 - tens;
                ColumnNumber = tmp2;
                RowNumber = tens;
            }
        }

        public int ColumnNumber
        {
            get
            {
                return columnNumber;
            }

            set
            {
                columnNumber = value;
            }
        }

        public int RowNumber
        {
            get
            {
                return rowNumber;
            }

            set
            {
                rowNumber = value;
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
