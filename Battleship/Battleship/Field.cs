using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Field
    {
        State currentState;
        int rowNumber;
        int columnNumber;
        bool shooted; //zmienna sprawdzajaca czy pole zostale juz ustrzelone kiedys - wczesniej robiłem isEnabled=false; w MainWindows.xaml.cs ale nie było koloru(był kolor tła)

        public Field(State state, int rowNumber, int columnNumber)
        {
            currentState = state;
            this.RowNumber = rowNumber;
            this.ColumnNumber = columnNumber;
            Shooted = false;
        }

        internal State CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
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

        public bool Shooted
        {
            get
            {
                return shooted;
            }

            set
            {
                shooted = value;
            }
        }
    }




}
