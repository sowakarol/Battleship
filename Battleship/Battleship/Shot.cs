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
            System.Diagnostics.Debug.WriteLine(name);
            String tmp = name.Replace("button1_Copy", "");
            System.Diagnostics.Debug.WriteLine(tmp);

            if (tmp == "00")
            {
                ColumnNumber = 0;
                RowNumber = 0;
            }
            else {
                int tmp2 = Int32.Parse(tmp);
                tmp2++;
                int remainder = tmp2 % 10; //zmienna przechowująca ile jedności się mieści 
                int tens = (tmp2 - remainder)/10;
                System.Diagnostics.Debug.WriteLine(tmp2);
                System.Diagnostics.Debug.WriteLine(tens);

                ColumnNumber = remainder;
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

        public int hit(Field field) // zwraca 1 jeśli strzelił w statek, 0 jeśli strzelił w wodę, -1 jeśli strzelono
        {
            if(field.Shooted == true)
            {
                return -1;
            }


            field.Shooted = true;
            if (field.CurrentState == State.SHIP_UNDAMAGED)
            {
                field.CurrentState = State.SHIP_DAMAGED;
                return 1;
            }
            return 0;
        }

    }
}
